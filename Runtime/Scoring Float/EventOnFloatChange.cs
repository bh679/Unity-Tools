using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BrennanHatton.Scoring
{
	public class EventOnFloatChange : MonoBehaviour
	{
		public ScoringFloat scoringFloat;
		float lastFrameValue;
		public UnityEvent onScoreChange = new UnityEvent();
		bool scoreChanged = false;
		
		void Reset()
		{
			scoringFloat = this.GetComponent<ScoringFloat>();
		}
		
	    // Start is called before the first frame update
	    void Start()
		{
			lastFrameValue = scoringFloat.GetScore();
	    }
	
	    // Update is called once per frame
	    void Update()
	    {
		    if(CheckScoreChanged())
			    onScoreChange.Invoke();
	    }
		
		public bool HasScoreChanged()
		{
			return scoreChanged;
		}
	    
		bool CheckScoreChanged()
		{
			scoreChanged = false;
			
			if(lastFrameValue != scoringFloat.GetScore())
			{
				scoreChanged = true;
			}
		    
			lastFrameValue = scoringFloat.GetScore();
			
			return scoreChanged;
		}
		
	}
}