#if BNG
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.Events;

public class EventOnVRInputBridge : MonoBehaviour
{
	//	VRUISystem.Instance.
	public UnityEvent onTriggerPress;
	public UnityEvent onTriggerRelease;
	
	bool isPressed = false;

    // Update is called once per frame
    void Update()
	{
		if(InputBridge.Instance.RightTriggerDown || InputBridge.Instance.LeftTriggerDown || Input.GetMouseButtonDown(0))
		{
			if(!isPressed)
				onTriggerPress.Invoke();
	    		isPressed = true;
	    } 
	    
		else if(isPressed)
		{
			onTriggerRelease.Invoke();
			isPressed = false;
		}
		/*
	    if(InputBridge.Instance.RightTrigger == 0 && InputBridge.Instance.LeftTrigger == 0){
	    	isPressed = false;
		}
		*/
    }
}
#endif
