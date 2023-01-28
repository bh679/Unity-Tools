using System.Collections;
using UnityEngine;
using UnityEngine.Events;

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
	
	
	public void VolumeFadeToZero(float speed)
	{
		StartCoroutine(_VolumeFadeToZero(speed));
	}
	IEnumerator _VolumeFadeToZero(float speed)
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
		
		yield return null;
	}
	
	
	public void VolumeFadeToFull(float speed)
	{
		StartCoroutine(_VolumeFadeToFull(speed));
	}
	
	IEnumerator _VolumeFadeToFull(float speed)
	{
		
		float volume = 
			audioSource.volume;
		
		while(volume < 1)
		{
			volume = volume + Time.deltaTime*speed;
			audioSource.volume = volume;
			yield return new WaitForSeconds(Time.deltaTime);
			
		}
		
		audioSource.volume = 1;
		
		yield return null;
	}
	
	public void PlayIfNotPlaying(AudioClip clip)
	{
		if(audioSource.isPlaying)
			return;
		
		audioSource.PlayOneShot(clip);
	}
}
