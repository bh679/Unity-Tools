using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BrennanHatton.UnityTools
{

	public class UIToggleGameObjects : MonoBehaviour
	{
		public GameObject[] whenOn, whenOff;
		public Toggle toggle;
		
		void Reset()
		{
			Toggle toggle = this.GetComponent<Toggle>();
		}
		
		void Start()
		{
			toggle.onValueChanged.AddListener((bool value)=>{ ToggleObjects(value);});
		}
		
		void ToggleObjects(bool isOn)
		{
			for(int i = 0; i < whenOn.Length; i++)
			{
				whenOn[i].SetActive(isOn);
			}
			for(int i = 0; i < whenOff.Length; i++)
			{
				whenOff[i].SetActive(!isOn);
			}
		}
	}

}