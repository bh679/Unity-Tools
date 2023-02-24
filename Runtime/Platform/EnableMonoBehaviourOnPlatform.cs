using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using BNG;

namespace BrennanHatton
{
	//[RequireComponent(typeof(VREmulator))]
	public class EnableMonoBehaviourOnPlatform : MonoBehaviour
	{
		public List<RuntimePlatform> platform;
		public MonoBehaviour monoBehaviour;
		
		void Reset()
		{
			platform = new List<RuntimePlatform>();
			platform.Add(RuntimePlatform.WindowsEditor);
			platform.Add(RuntimePlatform.WindowsPlayer);
			platform.Add(RuntimePlatform.OSXEditor);
			platform.Add(RuntimePlatform.OSXPlayer);
			
			//monoBehaviour = this.GetComponent<VREmulator>();
		}
		
	    // Start is called before the first frame update
	    void Start()
		{
			
			monoBehaviour.enabled = (
				CheckPlatform(platform)
			);
		    
		}
	    
		static bool CheckPlatform(List<RuntimePlatform> _platform)
		{
			for(int i = 0; i < _platform.Count; i++)
			{
				if(Application.platform == _platform[i])
					return true;
			}
			
			return false;
		}
	}


}