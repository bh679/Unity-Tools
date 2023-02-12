using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BrennanHatton.AI
{

	public class InputToGPT : MonoBehaviour
	{
		public GPT3 gpt;
		public TMP_InputField input;
		public PromptWrapper promptWrapper;
		
		void Reset()
		{
			input = this.GetComponentInChildren<TMP_InputField>();
			gpt = GameObject.FindObjectOfType<GPT3>();
		}
		
		public void AskGPT()
		{
			gpt.Execute(promptWrapper.wrapPromopt(input.text));
		}
	}

}