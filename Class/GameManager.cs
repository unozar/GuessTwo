using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
		[SerializeField]
		private FieldGenerator
				fieldGenerator;

		private void Awake ()
		{
				if (fieldGenerator == null) {
						Debug.LogError ("Obj is null");
						return;
				}

				fieldGenerator.GetField += HandleGetField;
		}

		void HandleGetField (GameObject[,] obj)
		{
				print ("gameField we have!!!");
		}
}
