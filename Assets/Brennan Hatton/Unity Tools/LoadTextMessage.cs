using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadTextMessage : MonoBehaviour
{
	public string[] loadingMessages;
	public TMP_Text text;
	public float startDelay = 5;
	public int startRandomFrequency = 5, maxLines = 40;
	float delay;
	
	int i = 0;
	int randomFrequencey = 0;
	int lines = 0;
	
    // Start is called before the first frame update
    void Start()
    {
	    i = Random.Range(0,loadingMessages.Length-1);
	    text.text = loadingMessages[i];
    }
    // Update is called once per frame
    void Update()
	{
		if(delay <= 0)
		{
			i++;
			text.text += loadingMessages[i] + '\n';
			delay = startDelay + loadingMessages[i].Length/20f;
			randomFrequencey--;
			lines++;
			
			if(randomFrequencey <= 0)
			{
				randomFrequencey = startRandomFrequency;
				i += (int)Random.Range(1,loadingMessages.Length/3);
			}
			
			if(i >= loadingMessages.Length)
				i = 0;
				
			if(lines >= maxLines)
			{
				text.text = "";
			}
		}
		
		delay -= Time.deltaTime;
    }
}
