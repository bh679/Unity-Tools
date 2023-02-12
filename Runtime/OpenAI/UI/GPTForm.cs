using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BrennanHatton.AI
{

	[System.Serializable]
	public class GPTInput
	{
		public string name;
		public TMP_InputField input;
		public TextAsset prePrompt, postPrompt;
		
		public string GetPrompt()
		{
			return (prePrompt != null?prePrompt.text:"") + input.text + (postPrompt!=null?postPrompt.text:"");
		}
	}
	
	public class GPTForm : MonoBehaviour
	{
		public TextAsset[] prePrompts, postPrompts;
		public GPTInput[] inputs;
		public GPT3 gpt;
		public string prompt;
		
		void Reset()
		{
			gpt = FindObjectOfType<GPT3>();
		}
		
		public void GeneratePrompt()
		{
			prompt = "";
			
			for(int i = 0 ; i < prePrompts.Length; i++)
				prompt += prePrompts[i] + "\n\n";
		
				
			for(int i = 0 ; i < inputs.Length; i++)
				prompt += inputs[i].GetPrompt() + "\n\n";
				
			
			for(int i = 0 ; i < postPrompts.Length; i++)
				prompt += postPrompts[i] + "\n\n";
		}
		
		public void Run()
		{
			gpt.Execute(prompt);
		}
		
		public void GenerateAndRun()
		{
			GeneratePrompt();
			
			Run();
		}
	}

}