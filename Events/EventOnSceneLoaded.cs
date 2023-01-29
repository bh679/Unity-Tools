using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace BrennanHatton.UnityTools
{

	public class EventOnSceneLoaded : MonoBehaviour
	{
		public UnityEvent onSceneLoaded;
		
		void Awake()
		{
			SceneManager.sceneLoaded += OnSceneLoaded;
		}
		
		void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			onSceneLoaded.Invoke();
		}
	}
}