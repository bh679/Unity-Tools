using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.UnityTools
{

	public class SetPositionBetweenPoints : MonoBehaviour
	{
		public Transform PointA;
		public Transform PointB;
		
		Vector3 dest;
		
	    // Start is called before the first frame update
	    void Start()
	    {
	        
	    }
	
	    // Update is called once per frame
	    void Update()
	    {
		    dest = (PointA.position + PointB.position) / 2;
		    transform.position = dest; 
	    }
	}

}