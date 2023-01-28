using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BrennanHatton.Notifications
{

	public class Notification : MonoBehaviour
	{
		public Text title, body;
		public Image icon;
		public AudioSource audio;
		
		public UnityEvent onFinish;
		public bool isSetUp = false;
		
		public void SetUp(string _title, string _description, Sprite _icon, bool silent)
		{
			title.text = _title;
			body.text = _description;
			icon.sprite = _icon;
			
			if(!silent)
				audio.Play();
				
			isSetUp = true;
		}
	    
		public void Close()
		{
			onFinish.Invoke();
			this.gameObject.SetActive(false);
			Destroy(this.gameObject);
		}
	}

}