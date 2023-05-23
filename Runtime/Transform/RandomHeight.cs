using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomHeight : MonoBehaviour
{
	public float interval = 0.1f;
	float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

	float y = 0;
    // Update is called once per frame
    void Update()
	{
		if(timer <= 0)
		{
			y += Random.Range(-0.25f,0.25f);
			if(y > 1) y = 1;
			if(y < 0.1f) y = 0.1f;
			
			this.transform.localScale = new Vector3(1,y,1);
			timer = interval;
		}
		timer -= Time.deltaTime;
    }
}
