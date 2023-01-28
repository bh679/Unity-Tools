using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyTransform : MonoBehaviour
{
	public Transform target;
	
	public bool position = true, rotation = false;
	
	public bool rx = true, ry = true, rz = true;
	
	public bool OnLateUpdate = false;
	
	public bool OnUpdate = true;
	
	public bool Local = false;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

	// Update is called once per frame
	void Update()
	{
		if(OnUpdate)
			CopyExistingTarget();
	}
	
	void LateUpdate()
	{
		if(OnLateUpdate)
			CopyExistingTarget();
	}
    
	public void CopyExistingTarget()
	{
		CopyFromTransform(target);
	}
	
	public void CopyFromTransform(Transform _target)
	{
		if(position)
		{
			if(Local)
				this.transform.localPosition = _target.transform.localPosition;
			else
				this.transform.position = _target.transform.position;
		}
			
		if(rotation)
		{
			if(Local)
			{
				if(rx & ry & rz)
					this.transform.localRotation = _target.transform.localRotation;
				else
				{
					Vector3 eulerAngles = this.transform.localEulerAngles;
				
					if(rx)
						eulerAngles.x = _target.transform.localEulerAngles.x;
					if(ry)
						eulerAngles.y = _target.transform.localEulerAngles.y;
					if(rz)
						eulerAngles.z = _target.transform.localEulerAngles.z;
				
				
					this.transform.localEulerAngles = eulerAngles;
				}
			}
			else
			{
				if(rx & ry & rz)
					this.transform.rotation = _target.transform.rotation;
				else
				{
					Vector3 eulerAngles = this.transform.eulerAngles;
					
					if(rx)
						eulerAngles.x = _target.transform.eulerAngles.x;
					if(ry)
						eulerAngles.y = _target.transform.eulerAngles.y;
					if(rz)
						eulerAngles.z = _target.transform.eulerAngles.z;
					
					
					this.transform.eulerAngles = eulerAngles;
				}
			}
		}
	}
	
	public void CopyPosition(Vector3 position)
	{
		this.transform.position = position;
	}
	
	public void RunOnUpdate(bool enabled)
	{
		OnUpdate = enabled;
	}
	
}
