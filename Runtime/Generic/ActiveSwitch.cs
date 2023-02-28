/*
Brennan Hatton
2020ish
Class for swithcing active state of GameObjects or Monobehaviours 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.UnityTools
{
	
	public class ActiveSwitch : MonoBehaviour
	{
		public GameObject gameObjectToSwitch;
		public MonoBehaviour behaviourToSwitch;
		
		public void Switch()
		{
			SwitchGameObject();
			SwitchBehaviour();
		}
		
		public void SwitchGameObject()
		{
			if(gameObjectToSwitch != null)
				gameObjectToSwitch.SetActive(!gameObjectToSwitch.activeInHierarchy);
		}
		
		public void SwitchBehaviour()
		{
			if(behaviourToSwitch != null)
				behaviourToSwitch.enabled =!behaviourToSwitch.enabled;
		}
	}

}