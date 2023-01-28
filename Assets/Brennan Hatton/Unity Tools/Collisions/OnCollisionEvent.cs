using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class OnCollisionEvent : MonoBehaviour
{
	public List<GameObject> targets= new List<GameObject>();
	public List<GameObject> exclude= new List<GameObject>();
	public LayerMask layer;
	public UnityEvent onCollisionEnterEvent;
	public UnityEvent onCollisionExitEvent;
	public float veolictyRequired = 0;
	public float veolictyRequiredSqr = 0;
	//Rigidbody rb;
	
	
	// Start is called before the first frame update
	void Start()
	{
		if(veolictyRequired != 0 && veolictyRequiredSqr == 0)
		{
			veolictyRequiredSqr = veolictyRequired*veolictyRequired;
			veolictyRequired = 0;
		}
	}

	// Update is called once per frame
	void Update()
	{
        
	}
    
	protected virtual void OnCollisionEnter(Collision col)
	{
		//if(rb == null)
		//	return;
		if(veolictyRequired != 0 && col.relativeVelocity.magnitude < veolictyRequired)
			return;
			
		if(veolictyRequiredSqr != 0 && col.relativeVelocity.sqrMagnitude < veolictyRequiredSqr)
			return;
		
		if(exclude.Contains(col.gameObject))
			return;
		
		if((layer.value & 1<< col.gameObject.layer) != 0
			|| targets.Contains(col.gameObject))
		{
			//Debug.Log(other);
			onCollisionEnterEvent.Invoke();
		}
	}
    
	protected virtual void OnCollisionExit(Collision col)
	{
		if(col.relativeVelocity.magnitude < veolictyRequired)
			return;
		
		if(exclude.Contains(col.gameObject))
			return;
			
		if((layer.value & 1<< col.gameObject.layer) != 0
			|| targets.Contains(col.gameObject))
		{
			//Debug.Log(col.gameObject.name);
			onCollisionExitEvent.Invoke();
		}
	}
	
	/*private void OnCollisionEnter(Collision col)
	{
		
	Debug.Log(col.gameObject.name);
	if((col.gameObject.layer == layer)
	|| targets.Contains(col.gameObject))
	{
	onTriggerEnterEvent.Invoke();
	}
	}*/
}
