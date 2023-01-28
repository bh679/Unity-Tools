using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyRandomRotation : MonoBehaviour
{
	
	public RotateAroundAxis rotator;
	public bool onEnable = false;
	public bool mulitplier = false;
	
	void Reset()
	{
		rotator = this.GetComponent<RotateAroundAxis>();
		
		if(!rotator)
		{
			rotator = this.gameObject.AddComponent<RotateAroundAxis>();
			rotator.axis = Vector3.up;
			rotator.speed = 360;
			rotator.onUpdate = false;
			onEnable = true;
		}
	}
	
	void OnEnable()
	{
		if(onEnable)
		{
			if(mulitplier)
				RotateByRandomMuliplier(rotator.speed);
			else
				RotateZeroToFloat(rotator.speed);
		}
	}
	// Start is called before the first frame update
	public void RotateByRandomMuliplier(float fvalue)
	{
		fvalue = ((int)Random.RandomRange(0,360))*fvalue;
		
		rotator.RotateDegrees(fvalue);
	}
	
    // Start is called before the first frame update
	public void RotateZeroToFloat(float fvalue)
	{
		fvalue = Random.RandomRange(0,fvalue);
		
		rotator.RotateDegrees(fvalue);
	}
}
