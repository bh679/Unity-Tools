using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[AddComponentMenu("Brennan Hatton/Input/Key Press Event")]
public class OnKeyPress : MonoBehaviour {

    public UnityEvent myEvent;
    public Key key;

    public enum PressType
    {
        Down = 0,
        Hold = 1,
        Up = 2
    }

    public PressType pressType = PressType.Down;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (pressType == PressType.Down)
        {
	        if (Keyboard.current[key].wasPressedThisFrame)
            {
                myEvent.Invoke();
            }
        }
        else
        if (pressType == PressType.Hold)
        {
	        if (Keyboard.current[key].isPressed)
            {
                myEvent.Invoke();
            }
        }
        else
        if (pressType == PressType.Up)
        {
	        if (Keyboard.current[key].wasReleasedThisFrame)
            {
                myEvent.Invoke();
            }
        }
    }
}
