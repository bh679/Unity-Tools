//
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. 
//
// <code>
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Microsoft.CognitiveServices.Speech;
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif
#if PLATFORM_IOS
using UnityEngine.iOS;
using System.Collections;
#endif

[System.Serializable]
public class Text2SpeechResults
{
	public string message;
	//public float time;
	
	public Text2SpeechResults(string _message)
	{
		message = _message;
		//time = System.DateTime.Now.to;
	}
}

public class MSCogVoiceToText : MonoBehaviour
{
	// Hook up the two properties below with a Text and Button object in your UI.
	public Text outputText;
	public Button startRecoButton;

	public TextAsset key;
	public string region = "australiaeast";
	
	private object threadLocker = new object();
	private bool waitingForReco;
	private string message;

	private bool micPermissionGranted = false;

	//[HideInInspector]
	public List<Text2SpeechResults> results = new List<Text2SpeechResults>();

#if PLATFORM_ANDROID || PLATFORM_IOS
	// Required to manifest microphone permission, cf.
	// https://docs.unity3d.com/Manual/android-manifest.html
	private Microphone mic;
#endif

	public async void ButtonClick()
	{
		// Creates an instance of a speech config with specified subscription key and service region.
		// Replace with your own subscription key and service region (e.g., "westus").
		var config = SpeechConfig.FromSubscription(key.text, region);

		// Make sure to dispose the recognizer after use!
		using (var recognizer = new SpeechRecognizer(config))
		{
			lock (threadLocker)
			{
				waitingForReco = true;
			}

			// Starts speech recognition, and returns after a single utterance is recognized. The end of a
			// single utterance is determined by listening for silence at the end or until a maximum of 15
			// seconds of audio is processed.  The task returns the recognition text as result.
			// Note: Since RecognizeOnceAsync() returns only a single utterance, it is suitable only for single
			// shot recognition like command or query.
			// For long-running multi-utterance recognition, use StartContinuousRecognitionAsync() instead.
			var result = await recognizer.RecognizeOnceAsync().ConfigureAwait(false);

			// Checks result.
			string newMessage = string.Empty;
			if (result.Reason == ResultReason.RecognizedSpeech)
			{
				newMessage = result.Text;
				results.Add(new Text2SpeechResults(newMessage));
			}
			else if (result.Reason == ResultReason.NoMatch)
			{
				newMessage = "NOMATCH: Speech could not be recognized.";
			}
			else if (result.Reason == ResultReason.Canceled)
			{
				var cancellation = CancellationDetails.FromResult(result);
				newMessage = $"CANCELED: Reason={cancellation.Reason} ErrorDetails={cancellation.ErrorDetails}";
			}

			lock (threadLocker)
			{
				message = newMessage;
				
				waitingForReco = false;
			}
		}
	}

	void Start()
	{
		if (outputText == null)
		{
			UnityEngine.Debug.LogError("outputText property is null! Assign a UI Text element to it.");
		}
		else if (startRecoButton == null)
		{
			message = "startRecoButton property is null! Assign a UI Button to it.";
			UnityEngine.Debug.LogError(message);
		}
		else
		{
			// Continue with normal initialization, Text and Button objects are present.
#if PLATFORM_ANDROID
			// Request to use the microphone, cf.
			// https://docs.unity3d.com/Manual/android-RequestingPermissions.html
			message = "Waiting for mic permission";
			if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
			{
			Permission.RequestUserPermission(Permission.Microphone);
			}
#elif PLATFORM_IOS
			if (!Application.HasUserAuthorization(UserAuthorization.Microphone))
			{
			Application.RequestUserAuthorization(UserAuthorization.Microphone);
			}
#else
			micPermissionGranted = true;
			message = "Click button to recognize speech";
#endif
			startRecoButton.onClick.AddListener(ButtonClick);
		}
	}

	void Update()
	{
#if PLATFORM_ANDROID
		if (!micPermissionGranted && Permission.HasUserAuthorizedPermission(Permission.Microphone))
		{
		micPermissionGranted = true;
		message = "Click button to recognize speech";
		}
#elif PLATFORM_IOS
		if (!micPermissionGranted && Application.HasUserAuthorization(UserAuthorization.Microphone))
		{
		micPermissionGranted = true;
		message = "Click button to recognize speech";
		}
#endif

		lock (threadLocker)
		{
			if (startRecoButton != null)
			{
				startRecoButton.interactable = !waitingForReco && micPermissionGranted;
			}
			if (outputText != null)
			{
				outputText.text = message;
				//results.Add(new Text2SpeechResults(message));
			}
		}
	}
}
// </code>
