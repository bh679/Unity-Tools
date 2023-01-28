using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.UnityTools
{
	public static class TransformTools
	{
		public static string HierarchyPath(Transform transform, int limit = 500)
		{
			if (transform == transform.root || limit < 0)
				return "";
			return HierarchyPath(transform.parent, limit - 1) + "/" + transform.name;
		}
		
		public static bool HasObjectInParents(Transform transform, Transform parent, int limit = 10)
		{
			if (transform == parent)
				return true;
			else if (transform == transform.root || limit < 0)
				return false; 
				
			return HasObjectInParents(transform.parent, parent, limit - 1);// + "/" + transform.name;
		}
		
		public static void MoveToParentUp(Transform transform, int numberOfParentsToMove)
		{
			for(int i = 0; i < numberOfParentsToMove; i++)
			{
				if(transform.parent != transform.root)
					transform.SetParent(transform.parent.parent);
			}
		}
		
		
		//Breadth-first search
		public static Transform FindDeepChild(this Transform aParent, string aName)
		{
			Queue<Transform> queue = new Queue<Transform>();
			queue.Enqueue(aParent);
			while (queue.Count > 0)
			{
				var c = queue.Dequeue();
				if (c.name == aName)
					return c;
				foreach(Transform t in c)
					queue.Enqueue(t);
			}
			return null;
		} 
		
		
		public static Matrix4x4 ParentMatrix(Transform parent)
		{
			return Matrix4x4.TRS(parent.position, parent.rotation, parent.lossyScale);
		}
	     
		public static Vector3 ChildPosition(Matrix4x4 parentMatrix, Vector3 childPosition)
		{
			return parentMatrix.MultiplyPoint3x4(childPosition);
		}
	     
		public static Quaternion ChildRotation(Quaternion parentRotation, Quaternion childRotation)
		{
			return (parentRotation * childRotation);
		}
	}
}