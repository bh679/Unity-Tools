#if BNG
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class ActiveOnHandedness : MonoBehaviour
{
	public Grabbable grabbable;
	
	public GameObject Left, Right;
	
    // Start is called before the first frame update
    void Start()
    {
	    
    }

	bool wasHeld = false;
    // Update is called once per frame
    void Update()
    {
	    if(grabbable.BeingHeld && !wasHeld)
	    {
    		if(grabbable.GetPrimaryGrabber().HandSide == ControllerHand.Left)
    		{
    			Left.SetActive(true);
    			Right.SetActive(false);
    		}else
    		{
    			Left.SetActive(false);
		    	Right.SetActive(true);
    		}
	    }
	    
		    wasHeld = grabbable.BeingHeld;
    }
}
#endif
