using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.UnityTools
{
	public class Shuffle : MonoBehaviour
	{
	
		/// <summary>
		/// Shuffle the array.
		/// </summary>
		/// <typeparam name="T">Array element type.</typeparam>
		/// <param name="array">Array to shuffle.</param>
		public static T[] ShuffleArray<T>(T[] array)
		{
		
			for (int i = array.Length; i > 1; i--)
			{
				// Pick random element to swap.
				int j = Random.Range(0, i); // 0 <= j <= i-1
				// Swap.
				T tmp = array[j];
				array[j] = array[i - 1];
				array[i - 1] = tmp;
			}
			return array;
		}
	}

}
