using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BrennanHatton.UnityTools
{

	public class BoolChecker : MonoBehaviour
	{
		public BoolObject boolObject;
		
		public UnityEvent onEnabled;
		public UnityEvent onDisabled;
		
		
		public void checkBool()
		{
			if(boolObject._bool)
			{
				onEnabled.Invoke();
			}
			
			else
			{
				onDisabled.Invoke();
			}
		}
	}

}