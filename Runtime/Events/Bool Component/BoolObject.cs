using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BrennanHatton.UnityTools
{
	
	public class BoolObject : MonoBehaviour
	{
		public Toggle toggle;
		
		public bool _bool;
		
		public void enableBool(){
			_bool = true;
		}
		
		public void disableBool(){
			_bool = false;
		}
		
		public void toggleBool()
		{
			_bool = toggle.isOn;
		}
	}

}