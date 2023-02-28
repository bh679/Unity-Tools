//BrennanHatton
//2018
//For changing lighting settings realtime in game

using UnityEngine;


namespace BrennanHatton.UnityTools
{
	
	[ExecuteInEditMode]
	public class SetGlobalLighting : MonoBehaviour {
		
		public enum FogSettings
		{
			None = 0,
			Linear = 1,
			Exponential = 2,
			ExponentialSquared = 3
		}
		
		public bool onStart = false;
		public bool onGameObjectActive = true;
		public bool changeAmbientLightSource = true;
		public UnityEngine.Rendering.AmbientMode ambientLightSource = UnityEngine.Rendering.AmbientMode.Flat;
		public Color color;
		
		public Material skybox;
		
		public FogSettings fog = FogSettings.None;
		public float fogDensity = 0.01f;
		public float fogstart = 50, fogend = 200f;
		
		
		
		bool objectActive ;
		
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
			if(changeAmbientLightSource)
			{
				if(ambientLightSource != RenderSettings.ambientMode)
					RenderSettings.ambientMode = ambientLightSource;
				
				if(RenderSettings.ambientLight != color)
					RenderSettings.ambientLight = color;
			}
			
			if(skybox!= null)
				RenderSettings.skybox = skybox;
			
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
				break;
				
			case (int)FogSettings.Exponential:
				RenderSettings.fog = true;
				RenderSettings.fogMode = FogMode.Exponential;
				RenderSettings.fogDensity = fogDensity;
				
				break;
				
			case (int)FogSettings.ExponentialSquared:
				RenderSettings.fog = true;
				RenderSettings.fogMode = FogMode.ExponentialSquared;
				RenderSettings.fogDensity = fogDensity;
				
				break;
			}
		}
	}
}