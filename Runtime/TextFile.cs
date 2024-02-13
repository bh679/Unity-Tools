using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TextFile : MonoBehaviour
{
    
		
	public static IEnumerator Load(string filePath, System.Action<string> result)
	{
		string path;
			
#if UNITY_ANDROID && !UNITY_EDITOR
		// For Android, directly use the path without "file://" prefix
		path = Application.streamingAssetsPath + filePath;
#else
		// For other platforms, prepend "file://" to the path
		path = "file://" + Application.streamingAssetsPath + filePath;
#endif
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
