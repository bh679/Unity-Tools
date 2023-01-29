using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BrennanHatton.UnityTools
{
	public class TimeToText : MonoBehaviour
	{
		
		public Text text;
		
		void Reset()
		{
			text = this.GetComponent<Text>();
		}
		
	
	
	    // Update is called once per frame
	    void Update()
	    {
		    text.text = FloatToTime((float)System.DateTime.Now.TimeOfDay.TotalSeconds);//.Hours.ToString() + ":" + System.DateTime.Now.TimeOfDay.Minutes.ToString() + ":" + System.DateTime.Now.TimeOfDay.Seconds.ToString();
		    
	    }
	    
		string FloatToTime(float time)
		{
			
			int hours, minutes, seconds;
			seconds = (int)(time % 60);
			minutes = (int)(time / 60) % 60;
			hours = (int)((time / 60) / 60) % 24;
			
			return ((hours<10)?"0":"") + hours.ToString() + ":" + ((minutes<10)?"0":"") + minutes + ":" + ((seconds<10)?"0":"") + seconds;
		}
	    
		
	}
}