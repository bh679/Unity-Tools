using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BrennanHatton.UnityTools
{
	public delegate TransformData TransformDataDelegate(GameObject trans);
	
	public class TransformData{
		Vector3 position, localPosition, localScale;
		Quaternion rotation, localRotation;
		Transform parent;
		
		public TransformData(Vector3 _position, Vector3 _rotation)
		{
			position = _position;
			localScale = Vector3.one;
			rotation.SetEulerAngles(_rotation);
		}
		
		public TransformData(Transform transform)
		{
			//local data
			localPosition = transform.localPosition;
			localScale = transform.localScale;
			localRotation = transform.localRotation;
			
			//global data
			position = transform.position;
			rotation = transform.rotation;
			
			//parent
			parent = transform.parent;
		}
		
		public TransformData(Transform transform, Transform newParent)
		{
			//local data
			localPosition = transform.localPosition;
			localScale = transform.localScale;
			localRotation = transform.localRotation;
			
			//global data
			position = transform.position;
			rotation = transform.rotation;
			
			//parent
			parent = newParent;
		}
		
		public void ApplyLocalData(Transform transform, bool includeParent)
		{
			if(includeParent)
			{
				transform.SetParent(parent);
			}
			
			transform.localPosition = localPosition;
			transform.localScale = localScale;
			transform.localRotation = localRotation;
		}
		
		public void ApplyGlobalData(Transform transform, bool includeParent)
		{
			transform.position = position;
			transform.rotation = rotation;
			
			if(includeParent)
			{
				transform.SetParent(parent);
			}
		}
		
		public void SetParent(Transform newParent)
		{
			parent = newParent;
		}
		
		public string ToDebugString()
		{
			return "position "+(position==null?"":position) + "\nlocalPosition: "+ (localPosition==null?"":localPosition) + "\nlocalScale: "+ (localScale==null?"":localScale) + "\nrotation: "+ (rotation==null?"":rotation) + "\nlocalRotation: "+(localRotation==null?"":localRotation) + "\nparent: "+(parent==null?"":parent.name);
		}
	}
}