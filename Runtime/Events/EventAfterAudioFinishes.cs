using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BrennanHatton.UnityTools
{
	
	public class EventAfterAudioFinishes : MonoBehaviour
	{
		
		public UnityEvent onFinish = new UnityEvent();
		public UnityEvent onStart = new UnityEvent();
		public UnityEvent isAlreadyTalking_notContinuous = new UnityEvent();
	
		public bool continuous = false;
	    
		public void RunWhenFinished(AudioSource audioSource)
		{
			StartCoroutine(runWhenFinished(audioSource));
		}
		
		IEnumerator runWhenFinished(AudioSource audioSource)
		{
			bool started = audioSource.isPlaying;
			
			if(started)
				isAlreadyTalking_notContinuous.Invoke();
			
			while(continuous)
			{
				
				while(audioSource.isPlaying)
				{
					yield return new WaitForEndOfFrame();
				}
				
				if(started)
					onFinish.Invoke();
				
				while(!audioSource.isPlaying)
				{
					yield return new WaitForEndOfFrame();

				}
				onStart.Invoke();
				
			}
			
			
			while(audioSource.isPlaying)
			{
				yield return new WaitForEndOfFrame();

			}
			
			onFinish.Invoke();
			
				
			while(!audioSource.isPlaying)
			{
				yield return new WaitForEndOfFrame();

			}
			onStart.Invoke();
			
			yield return null;
		}
	}
	
}