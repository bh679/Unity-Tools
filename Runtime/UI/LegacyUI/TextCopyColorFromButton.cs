using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BrennanHatton.UnityTools.LegacyUI
{
	public class TextCopyColorFromButton : MonoBehaviour
	{
		public Button buttonToCopy;
		public Text myText;
		public bool onUpdate, r,g,b,a;
		
		void Reset()
	    {
		    myText = this.GetComponent<Text>();
	    }
	
	    // Update is called once per frame
	    void Update()
	    {
		    if(onUpdate)
			    ChangeColor();
	    }
	    
		public void ChangeColor()
		{
			
			if(r && g && b && a)
				myText.color = buttonToCopy.GetComponent<Material>().color;
			else
				myText.color = new Color(
				
				r?buttonToCopy.GetComponent<Material>().color.r:myText.color.r,
				
				g?buttonToCopy.GetComponent<Material>().color.g:myText.color.g,
				
				b?buttonToCopy.GetComponent<Material>().color.b:myText.color.b,
				
				a?buttonToCopy.GetComponent<Material>().color.a:myText.color.a);
			
		}
	}
}