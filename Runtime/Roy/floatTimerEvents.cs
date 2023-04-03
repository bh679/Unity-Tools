using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class floatTimerEvents : MonoBehaviour
{
	
	public floatTimer timer;
	
	public float comparisonValue;
	
	public UnityEvent onGreaterThan;
	public UnityEvent onLessThan;
	
	public void checkValue()
	{
		if(timer.time < comparisonValue)
			onLessThan.Invoke();
		else
			onGreaterThan.Invoke();
	}
}
