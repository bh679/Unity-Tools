using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppVersionToText : MonoBehaviour
{
	public Text Text;

	string _cache;
	
	void Reset()
	{
		Text = this.GetComponent<Text>();
	}

	void Update()
	{
		if (Application.version != _cache)
		{
			_cache = Application.version;
			Text.text = _cache;
		}
	}
}
