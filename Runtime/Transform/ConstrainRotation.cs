using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.UnityTools
{

	public class ConstrainRotation : MonoBehaviour
	{
		
		public bool useLateUpdate = true;
		
		public Vector2 AngleLimitX = new Vector2(-10,10);
		float angleX;
	    
		void LateUpdate()
		{
			angleX = transform.rotation.eulerAngles.x;
			
			if(angleX > 180)
				angleX -= 360;
				
			
			angleX = Mathf.Clamp(angleX, AngleLimitX[0], AngleLimitX[1]);
			
			transform.eulerAngles = new Vector3(angleX, transform.eulerAngles.y, transform.eulerAngles.z);
		}
	}
}