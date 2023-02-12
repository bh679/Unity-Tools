using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.AI
{
		
	public class ResponseDisplay : MonoBehaviour
	{
		public GPT3 gpt3;
		public RectTransform origin;
		public SingleResponseDisplay singleResposeDisplayPrefab;
		public List<SingleResponseDisplay> responses = new List<SingleResponseDisplay>();
		RectTransform rect;
		
		void Reset()
		{
			gpt3 = FindObjectOfType<GPT3>();
		}
		
	    // Start is called before the first frame update
	    void Start()
	    {
		    gpt3.onResults.AddListener(AddResponse);
		    rect = (RectTransform)this.transform;
	    }
	    
		public void AddResponse(InteractionData data)
		{
			//make new item
			SingleResponseDisplay response = Instantiate(singleResposeDisplayPrefab, origin.localPosition,origin.localRotation,this.transform);
			((RectTransform)response.transform).SetLocalPositionAndRotation(origin.localPosition,origin.localRotation);
			response.gameObject.SetActive(true);
			response.SetResponse(data);
			
			//move all down
			for(int i = 0; i < responses.Count; i++)
			{
				responses[i].gameObject.SetActive(true);
				responses[i].transform.position = responses[i].transform.position + Vector3.down*response.Height;
				
				//Debug.Log(i+": "+Mathf.Abs(responses[i].transform.position.y) + " > " + rect.GetHeight());
				//Debug.Log(responses[i].transform.position.y );
				
				if(responses[i].transform.position.y < 0)
				{
					responses[i].gameObject.SetActive(false);
					
					//i = responses.Count;
				}
			}
			
			
			//add to list
			
			responses.Add(response);
			
			
		}
	}

}