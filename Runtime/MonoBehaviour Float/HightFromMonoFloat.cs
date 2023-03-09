using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BrennanHatton.UnityTools.MonoFloat
{

	public class HightFromMonoFloat : MonoBehaviour
	{
		
		public MonoFloat monoFloat; 
		
		public Vector3 baseScale = Vector3.one;
		public float scaleFactor = 1f;
		public float time = 1f;
		
		public UnityEvent onComplete = new UnityEvent();
		
		
	    // Start is called before the first frame update
		public void StartScale()
		{
			StartCoroutine(Scale());
		}
		
		IEnumerator Scale()
		{
			for(int i = 0; i < time*25; i++)
			{
				yield return new WaitForSeconds((time/25f) * Time.deltaTime);
			
				transform.localScale = baseScale + Vector3.up*scaleFactor*monoFloat.GetFloat()*i/(time*25);
			}
				
			onComplete.Invoke();
		}
		
	}
}