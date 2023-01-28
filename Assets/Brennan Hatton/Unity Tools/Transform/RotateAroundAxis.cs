using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RotateAroundAxis : MonoBehaviour
{
	public Transform target;
	public Vector3 axis;
	public float speed;
	public bool local = false;
	public bool onUpdate = true;
	
	#if UNITY_EDITOR
	public bool runInEditor = false;
	#endif
	
	void Reset()
	{
		target = this.transform;
	}
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
	{
		#if UNITY_EDITOR
		if(!runInEditor && !Application.isPlaying)
			return;
		#endif
		
		if(onUpdate)
			Rotate(speed);
	}
	
	public void Rotate()
	{
		Rotate(speed);
	}
    
	public void Rotate(float _speed)
	{
		if(local)
			target.transform.RotateAroundLocal(axis,_speed*Time.deltaTime);
		else
			target.transform.RotateAround(axis,_speed*Time.deltaTime);
	}
    
	public void RotateDegrees(float degree)
	{
		if(local)
			target.transform.RotateAroundLocal(axis,Mathf.Deg2Rad*degree);
		else
			target.transform.RotateAround(axis,Mathf.Deg2Rad*degree);
	}
	
	public void SetRotation()
	{
		if(local)
			target.transform.localEulerAngles = axis * speed; 
		else
			target.transform.eulerAngles = axis * speed; 
	}

	public void SetSpeed(float newSpeed)
	{
		speed = newSpeed;
	}

}
