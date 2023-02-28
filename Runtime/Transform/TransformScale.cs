//Brennan Hatton
//2020ish
//This scrip could probable me merged into TransformTools

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.UnityTools
{

	public class TransformScale : MonoBehaviour
	{
		public Vector2 randomScale;
		
		public bool onEnable = false;
		
		public bool uniform = true;
		
		void OnEnable()
		{
			if(onEnable)
			{
				if(uniform)
					TransformSetRandomUniformScale();
				else
					TransformSetRandomUniformScale();
			}
		}
	    
		public void ScaleAllRandom()
		{
			Vector3 newScale = this.transform.localScale.normalized;
			
			newScale.x *= Random.Range(randomScale.x,randomScale.y);
			newScale.y *= Random.Range(randomScale.x,randomScale.y);
			newScale.z *= Random.Range(randomScale.x,randomScale.y);
			
			this.transform.localScale = newScale;
		}
	    
		public void TransformSetUniformScale(float scale)
		{
			this.transform.localScale = this.transform.localScale.normalized*scale;
		}
	    
		public void TransformSetRandomUniformScale()
		{
			float scale = Random.Range(randomScale.x,randomScale.y);
			
			TransformSetUniformScale(scale);
		}
		
		public void ScaleToZero(float time)
		{
			StartCoroutine(scaleToZero(time));
		}
		
		IEnumerator scaleToZero(float time)
		{
			Vector3 startScale = transform.localScale;
			for(int i = 0; i < time*25; i++)
			{
				yield return new WaitForSeconds((time/25f) * Time.deltaTime);
				
				transform.localScale = startScale*(1-i/(time*25));
			}
		}
	}

}