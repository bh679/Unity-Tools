using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

namespace BrennanHatton.UnityTools
{
	
	public class CheckWebglMobile : MonoBehaviour
	{
		
		public GameObject[] mobileOnly, webGlNotMobile;
		
		/*   #if !UNITY_EDITOR && UNITY_WEBGL
		[DllImport("__Internal")]
		private static extern bool IsMobile();
	         #endif*/
	 
		public bool isMobile()
		{
			Debug.LogError("To make this work, you ned to find the javascript file. Check Dungeon Train source, or maybe BrennanHatton/TheGame");
	        /* #if !UNITY_EDITOR && UNITY_WEBGL
			return IsMobile();
	         #endif
			return false;*/
			return false;
		}
		
		public void EnableOnMobile()
		{
			bool _isMobile = isMobile();
			
			for(int i = 0; i < mobileOnly.Length; i++)
				mobileOnly[i].SetActive(_isMobile);
			
			for(int i = 0; i < webGlNotMobile.Length; i++)
				webGlNotMobile[i].SetActive(!_isMobile);
		}
	}
}
