using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace EqualReality.Utilities
{
	public static class UnityObjectUtils {

		public static void DestroyAppropriately(this Component obj)
		{
#if UNITY_EDITOR
			if (!Application.isPlaying)
			{
				UnityEditor.EditorApplication.delayCall+=()=>
				{
					if (obj == null) return;
					Object.DestroyImmediate(obj.gameObject);
				};
				return;
			}
#endif
			if (obj == null) return;
			Object.Destroy(obj.gameObject);
		}

		/// <summary>
		/// The Actual value of the object (checking for null)
		/// This allows the value to be used in null conditional or coalescing operators
		/// </summary>
		/// <param name="obj"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static T ac<T>(this T obj)
		where T : class
		{
			return obj == null ? null : obj;
		}
		
		public static T GetComponentInAncestors<T>(this Component owner)
		where T:class
		{
			for (var p = owner.transform.parent; p != null; p = p.parent)
			{
				T ret = p.GetComponent<T>();
				if (ret != null)
				{
					return ret;
				}
			}

			return null;
		}
		
		public static Component GetComponentInAncestors(this Component owner, Type type)
		{
			for (var p = owner.transform.parent; p != null; p = p.parent)
			{
				var ret = p.GetComponent(type);
				if (ret != null)
				{
					return ret;
				}
			}

			return null;
		}
		
		/// <summary>
		/// Recursively sets GameObject's layer to newLayer
		/// </summary>
		/// <param name="newLayer">The new layer</param>
		/// <param name="trans">Start transform</param>
		public static void SetLayer(int newLayer, Transform trans)
		{
			trans.gameObject.layer = newLayer;
			foreach (Transform child in trans)
			{
				child.gameObject.layer = newLayer;
				if (child.childCount > 0)
				{
					SetLayer(newLayer, child.transform);
				}
			}
		}
	}
}
