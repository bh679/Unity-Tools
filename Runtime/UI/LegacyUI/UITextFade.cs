using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BrennanHatton.UnityTools.LegacyUI
{

	public class UITextFade : MonoBehaviour
	{
		public Text text;
		
		Color textColor;
		
		void Start()
		{
			textColor = text.color;
		}
		
		public void StartAppear(float time)
		{
			if(text.isActiveAndEnabled)
				StartCoroutine(Appear(time));
		}
		
		IEnumerator Appear(float time)
		{
			for(int i = 0; i < time*26; i++)
			{
				yield return new WaitForSeconds((time/25f) * Time.deltaTime);
				
				text.color = new Color(textColor.r,textColor.g,textColor.b,i/(time*26));
			}
			text.color = new Color(textColor.r,textColor.g,textColor.b,255);
		}
		
		public void StartDisappear(float time)
		{
			if(text.isActiveAndEnabled)
				StartCoroutine(Disappear(time));
		}
		
		IEnumerator Disappear(float time)
		{
			for(int i = 0; i < time*26; i++)
			{
				yield return new WaitForSeconds((time/25f) * Time.deltaTime);
				
				text.color = new Color(textColor.r,textColor.g,textColor.b,1-i/(time*26));
			}
			text.color = new Color(textColor.r,textColor.g,textColor.b,0);
		}
	}

}