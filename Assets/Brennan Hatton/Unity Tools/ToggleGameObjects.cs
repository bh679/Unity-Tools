using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleGameObjects : MonoBehaviour
{
	public GameObject[] gameObjects, invertedGameObjects;
	
	bool isOn = true;
	
	public void TogglePlz()
	{
		isOn = !isOn;
		
		for( int  i = 0; i < gameObjects.Length; i++)
			gameObjects[i].SetActive(isOn);
			
		for( int  i = 0; i < invertedGameObjects.Length; i++)
			invertedGameObjects[i].SetActive(!isOn);
	}
	
	public void TogglePlz(Toggle toggle)
	{
		for( int  i = 0; i < gameObjects.Length; i++)
			gameObjects[i].SetActive(toggle.isOn);
			
		for( int  i = 0; i < invertedGameObjects.Length; i++)
			invertedGameObjects[i].SetActive(!toggle.isOn);
	}
	
}
