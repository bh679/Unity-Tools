using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BrennanHatton.UnityTools.LegacyUI
{
	
	public class KeyPad : MonoBehaviour
	{
		public InputField inputField;
		
		public void Type(string _char)
		{
			inputField.text += _char;
		}
		
		public void Backspace()
		{
			inputField.text = inputField.text.Remove(inputField.text.Length-1,1);
		}
		
		public void Clear()
		{
			inputField.text = "";
		}
	}	
}