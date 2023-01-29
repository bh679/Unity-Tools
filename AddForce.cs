using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.UnityTools
{
	
	[RequireComponent(typeof(Rigidbody))]
	public class AddForce : MonoBehaviour
	{
		public Vector3 force = Vector3.up*-1f;
		public bool up;
		Rigidbody rb;
		
	    // Start is called before the first frame update
	    void Start()
		{
			rb = this.GetComponent<Rigidbody>();
	    }
	
	    // Update is called once per frame
	    void Update()
		{
			if(up)
				rb.AddForceAtPosition(force, transform.position+Vector3.up*3f);
			else
				rb.AddForce(force);
	    }
	}

}