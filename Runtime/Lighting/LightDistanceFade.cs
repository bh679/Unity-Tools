/*
Brennan Hatton
2021
Change light range and intensity from distance to target
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.UnityTools
{

	public class LightDistanceFade : MonoBehaviour
	{
		public Light light;
		public Transform target;
		public float intensity;
		public float distance;
		public float acccelleration = 2;
		
		void Reset()
		{
			light = this.GetComponent<Light>();
			intensity = light.intensity;
			distance = light.range;
		}
		
	    // Start is called before the first frame update
	    void Start()
	    {
	        
	    }
	    
		float distancetmp;
	    // Update is called once per frame
	    void Update()
	    {
		    if(light & distance != 0)
		    {
		    	distancetmp = Vector3.Distance(target.position, light.transform.position);
		    	
		    	light.enabled = (distancetmp/distance < 1);
		    	
		    	if(light.enabled)
		    		light.intensity = Mathf.Min(intensity*(1-distancetmp/distance)*acccelleration,intensity);
		    }
	    }
	}

}