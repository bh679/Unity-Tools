using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BrennanHatton.AI
{
	
	public class SingleResponseDisplay : MonoBehaviour
	{
		public TMP_Text tmpText;
		public float paddingTop, lineHeight, paddingBottom;
		public InteractionData interactionData;
		float height;
		public float Height{get {return height;}}
		
		void Reset()
		{
			tmpText = this.GetComponentInChildren<TMP_Text>();
			paddingTop = -tmpText.rectTransform.rect.position.y;
			lineHeight = tmpText.fontSize*1.15f;
			paddingBottom = ((RectTransform)this.transform).rect.height - (paddingTop+lineHeight);
		}
		
		public void SetResponse(InteractionData data)
		{
			interactionData = data;
			SetText(interactionData.generatedText);
		}
		
		void SetText(string text)
		{
			if(text == tmpText.text)
				return;
				
			Debug.Log(tmpText.textInfo);
			tmpText.SetText(text);
			Debug.Log(tmpText.textInfo);
			tmpText.ForceMeshUpdate();
			
			StartCoroutine(adjustheight());
			
		}
		
		IEnumerator adjustheight()
		{
			while(tmpText.textInfo == null)
				yield return new WaitForEndOfFrame();
			
			height = paddingTop + 
				tmpText.textInfo.lineCount*lineHeight+
				paddingBottom;
				
			((RectTransform)this.transform).SetHeight(height);
		}
	}

}