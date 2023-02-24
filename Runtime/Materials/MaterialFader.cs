using UnityEngine;

namespace BrennanHatton.UnityTools
{

	public class MaterialFader : MonoBehaviour {
		
		Renderer myRenderer;
		
		public bool fadeOnDistance;
		public Transform target1, target2;
		public float maxVal = 100, minVal = 0;
		
		// Use this for initialization
		void Start () {
			myRenderer = this.GetComponent<Renderer>();
		}
		
		float distance;
		// Update is called once per frame
		void Update () {
			if(fadeOnDistance)
			{
				distance = Vector3.Distance(target1.position, target2.position);
				if (distance <= minVal)
					distance = 0;
				else if (distance >= maxVal)
					distance = maxVal;
				
				
				SetFadeAll(1 - (distance / maxVal));
			}
		}
		
		public void SetFadeAll(float fadeValue)
		{
			for(int i =0 ; i < myRenderer.materials.Length;i++)
			{
				myRenderer.materials[i].color = new Color(myRenderer.materials[i].color.r, myRenderer.materials[i].color.g, myRenderer.materials[i].color.b, fadeValue);
			}
		}
		
	}

}