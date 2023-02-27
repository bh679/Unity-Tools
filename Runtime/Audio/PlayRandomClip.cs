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
		public bool playOnShot = true;
		
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
			if(playOnShot)
				source.PlayOneShot(clips[id],volumeScale);
			else
			{
				source.clip=clips[id];
				source.volume = volumeScale;
				source.Play();
			}
		}
		
		public void PlayNextClip()
		{
			if(onlyIfNotPlayer && source.isPlaying)
				return;
				
			id++;
			Play();
		}
		
		
	    // Start is called before the first frame update
	    void Start()
		{
	    	
		    if(onStart)
			    source.PlayOneShot(clips[id]);
		    
	    }
	}

}
