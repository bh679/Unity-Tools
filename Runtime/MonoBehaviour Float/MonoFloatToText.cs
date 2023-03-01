using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BrennanHatton.UnityTools.MonoFloat
{

	public class MonoFloatToText : MonoBehaviour
	{
	    
		public MonoFloat monoFloat;
		public TMP_Text text;
		public Text legacyText;
			
		void Reset()
		{
			monoFloat = GameObject.FindAnyObjectByType<MonoFloat>();
			text = this.GetComponent<TMP_Text>();
			legacyText = this.GetComponent<Text>();
		}
			
		void Update()
		{
			if(text != null) text.text = monoFloat.GetFloat().ToString();
			if(legacyText != null) legacyText.text = monoFloat.GetFloat().ToString();
		}
	}

}