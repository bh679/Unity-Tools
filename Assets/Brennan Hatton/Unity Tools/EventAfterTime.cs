using UnityEngine;
using UnityEngine.Events;

[AddComponentMenu("Equal Reality/Events/Event After Time")]
public class EventAfterTime : MonoBehaviour {
	
	//Time until event is called
	public float time;
	
	//Event to be called
	public UnityEvent TimedEvent;
	
	//If we repeat the event or not
	public bool repeats = false;
	
	public bool onEnable = false;
	
	
	float timer = 0;
	bool called = false;
	public bool repeatOnEnable = false;
	
	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	void OnEnable()
	{
		if(onEnable)
		{
			if(repeatOnEnable)
				called = false;
			timer = 0;
		}
	}
	
    public void CancelTimer()
    {
        called = true;
    }
	
	// Update is called once per frame
	void Update () {
		
		timer += Time.deltaTime;
		
		if (timer >= time && called == false)
		{
			TimedEvent.Invoke();
			
			if(repeats)
			{
				timer = 0;
			}else
				called = true;
		}
	}
	
	/// <summary>
	/// Starts the timer and sets the target time
	/// </summary>
	/// <param name="_time"></param>
	public void StartTimer(float _time)
	{
		time = _time;
		timer = 0;
		called = false;
	}
}
