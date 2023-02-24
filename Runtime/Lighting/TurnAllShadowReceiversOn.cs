using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAllShadowReceiversOn : MonoBehaviour
{
	void Reset()
	{
		TurnOn();
	}
	
	
	public void TurnOn()
	{
		MeshRenderer[] renderers = this.GetComponentsInChildren<MeshRenderer>();
		for(int i = 0; i < renderers.Length; i++)
		{
			renderers[i].receiveShadows = true;
		}
		
	}
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
