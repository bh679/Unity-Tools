using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BrennanHatton.Audio
{
	public class AudioList : MonoBehaviour
	{
		
		public List<AudioClip> audioClips = new List<AudioClip>();
		public AudioSource source;
		
		public void PlayClip(int id)
		{
			if(!source.isPlaying)
				source.PlayOneShot(audioClips[id]);
		}
	}
}