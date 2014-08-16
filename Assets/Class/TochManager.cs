using UnityEngine;
using System.Collections;
using System;



[RequireComponent(typeof(BoxCollider2D))]
public class TochManager : MonoBehaviour
{
		#region EVENTS
		public event Action ClickMe;

		private void clickMeHandler ()
		{
				if (ClickMe != null) {
						ClickMe ();
				}

		}
		#endregion

		private void OnMouseDown ()
		{
				clickMeHandler ();

		}
		
}
