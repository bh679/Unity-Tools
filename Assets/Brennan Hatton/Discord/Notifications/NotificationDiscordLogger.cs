#if DISCORD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BrennanHatton.Discord;

namespace BrennanHatton.Notifications
{

	public class NotificationDiscordLogger : MonoBehaviour
	{
		public Notification notification;
		bool sent = false;
		
		void Reset()
		{
			notification = this.GetComponent<Notification>();
		}
	    // Update is called once per frame
	    void Update()
	    {
		    if(ClassDiscordConnection.Instance == null)
			    return;
			    
		    if(!sent && notification.isSetUp)
		    {
			    ClassDiscordConnection.Instance.SendMessage("Notification ``" + notification.title.text + "`` ``" + notification.body.text+"``");
			    sent = true;
		    }
	    }
	}

}
#endif