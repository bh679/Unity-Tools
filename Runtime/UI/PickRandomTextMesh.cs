using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BrennanHatton.UnityTools
{

	public class PickRandomText : MonoBehaviour {
		
		public List<string> TextOptions = new List<string>();
		
		public bool OnStart = true;
		public bool onEnable = false;
		
		public TMP_Text textObj;
		
		void Reset()
		{
			textObj = this.GetComponent<TMP_Text>();
		}
		
		// Use this for initialization
		void Start () {
			if (OnStart)
				RandomText ();
		}
		
		// Use this for initialization
		void OnEnable () {
			if (onEnable)
				RandomText ();
		}
		
		public void RandomText()
		{
			if(TextOptions.Count == 0)
				return;
			
			textObj.text = TextOptions[Random.Range(0,TextOptions.Count-1)];
			
		}
	}

}