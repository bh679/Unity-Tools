using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BrennanHatton.Scoring
{

	public class FloatToText : MonoBehaviour
	{
	    
		public ScoringFloat score;
		public TMP_Text text;
			
		void Reset()
		{
			score = this.GetComponent<ScoringFloat>();
			text = this.GetComponent<TMP_Text>();
		}
			
		void Update()
		{
			text.text = score.GetScore().ToString();
		}
	}

}