using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BrennanHatton.Scoring
{
	public class EventOnFloatTarget : MonoBehaviour
	{
		public ScoringFloat score;
		public float target;
		public EventOnFloatChange requireScoreChange;
		public UnityEvent onGreaterThan = new UnityEvent();
		public UnityEvent onEqualTo = new UnityEvent();
		public UnityEvent onLessThan = new UnityEvent();
		
		public bool alwaysCheck = false;
		
		enum comparisonState{
			greaterThan = 0,
			equalTo = 1,
			lessThan = 2
		}
		comparisonState state, lastState;
		
		void Reset()
		{
			score = this.GetComponent<ScoringFloat>();
			requireScoreChange = this.GetComponent<EventOnFloatChange>();
		}
		
		// Start is called before the first frame update
		void Start()
		{
			if(score.GetScore() > target)
				state = comparisonState.greaterThan;
			else if(score.GetScore() == target)
				state = comparisonState.equalTo;
			else 
				state = comparisonState.lessThan;
				
			lastState = state;
		}
	
		// Update is called once per frame
		void Update()
		{
			if(requireScoreChange != null)
			{
				if(!requireScoreChange.HasScoreChanged())
					return;
			}
			
			//Debug.Log("Score has changed");
			
			GetState();
				
			CheckState();
		}
		
		public void GetState()
		{
			lastState = state;
			
			if(score.GetScore() > target)
				state = comparisonState.greaterThan;
			else if(score.GetScore() == target)
				state = comparisonState.equalTo;
			else 
				state = comparisonState.lessThan;
		}
		
		public void CheckState()
		{
			
			if(alwaysCheck || lastState != state)
			{
				switch((int)state)
				{
				case (int)comparisonState.greaterThan:
					onGreaterThan.Invoke();
					break;
				case (int)comparisonState.equalTo:
					onEqualTo.Invoke();
					break;
				case (int)comparisonState.lessThan:
					onLessThan.Invoke();
					break;
				}
			}
		}
		
	    
		
	}
}