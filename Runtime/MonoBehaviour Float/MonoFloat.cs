using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BrennanHatton.UnityTools.MonoFloat
{
	
	public class MonoFloat : MonoBehaviour
	{
		[SerializeField] 
		protected float value;
		
		
		public virtual void UpdateFloat(float scoreUpdate)
		{
			value += scoreUpdate;
		}
		
		
		public virtual void UpdateFloatDeltaTime(float scoreUpdate)
		{
			UpdateFloat(scoreUpdate*Time.deltaTime);
		}
		
		public virtual void SetFloat(float newScore)
		{
			
				value = newScore;
		}
		
		public virtual float GetFloat()
		{
			
				return value;
		}
	}
}