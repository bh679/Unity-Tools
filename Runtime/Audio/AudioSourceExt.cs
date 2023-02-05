using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace BrennanHatton.UnityTools
{
	public class AudioSourceExt : MonoBehaviour {
		
		public UnityEvent OnPlayFinish;
		
		public AudioSource audioSource;
		bool isPlaying = false;
		
		public bool startAtRandomTime = false;
		
		// Use this for initialization
		void Reset () {
			audioSource = this.GetComponent<AudioSource>();
		}
		
		void OnEnable()
		{
			if(!audioSource)
				audioSource = this.GetComponent<AudioSource>();
			
			if(startAtRandomTime)
				audioSource.time = Random.Range(0, audioSource.clip.length);
		}
		
		
		// Update is called once per frame
		void Update () {
			
			if(audioSource.isPlaying == false && isPlaying)
				OnPlayFinish.Invoke();
			
			isPlaying = audioSource.isPlaying;
			
		}
		
		
		public void VolumeFadeToZeroAndPause(float speed)
		{
			StopAllCoroutines();
			StartCoroutine(_VolumeFadeToZeroAndPause(speed));
		}
		IEnumerator _VolumeFadeToZeroAndPause(float speed)
		{
			
			float volume = 
				audioSource.volume;
			
			while(volume > 0)
			{
				volume = volume - Time.deltaTime*speed;
				audioSource.volume = volume;
				yield return new WaitForSeconds(Time.deltaTime);
				
			}
			
			audioSource.volume = 0;
			audioSource.Pause();
			isPlaying = false;
			yield return null;
		}
		
		
		public void VolumeFadeToTarget(float time, float target)
		{
			if(target > audioSource.volume)
				VolumeDecreaseToTarget(time, target);
			else if(target < audioSource.volume)
				VolumeIncreaseToTarget(time, target);
		}
		
		
		public void VolumeFadeToZero(float time)
		{
			VolumeDecreaseToTarget(time, 0);
		}
		
		
		public void VolumeDecreaseToTarget(float time, float target)
		{
			StopAllCoroutines();
			StartCoroutine(volumeDecreaseToTarget(time, target));
		}
		
		IEnumerator volumeDecreaseToTarget(float time, float target)
		{
			Debug.Log(Time.time);
			float volume = 
				audioSource.volume;
			float distance = volume - target;
			while(volume > target)
			{
				//Debug.Log("volume -= (Time.deltaTime/time)/distance");
				//Debug.Log(volume + " -= ("+Time.deltaTime+"/"+time+")/"+distance+";"	);
				volume -= distance/(time*10f);
				audioSource.volume = volume;
				yield return new WaitForSeconds(0.1f);
				
			}
			
			audioSource.volume = target;
			Debug.Log(Time.time);
			
			yield return null;
		}
		
		
		public void VolumeFadeToFull(float time)
		{
			VolumeIncreaseToTarget(time, 1f);
		}
		
		
		public void VolumeIncreaseToTarget(float time, float target)
		{
			StopAllCoroutines();
			StartCoroutine(volumeIncreaseToTarget(time, target));
		}
		
		IEnumerator volumeIncreaseToTarget(float time, float target)
		{
			
			float volume = 
				audioSource.volume;
			
			float distance = target - volume;
			while(volume < target)
			{
				volume = volume + distance/(time*10f);
				//volume = volume + Time.deltaTime/speed;
				audioSource.volume = volume;
				yield return new WaitForSeconds(0.1f);
				
			}
			
			audioSource.volume = target;
			
			yield return null;
		}
		
		public void PlayIfNotPlaying(AudioClip clip)
		{
			if(audioSource.isPlaying)
				return;
			
			audioSource.PlayOneShot(clip);
		}
	}
}
