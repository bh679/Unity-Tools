using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.UnityTools
{

	public class DisableAfterTime : MonoBehaviour
	{
		public float duration = 3f;
		
		public IEnumerator startTimer()
		{
			yield return new WaitForSeconds(duration);
			this.gameObject.SetActive(false);
		}
		
		void OnEnable()
	    {
		    StartCoroutine(startTimer());
	    }
	}

}