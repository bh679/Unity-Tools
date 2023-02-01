using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BrennanHatton.UnityTools
{
	
	public class EventAfterAudioFinishes : MonoBehaviour
	{
		
		public UnityEvent onFinish = new UnityEvent();
	    
		public void RunWhenFinished(AudioSource audioSource)
		{
			//Debug.Log("RunWhenFinished");
			StartCoroutine(runWhenFinished(audioSource));
		}
		
		IEnumerator runWhenFinished(AudioSource audioSource)
		{
			//Debug.Log("runWhenFinished");
			//float time = 0;
			while(audioSource.isPlaying)
			{
				yield return new WaitForEndOfFrame();
				
				/*if(time > 120)
				{
					Debug.Log("Waiting for autio");
					time = 0;
				}
				time++;*/

			}
			//Debug.Log("onFinishInvoke");
			
			onFinish.Invoke();
			
			yield return null;
		}
	}
	
}