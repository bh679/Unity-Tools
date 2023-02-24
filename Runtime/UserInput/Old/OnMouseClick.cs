//Brennan Hatton
//2020ish
//Unity event for mouse click. Using old input system 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BrennanHatton.UnityTools
{
	public class OnMouseClick : MonoBehaviour
	{
	
		public UnityEvent myEvent;
		public enum MouseButtons{
			left = 0,
			right = 1,
			middle = 2
		}
		public MouseButtons mouseButton = MouseButtons.left;
	
		public enum PressType
		{
			Down = 0,
			Hold = 1,
			Up = 2
		}
	
		public PressType pressType = PressType.Down;
	
		// Use this for initialization
		void Start () {
		
		}
	
		// Update is called once per frame
		void Update () {
	
			if (pressType == PressType.Down)
			{
				if (Input.GetMouseButtonDown((int)mouseButton))
				{
					myEvent.Invoke();
				}
			}
			else
				if (pressType == PressType.Hold)
				{
					if (Input.GetMouseButton((int)mouseButton))
					{
						myEvent.Invoke();
					}
				}
				else
					if (pressType == PressType.Up)
					{
						if (Input.GetMouseButtonUp((int)mouseButton))
						{
							myEvent.Invoke();
						}
					}
		}
	}
}
