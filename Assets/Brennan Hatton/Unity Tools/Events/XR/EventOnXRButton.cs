using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
 
namespace Zenva.VR
{
	public class EventOnXRButton : MonoBehaviour
	{
		static readonly Dictionary<string, InputFeatureUsage<bool>> availableButtons = new Dictionary<string, InputFeatureUsage<bool>>
		{
			{"triggerButton", CommonUsages.triggerButton },
			{"thumbrest", CommonUsages.thumbrest },
			{"primary2DAxisClick", CommonUsages.primary2DAxisClick },
			{"primary2DAxisTouch", CommonUsages.primary2DAxisTouch },
			{"menuButton", CommonUsages.menuButton },
			{"gripButton", CommonUsages.gripButton },
			{"secondaryButton", CommonUsages.secondaryButton },
			{"secondaryTouch", CommonUsages.secondaryTouch },
			{"primaryButton", CommonUsages.primaryButton },
			{"primaryTouch", CommonUsages.primaryTouch },
        };
 
		public enum ButtonOption
		{
			triggerButton,
			thumbrest,
			primary2DAxisClick,
			primary2DAxisTouch,
			menuButton,
			gripButton,
			secondaryButton,
			secondaryTouch,
			primaryButton,
			primaryTouch
		};
 
		[Tooltip("Input device role (left or right controller)")]
		public InputDeviceRole deviceRole;
       
		[Tooltip("Select the button")]
		public ButtonOption button;
 
		[Tooltip("Event when the button starts being pressed")]
		public UnityEvent OnPress;
 
		[Tooltip("Event when the button is released")]
		public UnityEvent OnRelease;
 
		// to check whether it's being pressed
		public bool IsPressed { get; private set; }
 
		// to obtain input devices
		List<InputDevice> inputDevices;
		bool inputValue;
 
		InputFeatureUsage<bool> inputFeature;
 
		void Awake()
		{
			// get label selected by the user
			string featureLabel = Enum.GetName(typeof(ButtonOption), button);
 
			// find dictionary entry
			availableButtons.TryGetValue(featureLabel, out inputFeature);
           
			// init list
			inputDevices = new List<InputDevice>();
		}
 
		void Update()
		{
			InputDevices.GetDevicesWithRole(deviceRole, inputDevices);
 
			for (int i = 0; i < inputDevices.Count; i++)
			{
				if (inputDevices[i].TryGetFeatureValue(inputFeature,
					out inputValue) && inputValue)
				{
					// if start pressing, trigger event
					if (!IsPressed)
					{
						IsPressed = true;
						OnPress.Invoke();
					}
				}
 
				// check for button release
				else if (IsPressed)
				{
					IsPressed = false;
					OnRelease.Invoke();
				}
			}
		}
	}
}