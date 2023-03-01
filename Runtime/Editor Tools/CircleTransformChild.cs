/*Brennan Hatton
2022
Arranges child objects in a circle when script is reset in editor.
Gets circle values from CircleVars object
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.UnityTools.EditorTools
{

	[RequireComponent(typeof(CircleVars))]
	public class CircleTransformChild : MonoBehaviour
	{
		
		
		void Reset()
		{
			Transform[] children = transform.GetComponentsInChildren<Transform>();
			CircleVars circleVars;
			
			circleVars = this.GetComponent<CircleVars>();
			
			float radius = circleVars.radius;
			float points = circleVars.points; 
			float degrees = circleVars.degrees* Mathf.Deg2Rad;
			
			for (int i = 0; i < points; i++)
			{
				if(i < children.Length && children[i] == this.transform)
					i++;
				
				float angle = i  *degrees / points;
				Vector3 newPos = new Vector3(Mathf.Cos(angle)*radius, 0, Mathf.Sin(angle)*radius);
				
				if(i < children.Length)
				{
					children[i].transform.localPosition = newPos;
					children[i].transform.LookAt(circleVars.target,Vector3.up);
				}else
				{
					GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
					go.transform.localPosition = newPos;
					go.transform.SetParent(this.transform);
					go.transform.LookAt(circleVars.target,Vector3.up);
				}
			}
			
			if(children.Length > points)
			{
				for(int i  = (int)points; i < children.Length; i++)
				{
					Destroy(children[i].gameObject);
				}
			}
		}
	}

}