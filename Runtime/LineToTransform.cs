using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.UnityTools {

	/// <summary>
	/// Draw a LineRenderer from the Transform to another. Specified in localSpace.
	/// </summary>
	public class LineToTransform : MonoBehaviour {
		public Transform ConnectTo;
		LineRenderer line;
		
		[Range(0.0f, 1.0f)]
		public float startOffset = 0, endOffset = 1;

		void Start() {
			line = GetComponent<LineRenderer>();
			if(line) {
				line.useWorldSpace = false;
			}
		}
		void LateUpdate() {
			line.SetPosition(0, transform.InverseTransformPoint(ConnectTo.position)*startOffset/1f);
			line.SetPosition(1, transform.InverseTransformPoint(ConnectTo.position)*endOffset/1f);
		}
	}
}

