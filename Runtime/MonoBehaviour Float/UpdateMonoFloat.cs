using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.UnityTools.MonoFloat
{
	
	public class UpdateMonoFloat : MonoBehaviour
	{
		public MonoFloat scoreFloat;
		
		public float addAmount = 1f;
		
		void Reset()
		{
			scoreFloat = GameObject.FindFirstObjectByType<MonoFloat>();
		}
		
		[Tooltip("Changes score value by 'addAmount' every second")]
		public bool OnUpdate;
	
	    // Update is called once per frame
	    void Update()
	    {
		    if(OnUpdate)
			    AddToFloat(addAmount);
	    }
	    
		public void AddToFloat(float value)
		{
			scoreFloat.UpdateFloat(value);
		}
	}
}