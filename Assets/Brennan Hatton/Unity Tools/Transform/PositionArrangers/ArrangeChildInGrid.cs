#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Vector3Component))]
public class ArrangeChildInGrid : MonoBehaviour
{
	void Reset()
	{
		if(Application.isPlaying)
			return;
		
		Vector3Component vector3Component = this.GetComponent<Vector3Component>();
		if(vector3Component.vector3Value == Vector3.zero)
		{
			vector3Component.vector3Value = new Vector3(1,0,1);
		}
		
		int rows = (int)Mathf.Sqrt(transform.childCount);
		
		if(vector3Component.vector3Value.z == 0)
			rows = transform.childCount;
		
		int x = 0,z = -1;
		for(int i = 0 ;i < transform.childCount; i++)
		{
			x = i % rows;
			
			if(x == 0)
				z++;
			
			transform.GetChild(i).localPosition=  new Vector3(x*vector3Component.vector3Value.x,vector3Component.vector3Value.y,z*vector3Component.vector3Value.z);
		}
	}
	
}
#endif