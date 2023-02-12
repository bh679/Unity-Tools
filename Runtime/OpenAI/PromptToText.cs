using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BrennanHatton.AI
{
	public class PromptToText : MonoBehaviour
	{
		public TMP_Text promptText, responseText;
		public GPT3 gpt;
		int length = 0;
		
		void Reset()
		{
			promptText = this.GetComponent<TMP_Text>();
		}
		
		// Update is called once per frame
		void Update()
		{
			if(length != gpt.interactions.Count)
			{
				promptText.text = gpt.interactions[gpt.interactions.Count-1].requestData.prompt;
				responseText.text = gpt.interactions[gpt.interactions.Count-1].GeneratedText;
				length = gpt.interactions.Count;
			}
		}
	}
}