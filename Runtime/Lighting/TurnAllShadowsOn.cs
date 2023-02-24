/*
Brennan Hatton
2021
Turns ON all Shadows off in children when component is added
For use in editor only

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.UnityTools.EditorTools
{
		
	public class TurnAllShadowsOn : MonoBehaviour
	{
		void Reset()
		{
			TurnOn();
		}
		
		
		public void TurnOn()
		{
			MeshRenderer[] renderers = this.GetComponentsInChildren<MeshRenderer>();
			for(int i = 0; i < renderers.Length; i++)
			{
				renderers[i].shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
			}
			
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