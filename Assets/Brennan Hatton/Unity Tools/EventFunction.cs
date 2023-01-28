using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

namespace BrennanHatton.Utilities
{
	public class EventFunction : MonoBehaviour {
		
		[System.Serializable]
		public class EventByName {
			
			public string name;
			public UnityEvent myEvent;
		}
		
		public List<EventByName> events = new List<EventByName>();
		
		public void CallEvent(string name)
		{
			//Debug.Log(name);
			for(int i = 0; i < events.Count; i++)
			{
				if(events[i].name == name)
				{
					events[i].myEvent.Invoke();
					
					return;
				}
			}
		}
		
		public void CallEvent(int id)
		{
			events[id].myEvent.Invoke();
		}
		
		public void CallEvent()
		{
			events[0].myEvent.Invoke();
		}
	}
}