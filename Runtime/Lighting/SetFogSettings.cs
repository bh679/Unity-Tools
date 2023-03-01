using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.UnityTools
{

	[ExecuteInEditMode]
	public class SetFogSettings : MonoBehaviour
	{
		public enum FogSettings
		{
			None = 0,
			Linear = 1,
			Exponential = 2,
			ExponentialSquared = 3
		}
		
		public bool onStart = false;
		public bool onGameObjectActive = false;
		public Color color;
		
		
		public FogSettings fog = FogSettings.None;
		public float fogDensity = 0.01f;
		public float fogstart = 50, fogend = 200f;
		
		
		
		bool objectActive ;
		
		void Reset()
		{
			if(RenderSettings.fogMode == FogMode.Linear)
				fog = FogSettings.Linear;
			else if(RenderSettings.fogMode == FogMode.Exponential)
				fog = FogSettings.Exponential;
			else if(RenderSettings.fogMode == FogMode.ExponentialSquared)
				fog = FogSettings.ExponentialSquared;
				
			color = RenderSettings.fogColor;
			
			fogDensity = RenderSettings.fogDensity;
			
			fogstart = RenderSettings.fogStartDistance;
			fogend = RenderSettings.fogEndDistance;
			onGameObjectActive = true;
		}
		
		void OnEnable()
		{
			if(onGameObjectActive)
				ChangeLighting();
		}
		
		// Use this for initialization
		void Start () {
			objectActive = gameObject.activeInHierarchy;
			if (onStart)
				ChangeLighting();
		}
		
		// Update is called once per frame
		void Update () {
			
			if(onGameObjectActive && gameObject.activeInHierarchy && objectActive == false)
				ChangeLighting();
			
			objectActive = gameObject.activeInHierarchy;
		}
		
		public void ChangeLighting()
		{
			switch((int)fog)
			{
				
			case (int)FogSettings.None:
				RenderSettings.fog = false;
				break;
				
			case (int)FogSettings.Linear:
				RenderSettings.fog = true;
				RenderSettings.fogMode = FogMode.Linear;
				RenderSettings.fogDensity = fogDensity;
				RenderSettings.fogStartDistance = fogstart;
				RenderSettings.fogEndDistance = fogend;
				RenderSettings.fogColor = color;
				break;
				
			case (int)FogSettings.Exponential:
				RenderSettings.fog = true;
				RenderSettings.fogMode = FogMode.Exponential;
				RenderSettings.fogDensity = fogDensity;
				RenderSettings.fogColor = color;
				break;
				
			case (int)FogSettings.ExponentialSquared:
				RenderSettings.fog = true;
				RenderSettings.fogMode = FogMode.ExponentialSquared;
				RenderSettings.fogDensity = fogDensity;
				RenderSettings.fogColor = color;
				break;
			}
		}
	}

}
