using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatTimer : MonoBehaviour
{
	public float time;
	public bool onStart = false;
	bool timerToggle;
	
    // Start is called before the first frame update
    void Start()
    {
	    if(onStart)
	    	startTimer();
    }

    // Update is called once per frame
    void Update()
    {
	    if(timerToggle)
	    {
	    	time += Time.deltaTime;
	    }
    }
    
	public void startTimer(){
		timerToggle = true;
	}
	
	public void stopTimer(){
		timerToggle = false;
	}
	
	public void restartTimer(){
		time = 0f;
		timerToggle = true;
	}
	
	public void resetTimer(){
		time = 0f;
	}
}
