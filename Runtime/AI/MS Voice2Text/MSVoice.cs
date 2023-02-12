using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
using TMPro;

public class MSVoice : MonoBehaviour
{
	
	
	public TMP_Text result, hypothesis, complete, error;
	
	DictationRecognizer dictationRecognizer = new DictationRecognizer();
	bool isRecording = false;
	
	void Start()
	{
		dictationRecognizer = new DictationRecognizer();
		isRecording = false;
	}
	
	public void Record(bool _isRecording)
	{
		if(_isRecording == isRecording)
			return;
		
		if(!isRecording)
			StartRecording();
		else
			StopRecording();
	}

	public void StartRecording()
	{
		isRecording = true;
		
		dictationRecognizer.Start();
		
		dictationRecognizer.DictationResult += DictationRecognizer_DictationResult;
		dictationRecognizer.DictationHypothesis += DictationRecognizer_DictationHypothesis;
		dictationRecognizer.DictationComplete += DictationRecognizer_DictationComplete;
		dictationRecognizer.DictationError += DictationRecognizer_DictationError;
	}
	
	public void StopRecording()
	{
		isRecording = false;
		
		dictationRecognizer.Stop();
		
		dictationRecognizer.DictationResult -= DictationRecognizer_DictationResult;
		dictationRecognizer.DictationComplete -= DictationRecognizer_DictationComplete ;
		dictationRecognizer.DictationHypothesis -= DictationRecognizer_DictationHypothesis ;
		dictationRecognizer.DictationError -= DictationRecognizer_DictationError ;
		dictationRecognizer.Dispose();
	}
    
	private void DictationRecognizer_DictationResult(string text, ConfidenceLevel confidence)
	{
		// do something
		Debug.Log("Result: "+text);
	}
	
	private void DictationRecognizer_DictationHypothesis(string text)
	{
		// do something
		Debug.Log("Hypothesis: "+text);
	}
	
	private void DictationRecognizer_DictationComplete(DictationCompletionCause cause)
	{
		// do something
		Debug.Log("Complete");
	}
	
	private void DictationRecognizer_DictationError(string error, int hresult)
	{
		// do something
		Debug.Log("Error: "+error);
	}
}
