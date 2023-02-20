using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BrennanHatton.UnityTools;

namespace BrennanHatton.AI
{
	
	public class SingleResponseDisplay : MonoBehaviour
	{
		public TMP_Text tmpText, promptText;
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
		
		public void SetResponse(InteractionData data, bool includePrompt = false)
		{
			interactionData = data;
			SetText(interactionData.generatedText);
			
			if(includePrompt && promptText != null)
				promptText.text = data.requestData.prompt;
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
