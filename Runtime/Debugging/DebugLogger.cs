using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.UnityTools
{

	public class DebugLogger : MonoBehaviour
	{
		public string messageEnd;
		public bool includeGameObjectName = true;
		public bool includeGameObjectLine = false;
		public bool onEnable = false;
		
		void OnEnable()
		{
			if(onEnable)
				DebugMessage("");
		}
		
		public void DebugMessage(string msg)
		{
			Debug.Log(msg + messageEnd + (includeGameObjectName?" "+this.gameObject.name:""));
			
			if(includeGameObjectLine)
				Debug.Log(this.gameObject);
		}
	}

}