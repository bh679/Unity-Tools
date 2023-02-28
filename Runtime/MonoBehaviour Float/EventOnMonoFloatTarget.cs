using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace BrennanHatton.UnityTools.MonoFloat
{

	public class EventOnMonoFloatTarget : MonoBehaviour
	{
		public MonoFloat monoFloat;
		public float target;
		public EventOnMonoFloatChange requireScoreChange;
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
			monoFloat = this.GetComponent<MonoFloat>();
			requireScoreChange = this.GetComponent<EventOnMonoFloatChange>();
		}
		
		// Start is called before the first frame update
		void Start()
		{
			if(monoFloat.GetFloat() > target)
				state = comparisonState.greaterThan;
			else if(monoFloat.GetFloat() == target)
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
			
			if(monoFloat.GetFloat() > target)
				state = comparisonState.greaterThan;
			else if(monoFloat.GetFloat() == target)
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