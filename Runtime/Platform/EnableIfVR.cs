using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class EnableIfVR : MonoBehaviour
{
	public GameObject[] VrGameObjects, nonVrGameObjects;
	
    // Start is called before the first frame update
    void Start()
	{
		UpdateEnabled();
    }

	void UpdateEnabled()
    {
        
    	
	    for(int i = 0; i < VrGameObjects.Length; i++)
		    VrGameObjects[i].SetActive(isPresent());
    	
	    for(int i = 0; i < nonVrGameObjects.Length; i++)
		    nonVrGameObjects[i].SetActive(!isPresent());
    }
    
	public static bool isPresent()
	{
		var xrDisplaySubsystems = new List<XRDisplaySubsystem>();
		SubsystemManager.GetInstances<XRDisplaySubsystem>(xrDisplaySubsystems);
		foreach (var xrDisplay in xrDisplaySubsystems)
		{
			if (xrDisplay.running)
			{
				return true;
			}
		}
		return false;
	}
}
