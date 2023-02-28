/*
Brennan Hatton
2022
A instantiona management class, for tracking items to be instantiated and limiting number of items instantiated per frame
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.UnityTools
{
	
	public class InstantiateList : MonoBehaviour
	{
		int id = 0, line = 0;
		[Tooltip("Number of objects to create per frame")]
		public int speed = 5;
		
		public void Clear()
		{
			line = id;
		}
		
		public static InstantiateList Instance { get; private set; }
		private void Awake() 
		{ 
			// If there is an instance, and it's not me, delete myself.
	    
			if (Instance != null && Instance != this) 
			{ 
				Destroy(this); 
			} 
			else 
			{ 
				Instance = this; 
			} 
		}
		
		public int GetLine()
		{
			int retVal = line;
			line++;
			return retVal;
		}
		
		public bool IsMyTurn(int check)
		{
			if(id >= check)
			{
				if(id == check)
					StartCoroutine(next());
				return true;
			}
			return false;
		}
		
		IEnumerator next()
		{
			yield return new WaitForEndOfFrame();
			id += speed;
			yield return null;
		}
	}
}
