/*
Brennan Hatton
2018ish
Fades images to transparent or opague over time
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BrennanHatton.UnityTools
{

	public class UIImageFade : MonoBehaviour
	{
		public Image image;
		
		public void StartFadeToBlack(float time)
		{
			StartCoroutine(FadeToBlack(time));
		}
		
		IEnumerator FadeToBlack(float time)
		{
			for(int i = 0; i < time*25; i++)
			{
				yield return new WaitForSeconds((time/25f) * Time.deltaTime);
				
				image.color = new Color(0,0,0,i/(time*25));
			}
			image.color = new Color(0,0,0,255);
		}
		
		
		public void StartFadeToOpaque(float time)
		{
			StartCoroutine(FadeToOpaque(time));
		}
		
		IEnumerator FadeToOpaque(float time)
		{
			Color colorTemp = image.color;
			for(int i = 0; i < time*25; i++)
			{
				yield return new WaitForSeconds((time/25f) * Time.deltaTime);
				
				//image.color = new Color(255,255,255,i/(time*25));
				colorTemp = new Color(image.color.r, image.color.g, image.color.b, i/(time*25));
				image.color = colorTemp;
			}
			image.color = new Color(colorTemp.r, colorTemp.g, colorTemp.b, 255);
		}
		
		public void StartFadeToClear(float time)
		{
			StartCoroutine(FadeToClear(time));
		}
		
		IEnumerator FadeToClear(float time)
		{
			Color colorTemp = image.color;
			for(int i = 0; i < time*25; i++)
			{
				yield return new WaitForSeconds((time/25f) * Time.deltaTime);
				
				//image.color = new Color(0,0,0,1-i/(time*25));
				colorTemp = new Color(image.color.r, image.color.g, image.color.b, 1-i/(time*25));
				image.color = colorTemp;
			}
			image.color = new Color(colorTemp.r, colorTemp.g, colorTemp.b, 0);
		}
	}

}
