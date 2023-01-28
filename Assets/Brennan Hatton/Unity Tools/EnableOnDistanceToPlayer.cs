using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnDistanceToPlayer : MonoBehaviour
{
	public float distance;
	public Transform target1, target2;
	public bool target2IsMainCamera;
	
	public GameObject[] enableWhenCloser, enableWhenFurther;
	
	bool closer = false;
	
	void Reset()
	{
		target1 = this.transform;
	}
	
    // Start is called before the first frame update
    void Start()
	{
		if(target2IsMainCamera)
			target2 = Camera.main.transform;
		
		SetObjectsActive(enableWhenCloser,false);
		SetObjectsActive(enableWhenFurther,true);
	    CheckDistance();
    }

    // Update is called once per frame
    void Update()
	{
		CheckDistance();
    }
    
	void CheckDistance()
	{
		
		if(closer && Vector3.Distance(target1.position,target2.position	) > distance)
		{
			SetObjectsActive(enableWhenCloser,false);
			SetObjectsActive(enableWhenFurther,true);
			closer = false;
	    	
		}else if(!closer && Vector3.Distance(target1.position,target2.position) < distance)
		{
			SetObjectsActive(enableWhenCloser,true);
			SetObjectsActive(enableWhenFurther,false);
			closer = true;
		}
	}
    
	void SetObjectsActive(GameObject[] objects, bool active)
	{
		for(int i = 0; i < objects.Length; i++)
		{
			objects[i].SetActive(active);
		}
	}
}
