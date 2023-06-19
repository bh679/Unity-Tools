using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TextFile : MonoBehaviour
{
    
		
	public static IEnumerator Load(string filPath, System.Action<string> result)
	{
		string path = "file://" + Application.streamingAssetsPath + filPath;
		Debug.Log(path);
		using (UnityWebRequest www = UnityWebRequest.Get(path))
		{
			yield return www.SendWebRequest();
			if (www.result != UnityWebRequest.Result.Success)
			{
				Debug.Log(www.error);
				result(null); // You can call the action with null or with some error message.
			}
			else
			{
				//Debug.Log(www.downloadHandler.text);
				result(www.downloadHandler.text);
			}
		}
	}
}
