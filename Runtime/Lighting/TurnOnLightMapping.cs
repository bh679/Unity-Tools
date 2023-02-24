/*
Brennan Hatton
2021
Turns ON lightmapping in children when component is added
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
		
	public class TurnOnLightMapping : MonoBehaviour
	{
		void Reset()
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
				so.FindProperty("m_ScaleInLightmap").floatValue = 1;
				so.ApplyModifiedProperties();
			}
			
	#endif
		}
	    // Start is called before the first frame update
	    void Start()
	    {
	        
	    }
	
	    // Update is called once per frame
	    void Update()
	    {
	        
	    }
	}
}