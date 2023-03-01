/*
Brennan Hatton
2022
Circle variables for scripts that run on mono editor -> Reset()
Original made for CircleTransformChild.cs
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.UnityTools.EditorTools
{

	public class CircleVars : MonoBehaviour
	{
		public float radius = 1f;
		public float points = 10f;
		public float degrees = 360f;
		public Transform target;
	}

}