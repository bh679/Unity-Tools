﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BrennanHatton.UnityTools
{
		
	public class EventOnEnableDisable : MonoBehaviour
	{
		public UnityEvent onEnable;
		public UnityEvent onDisable;
		
		
		void OnEnable(){
			onEnable.Invoke();
		}
		
		void OnDisable(){
			onDisable.Invoke();
		}
	}
}