/*
Brennan Hatton
2022
Enable target monobehaviour on device name
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.UnityTools
{

	public class EnableMonoBehaviourOnDevice : MonoBehaviour
	{
		[System.Serializable]
		public class DevicesActive
		{
			public string deviceName = "Oculus Quest 2";
			bool active = false;
			
			public bool CheckAndSet()
			{
				SetEnable(CheckDeviceName());
				
				return active;
			}
			
			public bool CheckDeviceName()
			{
				return (SystemInfo.deviceName == deviceName);
			}
			
			public void SetEnable(bool enabled)
			{
				active = enabled;
			}
		}
		
		public DevicesActive[] devices;
		public MonoBehaviour monoBehaviour;
		public bool inverse = false;
		public bool onStart = true;
		
	    // Start is called before the first frame update
	    void Start()
		{
			if(onStart)
		    	Check();
	    }
	    
		void Check()
		{
			bool found = false;
			for(int i = 0; i < devices.Length;i ++)
			{
				if(!found)
					found = devices[i].CheckAndSet();
				else
					devices[i].SetEnable(false);
			}
		    
			if(!found)
			{
				devices[0].SetEnable(true);
			}
			
			monoBehaviour.enabled = inverse?!found:found;
		}
	}

}
