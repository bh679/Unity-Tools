using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BrennanHatton
{

	public class InputRandomText : MonoBehaviour
	{
		public TMP_InputField input;
		public string[] text;
		public bool onStart = true;
		
		void Reset()
		{
			input = this.GetComponent<TMP_InputField>();
		}
		
		
	    // Start is called before the first frame update
	    void Start()
	    {
		    if(onStart)
			    SetRandom();
	    }
	    
		public void SetRandom()
		{
			input.text = text[Random.Range(0,text.Length)];
		}
	}

}