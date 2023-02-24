using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.UnityTools
{
	
	public class MaterialColorBlender : MonoBehaviour
	{
		public Renderer renderer;
		public Color defaultColor;
		
		void Reset()
		{
			renderer = this.GetComponentInChildren<Renderer>();
			defaultColor = renderer.material.color;
		}
	    
		public void SetRedAndFadeBackSeconds(float seconds)
		{
			if(renderer == null)
				return;
				
			StartCoroutine(iBlendColorOverTime(Color.red, defaultColor, seconds));
		}
		
		public void SetRedAndFadeBack1Sec()
		{
			if(renderer == null)
				return;
				
			StartCoroutine(iBlendColorOverTime(Color.red, defaultColor, 1));
		}
		
		public void SetColorAndFadeBack1Sec(Color target)
		{
			if(renderer == null)
				return;
				
			StartCoroutine(iBlendColorOverTime(target, renderer.material.color, 1));
		}
		
		public void FadeBack(float time)
		{
			if(renderer == null)
				return;
				
			StartCoroutine(iBlendColorOverTime(defaultColor, renderer.material.color, time));
		}
		
		public void SetColorAndFadeBack(Color target, float time)
		{
			if(renderer == null)
				return;
				
			StartCoroutine(iBlendColorOverTime(target, renderer.material.color, time));
		}
		
		public void BlendColorOverTime(Color target, float time)
		{
			if(renderer == null)
				return;
				
			StartCoroutine(iBlendColorOverTime(renderer.material.color,target,time));
		}
		
		IEnumerator iBlendColorOverTime(Color colorStart, Color colorEnd, float time)
		{
			float blendFrames = time/Time.deltaTime;
			
			for(float i = 0; i < blendFrames; i++)
			{
				renderer.material.color = Color.Lerp(colorStart,colorEnd,i/blendFrames);
				
				yield return new WaitForEndOfFrame();
			}
		}
	}
}