//Roy Dadivas
//Animates a circle timer UI
//2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace BrennanHatton.UnityTools
{
	
	public class CircleTimerUI : MonoBehaviour
	{
		public float duration;
		public Image fillImage;
		public Text text;
		public bool onEnable = true;
		
		public UnityEvent onFinish;
		
	    // Start is called before the first frame update
		void OnEnable()
		{
			if(!onEnable)
				return;
			RunTimer();
		}
	    
		//Fills the cirlce and starts the timer
		public void RunTimer()
		{
				
			fillImage.fillAmount = 1f;
		    
			StartCoroutine(timer(duration));
		}
	
	    // Update is called once per frame
		IEnumerator timer(float duration)
		{
			float startTime = Time.time;
			float time = duration;
			float value = 0f;
			
			while(Time.time - startTime < duration)
			{
				time -= Time.deltaTime;
				value = time / duration;
				fillImage.fillAmount = value;
				if(text != null)
					text.text = ((int)time).ToString();
				yield return null;
			}
			onFinish.Invoke();
		}
	}

}