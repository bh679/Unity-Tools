using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.Utilities
{

	public class chooseGameobject : MonoBehaviour
	{
		//selects a gameobject from a list of gameobjects
		//enables the selected one and disables the rest
		
		public GameObject[] gameObjects;
		
		public void chooseObject(int x)
		{
			for(int i = 0; i < gameObjects.Length; i++){
				gameObjects[i].SetActive(false);
			}
			
			gameObjects[x].SetActive(true);
		}
		
		public void chooseNothing() //disables all gameobjects
		{
			for(int i = 0; i < gameObjects.Length; i++){
				gameObjects[i].SetActive(false);
			}
		}
	}

}