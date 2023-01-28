using UnityEngine;

namespace BrennanHatton.UnityTools
{
	
	public class DontDestroyOnLoad : MonoBehaviour
	{
		void Awake()
		{
			DontDestroyOnLoad( this );
		}
	}
}