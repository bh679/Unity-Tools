/*
Brennan Hatton
Has rigibody copy position of target transform;
2022
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.UnityTools
{

	[RequireComponent(typeof(Rigidbody))]
	public class FollowPhsyics : MonoBehaviour
	{
		public Transform target;
		Rigidbody rb;
		
	    // Start is called before the first frame update
	    void Start()
	    {
		    rb = this.GetComponent<Rigidbody>();
	    }
	
	    // Update is called once per frame
	    void Update()
	    {
		    rb.MovePosition(target.transform.position);
	    }
	    
		void LateUpdate()
		{
			target.SetParent(this.transform);
			target.localPosition = Vector3.zero;
		}
	}

}