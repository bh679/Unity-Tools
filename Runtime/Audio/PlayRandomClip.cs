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
				PlayRandomClipPLz();
		}
		
		int id;
		public void PlayRandomClipPLz()
		{
			id = Random.Range(0,clips.Length);
			play();
			//Debug.Log(clips[id]);
		}
		
		public void playRandomClipVolumeScale(float volumeScale)
		{
			Random.seed = System.DateTime.Today.Second + System.DateTime.Today.Millisecond +System.DateTime.Today.Minute + System.DateTime.Today.Hour + System.DateTime.Today.Date.DayOfYear;
			int id = Random.Range(0,clips.Length);
			play(volumeScale);
			//Debug.Log(clips[id]);
		}
		
		void play(float volumeScale = -1)
		{
			if(playOnShot)
				source.PlayOneShot(clips[id],volumeScale>=0?volumeScale:1);
			else
			{
				source.clip = clips[id];
				if(volumeScale >= 0)
					source.volume = volumeScale;
				source.Play();
			}
		}
		
		public void PlayNextClip()
		{
			if(onlyIfNotPlayer && source.isPlaying)
				return;
				
			id++;
			play();
		}
		
		public void PlayRandomClipChance(int oneIn)
		{
			if(Random.Range(0,oneIn) == 0)
			{
				PlayRandomClipPLz();
			}
		}
		
	    // Start is called before the first frame update
	    void Start()
		{
	    	
		    if(onStart)
			    PlayRandomClipPLz();
		    
	    }
	
	    // Update is called once per frame
	    void Update()
	    {
	        
	    }
	}

}
