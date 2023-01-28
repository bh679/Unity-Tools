using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.Utilities
{

	public class enableRandomGameobject : MonoBehaviour
	{
		public GameObject[] gameObjects;
		public bool onEnable = true;
		
		void Reset()
		{
			gameObjects = new GameObject[transform.childCount];
			for(int i = 0 ;i < transform.childCount; i++)
				gameObjects[i] = transform.GetChild(i).gameObject;
		}
		
		void OnEnable()
		{
			if(onEnable){	
				enableRandom();
			}
		}
		
		public void enableRandom()
		{
			//make sure all gameobjects are turned off first
			for(int i = 0; i < gameObjects.Length; i++){
				gameObjects[i].SetActive(false);
			}
			
			int x = Random.Range(0, gameObjects.Length);
			gameObjects[x].SetActive(true);
		}
		
	}

}