using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace BrennanHatton.Scoring
{
	
	public class ScoringFloat : MonoBehaviour
	{
		[SerializeField] 
		protected float value;
		
		
		public virtual void UpdateScore(float scoreUpdate)
		{
			value += scoreUpdate;
		}
		
		
		public virtual void UpdateScoreDeltaTime(float scoreUpdate)
		{
			UpdateScore(scoreUpdate*Time.deltaTime);
		}
		
		public virtual void SetScore(float newScore)
		{
			
				value = newScore;
		}
		
		public virtual float GetScore()
		{
			
				return value;
		}
	}
}