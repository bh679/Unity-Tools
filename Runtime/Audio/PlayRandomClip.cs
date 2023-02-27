using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.UnityTools
{

	public class PlayRandomClip : MonoBehaviour
	{
		public bool PlayOnEnable = false;
		public bool onStart = false;
		public bool onlyIfNotPlayer = false;
		
		public AudioClip[] clips;
		public AudioSource source;
		
		void Reset()
		{
			source = this.GetComponent<AudioSource>();
		}
		
		
		void OnEnable()
		{
			if(PlayOnEnable)
				playRandomClip();
		}
		
		int id;
		public void playRandomClip()
		{
			id = Random.Range(0,clips.Length);
			Play();
			//Debug.Log(clips[id]);
		}
		
		public void playRandomClipVolumeScale(float volumeScale)
		{
			Random.seed = System.DateTime.Today.Second + System.DateTime.Today.Millisecond +System.DateTime.Today.Minute + System.DateTime.Today.Hour + System.DateTime.Today.Date.DayOfYear;
			int id = Random.Range(0,clips.Length);
			Play(volumeScale);
			//Debug.Log(clips[id]);
		}
		
		void Play(float volumeScale = 1)
		{
			source.PlayOneShot(clips[id],volumeScale);
		}
		
		
	    // Start is called before the first frame update
	    void Start()
		{
			if(onlyIfNotPlayer && source.isPlaying)
				return;
	    	
		    if(onStart)
			    source.PlayOneShot(clips[id]);
		    
	    }
		
		public void PlayNextClip()
		{
			id++;
			Play();
		}
	}

}
