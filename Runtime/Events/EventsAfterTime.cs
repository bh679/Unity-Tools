using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BrennanHatton.UnityTools
{
	public class UnityEventAfterTime
	{
		//Time until event is called public float time;
		//Event to be called
		public UnityEvent timedEvent;
		
		//If we repeat the event or not
		public bool looping = false;
	
		public float time = 0;
	}
	
	public enum MonoStart
	{
		OnAwake, OnStart, OnEnable, OnEnableOnce
	}

	[AddComponentMenu ("Brennan Hatton/Events/Events After Time" )]
	public class EventsAfterTime : MonoBehaviour 
	{
		public List<UnityEventAfterTime> timedEvents = new List<UnityEventAfterTime>();
		public MonoStart startTime = MonoStart. OnEnable;
		
		bool called = false;
		
		void Reset()
		{
			timedEvents.Add(new UnityEventAfterTime());
		}
		
		void Awake ()
		{
			if (startTime == MonoStart.OnAwake)
				StartTimers ();
		}
		
		// Use this for initialization
		void Start ()
		{
			if (startTime == MonoStart.OnStart)
				StartTimers ();
		}
		
		// Use this for initialization
		void OnEnable ()
		{
			if (startTime == MonoStart.OnEnable)
				StartTimers ();
			else if (startTime == MonoStart.OnEnableOnce && !called)
			{
				called = true;
				StartTimers ();
			}
		}
		
		public void StartTimers ()
		{
			for(int i = 0 ; i < timedEvents.Count;i ++)
			{
				StartCoroutine(_runTimer(timedEvents[i]));
			}
		}
		
		IEnumerator _runTimer(UnityEventAfterTime timer)
		{
			yield return new WaitForSeconds(timer.time);
			
			timer.timedEvent.Invoke();
			
			while(timer.looping)
			{
				
				yield return new WaitForSeconds(timer.time);
			
				timer.timedEvent.Invoke();
			}
		}
	}
}