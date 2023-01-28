using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.Utilities
{
	public class TransformUtils
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
	}
}