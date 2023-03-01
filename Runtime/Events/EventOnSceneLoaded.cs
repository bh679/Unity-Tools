/*
Brennan Hatton
2023-03-01
Calls Unity event on laod of scene
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace BrennanHatton.UnityTools
{

	[System.Serializable]
	public class SceneEvent
	{
		public string eventId;
		public UnityEvent onSceneLoaded;
		
		public void Invoke()
		{
			onSceneLoaded.Invoke();
		}
	}
	
	public class EventOnSceneLoaded : MonoBehaviour
	{
		public SceneEvent onSceneLoaded;
		static List<SceneEvent> events = new List<SceneEvent>();
		static bool addedToSceneLoad;
		
		void Awake()
		{
			if(!IdIsInEvents(onSceneLoaded.eventId))
			{
				events.Add(onSceneLoaded);
			}
			
			if(!addedToSceneLoad)
			{
				SceneManager.sceneLoaded += OnSceneLoaded;
				addedToSceneLoad = true;
			}
		}
		
		static bool IdIsInEvents(string id)
		{
			for(int i = 0; i < events.Count; i++)
			{
				if(events[i].eventId == id)
					return false;
			}
			
			return true;
		}
		
		static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			for(int i = 0; i < events.Count; i++)
			{
				events[i].Invoke();
			}
		}
	}

}
