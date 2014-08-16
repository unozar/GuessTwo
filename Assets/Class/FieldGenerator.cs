using UnityEngine;
using System.Collections;
using System;



public class FieldGenerator : MonoBehaviour
{

		#region SERIALIZE FIELDS
		[SerializeField]
		[Range(1,5)]
		private int
				width = 1, height = 1;

		[SerializeField]
		private Vector2
				center;

		[SerializeField]
		private Transform
				gameWrapper;
		[SerializeField]
		private GameObject
				gameElement;
		[SerializeField]
		private float
				size;
		#endregion

		#region Events
		public event Action<GameObject[,]> GetField;

		private void getFieldHandler (GameObject[,] field)
		{

				if (GetField != null) {
						GetField (field);
				}

		}
		#endregion

		#region Private Fields
		
		private Vector2? myStartPoint;
		private GameObject[,]  gameField;

		#endregion

		#region PRIVATE PROPERTIES
		private Vector2 startPoint {
				get {
						if (gameWrapper == null) {
								Debug.LogError ("Obj is null");
								return Vector2.zero;
						}
						if (myStartPoint != null)
								return (Vector2)myStartPoint;

						myStartPoint = new Vector2 (gameWrapper.position [0] - (width - 1) * 0.5f * size,
			                            gameWrapper.position [1] + (height - 1) * 0.5f * size);

						return (Vector2)myStartPoint;
				}
		}
		#endregion

		#region UNITY EVENTS
		private void Start ()
		{
				gameField = new GameObject[height, width];
				generationField ();
		}

		private void Update ()
		{

		}
		#endregion

		#region PRIVATE METHODS
		private void generationField ()
		{

				for (int i = 0; i < height; i++) {

						for (int j = 0; j < width; j++) {

								var temp = createItem ();
				
								if (temp == null) {
										Debug.LogError ("Obj is null");
										continue;
								}

								temp.transform.position = new Vector3 (startPoint [0] + j * size, 
				                                       startPoint [1] - i * size, 
				                                       0f);

								temp.transform.parent = gameWrapper;

								gameField [i, j] = temp;
						}
				}

				getFieldHandler (gameField);

		}


		private GameObject createItem ()
		{
				if (gameElement == null) {
						Debug.LogError ("Obj is null");
						return null;
				}

				var tempObj = Instantiate (gameElement) as GameObject;

				if (tempObj == null) {
						Debug.LogError ("Obj is null");
				}

				return tempObj;
		}
		#endregion

}

