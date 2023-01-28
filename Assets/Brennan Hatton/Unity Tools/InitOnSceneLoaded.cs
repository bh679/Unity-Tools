using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class InitOnSceneLoaded : MonoBehaviour
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
