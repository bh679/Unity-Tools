/*
Roy Dadvias
Equal Reality

Controller script for a hint prefab (containing an image)
it's clunky, sometimes getting errors
I haven't used this in so long. better to just use UIImageFade.cs

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.UnityTools
{

	
	[RequireComponent(typeof(UIImageFade))]
	public class imageHint : MonoBehaviour
	{
		public bool appearOnStart = true;
		public bool hasDuration = true;
		public float duration = 5f;
		
		UIImageFade imageFade;
	    
		void Start()
		{
			imageFade = GetComponent<UIImageFade>();
			if(imageFade.image == null)
			{
				Debug.Log("UITextFade's text value is empty!");
				return;
			}
		    
			if(appearOnStart){
				appear();
			}
		}
	
		public void appear(){
			imageFade.StartFadeToOpaque(2);
			
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
			imageFade.StartFadeToClear(2);
		}
	}

}