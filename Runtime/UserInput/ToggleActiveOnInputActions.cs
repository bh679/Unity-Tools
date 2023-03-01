/*
Brennan Hatton
2023-03-01
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BrennanHatton.UnityTools
{

	/// <summary>
	/// This script will toggle a GameObject whenever the provided InputAction is executed
	/// </summary>
	public class ToggleActiveOnInputActions : MonoBehaviour {
	
		public InputActionReference[] InputAction = new InputActionReference[1]{default};
		public GameObject ToggleObject = default;
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
				if(enable)
					InputAction[i].action.Disable();
				InputAction[i].action.performed -= ToggleActive;
			}
		}
	
		public void ToggleActive(InputAction.CallbackContext context) {
			if(ToggleObject) {
				ToggleObject.SetActive(!ToggleObject.activeSelf);
			}
		}
	}

}