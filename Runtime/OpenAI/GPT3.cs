/*
Modified by Brennan Hatton

modified original sample code by unitycoder.com
From https://github.com/unitycoder/UnityOpenAIGPT3
MIT License
*/
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace BrennanHatton.AI
{
	public class InteractionData
	{
		public RequestData requestData;
		public OpenAIAPI responseData;
		public string GeneratedText
		{
			get{
			return generatedText;
			}
		}
		public string generatedText;
		public bool processing;
		
		public InteractionData(RequestData _requestData)
		{
			requestData = _requestData;
			processing = true;
		}
		
		public void SetResponse(OpenAIAPI _result)
		{
			responseData = _result;
			generatedText = responseData.choices[0].text.TrimStart('\n').TrimStart('\n');
			processing = false;
		}
	}

	/// <summary>
	/// A UnityEvent with a Grabbable as the parameter
	/// </summary>
	[System.Serializable]
	public class InteractionEvent : UnityEvent<InteractionData> { }
	
	public class GPT3 : MonoBehaviour
	{
		const string url = "https://api.openai.com/v1/completions";

		public string modelName = "text-davinci-003";

		public GameObject loadingIcon;
		public TextAsset apiKeytext;

		string apiKey = null;
		public bool IsRunning{ get{  return isRunning; } }
		bool isRunning = false;
		
		public InteractionEvent onExecute = new InteractionEvent(), onResults = new InteractionEvent();
		
		
		public List<InteractionData> interactions = new List<InteractionData>();
		
		public string GetRecentResults(int n)
		{
			string output = "";
			for(int i = Mathf.Max(0,interactions.Count - n); i < interactions.Count; i++)
			{
				output += interactions[i].GeneratedText;
			}
			
			return output;
		}
		
		
		void Start()
		{
			LoadAPIKey();
		}

		public void Execute(string newPrompt)
		{
			InteractionData newInteraction;
			
			if (isRunning)
			{
				Debug.LogError("Already running");
				return;
			}
			isRunning = true;
			if(loadingIcon != null ) loadingIcon.SetActive(true);
            
			// fill in request data
			RequestData requestData = new RequestData()
			{
				model = modelName,
				prompt = newPrompt,
				temperature = 0.7f,
				max_tokens = 256,
				top_p = 1,
				frequency_penalty = 0,
				presence_penalty = 0
            };
            
			newInteraction = new InteractionData(requestData);
			onExecute.Invoke(newInteraction);
			
			Debug.Log(requestData.prompt);
			
            

			string jsonData = JsonUtility.ToJson(requestData);

			byte[] postData = System.Text.Encoding.UTF8.GetBytes(jsonData);

			UnityWebRequest request = UnityWebRequest.Post(url, jsonData);
			request.uploadHandler = new UploadHandlerRaw(postData);
			request.downloadHandler = new DownloadHandlerBuffer();
			request.SetRequestHeader("Content-Type", "application/json");
			request.SetRequestHeader("Authorization", "Bearer " + apiKey);

			UnityWebRequestAsyncOperation async = request.SendWebRequest();

			async.completed += (op) =>
			{
				if (request.result == UnityWebRequest.Result.ConnectionError)
				{
					Debug.LogError(request.error);
				}
				else
				{
					Debug.Log(request.downloadHandler.text);
					// parse the results to get values 
					OpenAIAPI responseData = JsonUtility.FromJson<OpenAIAPI>(request.downloadHandler.text);
					newInteraction.SetResponse(responseData);
					onResults.Invoke(newInteraction);
					interactions.Add(newInteraction);
					
					// sometimes contains 2 empty lines at start?
					//string generatedText = responseData.choices[0].text.TrimStart('\n').TrimStart('\n');

					//results.Insert(0,generatedText);
				}
				if(loadingIcon != null ) loadingIcon.SetActive(false);
				isRunning = false;
			};
			
			//_prompt += followupPrompts.text;

		} // execute

		void LoadAPIKey()
		{
			// TODO optionally use from env.variable

			
			apiKey = apiKeytext.text;
			Debug.Log("API key loaded, len= " + apiKey.Length);
		}
	}
}
