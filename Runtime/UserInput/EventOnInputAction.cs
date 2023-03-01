/*
Brennan Hatton
1-03-2023

Call Unity Event when input action is triggered
todo: setup for float & vector2 input
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace BrennanHatton.UnityTools{
	
	public class EventOnInputAction : MonoBehaviour
	{
		public InputActionReference[] InputAction = new InputActionReference[1]{default};
		public UnityEvent onAction;
		[Tooltip("Enables the input action OnEnable")]
		public bool enable = true; 
		[Tooltip("Disables the input action OnDisable")]
		public bool disable = false;
	
		private void OnEnable() {
			
			for(int i = 0; i < InputAction.Length;i++)
			{
				if(enable)
					InputAction[i].action.Enable();
				InputAction[i].action.performed += ToggleActive;
			}
		}
	
		private void OnDisable() {
			
			for(int i = 0; i < InputAction.Length;i++)
			{
				if(disable)
					InputAction[i].action.Disable();
				InputAction[i].action.performed -= ToggleActive;
			}
		}
	
		public void ToggleActive(InputAction.CallbackContext context) {
			onAction.Invoke();
		}
	}

}