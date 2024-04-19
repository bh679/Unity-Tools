using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class AudioTextList : MonoBehaviour
{
	[System.Serializable]
	public class AudioData
	{
		public float delay = 1;
		public AudioClip clip;
		public string text;
		public UnityEvent eventOnStart;
	}
	
	public List<AudioData> audioList = new List<AudioData>();
	
	public AudioSource source;
	public TMP_Text TMPTextFeild;
	
	public bool PlayOnEnable = true;
	
	int nextId = 0;
	public void PlayNext()
	{
		source.PlayOneShot(audioList[nextId].clip);
		audioList[nextId].eventOnStart.Invoke();
		
		nextId++;
		
		if(nextId >= audioList.Count)
			nextId = 0;
	}
	
	void Reset()
	{
		source = this.GetComponentInChildren<AudioSource>();
	}
	
	void OnEnable()
	{
		if(PlayOnEnable)
		{
			StartAudioList();
		}
	}
	
	public void StartAudioList()
	{
		StartCoroutine(runAudioList());
	}
	
	//skips to the last action of the list and plays it
	public void SkipToEnd()
	{
		StopAllCoroutines();
		audioList[audioList.Count - 1].eventOnStart.Invoke();
	}
	
	IEnumerator runAudioList()
	{
		for(int i = 0; i < audioList.Count; i++)
		{
			
			yield return new WaitForSeconds(audioList[i].delay);
			
			audioList[i].eventOnStart.Invoke();
			
			if(TMPTextFeild != null)
			{
				TMPTextFeild.text = audioList[i].text;
			}
			
			if(audioList[i].clip != null)
			{
				source.PlayOneShot(audioList[i].clip);
				
				yield return new WaitForSeconds(audioList[i].clip.length);
			}
		}
	}
}
