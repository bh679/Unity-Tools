#if PUN
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeToText : MonoBehaviour
{
	
	public enum TimeMode
	{
		Local = 0,
		Server = 1,
		AppTimer = 2
	}
	
	
	public Text text;
	
	public TimeMode timeMode;
	
	void Reset()
	{
		text = this.GetComponent<Text>();
	}
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    
	    if(timeMode == TimeMode.Local)
		    text.text = FloatToTime((float)System.DateTime.Now.TimeOfDay.TotalSeconds);//.Hours.ToString() + ":" + System.DateTime.Now.TimeOfDay.Minutes.ToString() + ":" + System.DateTime.Now.TimeOfDay.Seconds.ToString();
	    
	    else if(timeMode == TimeMode.AppTimer)
		    text.text = FloatToTime(Time.time);
	    
	    else if(timeMode == TimeMode.Server)
		    text.text = FloatToTime((float)Photon.Pun.PhotonNetwork.Time);
	    
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
#endif