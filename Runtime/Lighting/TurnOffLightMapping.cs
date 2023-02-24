/*
Brennan Hatton
2021
Turns off lightmapping in children when component is added
For use in editor only

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BrennanHatton.UnityTools.EditorTools
{
	
	
	public class TurnOffLightMapping : MonoBehaviour
	{	void Reset()
		{
			TurnOn();
		}
		
		
		public void TurnOn()
		{
	#if UNITY_EDITOR
			MeshRenderer[] renderers = this.GetComponentsInChildren<MeshRenderer>();
			for(int i = 0; i < renderers.Length; i++)
			{
				SerializedObject so = new SerializedObject (renderers[i]);
				so.FindProperty("m_ScaleInLightmap").floatValue = 0;
				so.ApplyModifiedProperties();
			}
			
	#endif
		}
	}

}