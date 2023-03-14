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

	public class EnableOnDevice : MonoBehaviour
	{
		[System.Serializable]
		public class DevicesActive
		{
			public string deviceName = "Oculus Quest 2";
			bool active = false;
			public MonoBehaviour[] monoBehaviours;
			public GameObject[] gameObjects;
			
			public DevicesActive(string _deviceName)
			{
				deviceName = _deviceName;
			}
			
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
				
				for(int i =0; i < gameObjects.Length; i++)
				{
					gameObjects[i].SetActive(enabled);
				}
				
				for(int i =0; i < monoBehaviours.Length; i++)
				{
					monoBehaviours[i].enabled = enabled;
				}
			}
		}
		
		public DevicesActive[] devices = { 
			new DevicesActive("Default"),
			new DevicesActive("Oculus Quest"),
			new DevicesActive("Oculus Quest 2"),
			new DevicesActive("Oculus Quest Pro"),
			new DevicesActive("Oculus Rift S"),
			new DevicesActive("Pico")
		};
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
			
			//monoBehaviour.enabled = inverse?!found:found;
		}
	}

}
