using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BrennanHatton.Notifications
{

	public class CreateNotification : MonoBehaviour
	{
		public Notification prefab;
		
		public string title, description;
		public Sprite image;
		public bool silent = true;
		
		public bool onEnable;
		
	#if UNITY_EDITOR
		void Reset()
		{
			object _prefab = AssetDatabase.LoadAssetAtPath("Assets/Brennan Hatton/Utilities/Prefabs/Notification.prefab", typeof(Notification));
			Debug.Log(_prefab);
			prefab = (Notification)_prefab;
		}
	#endif
		
		public void OnEnable()
		{
			if(onEnable)
				Create_Notification();
		}
	    
		public void Create_Notification()
		{
			Notification notification = Instantiate(prefab) as Notification;
			
			notification.SetUp(title, description, image, silent);
		}
	}
}