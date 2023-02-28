using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BrennanHatton.UnityTools.MonoFloat
{
	public class EventOnMonoFloatChange : MonoBehaviour
	{
		public MonoFloat scoringFloat;
		float lastFrameValue;
		public UnityEvent onScoreChange = new UnityEvent();
		bool scoreChanged = false;
		
		void Reset()
		{
			scoringFloat = this.GetComponent<MonoFloat>();
		}
		
	    // Start is called before the first frame update
	    void Start()
		{
			lastFrameValue = scoringFloat.GetFloat();
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
			
			if(lastFrameValue != scoringFloat.GetFloat())
			{
				scoreChanged = true;
			}
		    
			lastFrameValue = scoringFloat.GetFloat();
			
			return scoreChanged;
		}
		
	}
}