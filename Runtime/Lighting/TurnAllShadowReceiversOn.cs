/*
Brennan Hatton
2021
Turns on all Shadow Receievers in children when component is added
For use in editor only

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.UnityTools.EditorTools
{
	
	public class TurnAllShadowReceiversOn : MonoBehaviour
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
				renderers[i].receiveShadows = true;
			}
			
		}
	}
}