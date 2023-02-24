/*
Brennan Hatton
Has this game object face the relative direction of the target rigibody velocity
2021
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.UnityTools
{

	public class FaceRigidbodyForward : MonoBehaviour
	{
		public Rigidbody rb;
		
		void Reset(){
			rb = this.GetComponent<Rigidbody>();
		}
		
	    // Start is called before the first frame update
	    void Start()
		{
			if(rb == null)
				rb = this.GetComponent<Rigidbody>();
	    }
	
	    // Update is called once per frame
	    void Update()
	    {
		    this.transform.forward = rb.velocity.normalized;
	    }
	}

}