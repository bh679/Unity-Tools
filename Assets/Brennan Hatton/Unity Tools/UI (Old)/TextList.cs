using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextList : MonoBehaviour
{
	public List<string> listOfText = new List<string>();
	public Text[] texts;
	public Text idText;
	public int i = 0;
	
    // Start is called before the first frame update
    void Start()
	{
		SetText(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
	public void SetNextText()
	{
		i++;
		
		if(i >= listOfText.Count)
			i = 0;
			
		SetText(i);
	}
    
	public void SetPreviousText()
	{
		i--;
		
		if(i < 0)
			i = listOfText.Count - 1;
			
		SetText(i);
	}
	
	public void SetText(int id)
	{
		i = id;
		
		for(int x =0; x < texts.Length; x++)
			texts[x].text = listOfText[i];
		
		if(idText != null)
			idText.text = (i+1).ToString() + "/"+ listOfText.Count.ToString();
	}
}
