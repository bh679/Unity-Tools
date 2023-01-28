using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class CheckWebglMobile : MonoBehaviour
{
	
	public GameObject[] mobileOnly, webGlNotMobile;
	
         #if !UNITY_EDITOR && UNITY_WEBGL
	[DllImport("__Internal")]
	private static extern bool IsMobile();
         #endif
 
	public bool isMobile()
	{
         #if !UNITY_EDITOR && UNITY_WEBGL
		return IsMobile();
         #endif
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
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
