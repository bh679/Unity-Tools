/*
Roy Dadivas
Equal Reality

--What Roy had to say about imageHint.cs
Controller script for a hint prefab (containing an image)
it's clunky, sometimes getting errors
I haven't used this in so long. better to just use UIImageFade.cs
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BrennanHatton.UnityTools.LegacyUI;

namespace BrennanHatton.UnityTools
{


	[RequireComponent(typeof(UITextFade))]
	public class textHint : MonoBehaviour
	{
		public bool appearOnStart = true;
		public bool hasDuration = true;
		public float duration = 5f;
		
		UITextFade textFade;
	    
	    void Start()
	    {
		    textFade = GetComponent<UITextFade>();
		    if(textFade.text == null)
		    {
		    	Debug.Log("UITextFade's text value is empty!");
		    	return;
		    }
		    
		    if(appearOnStart){
		    	appear();
		    }
	    }
	
		public void appear(){
			textFade.StartAppear(2);
			
			if(hasDuration){
				StartCoroutine(disappearTimer());
			}
		}
		
		IEnumerator disappearTimer()
		{
			yield return new WaitForSeconds(duration);
			disappear();
		}
		
		public void disappear(){
			textFade.StartDisappear(2);
		}
	}
}