using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.Scoring
{
	
	public class UpdateScoreFloat : MonoBehaviour
	{
		public ScoringFloat scoreFloat;
		
		public float addAmount = 1f;
		
		void Reset()
		{
			scoreFloat = GameObject.FindFirstObjectByType<ScoringFloat>();
		}
		
		[Tooltip("Changes score value by 'addAmount' every second")]
		public bool OnUpdate;
	
	    // Update is called once per frame
	    void Update()
	    {
		    if(OnUpdate)
			    AddToScore(addAmount);
	    }
	    
		public void AddToScore(float value)
		{
			scoreFloat.UpdateScore(value);
		}
	}
}