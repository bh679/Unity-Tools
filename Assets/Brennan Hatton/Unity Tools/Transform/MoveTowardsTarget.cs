using UnityEngine;
using UnityEngine.Events;

namespace Generic.Move
{
	
	[AddComponentMenu("Equal Reality/Move/Move Towards Target")]
public class MoveTowardsTarget : MonoBehaviour {

	//This is the object we are following
	[Tooltip("Drag the object to follow here")]
	public Transform Target;

        //The speed moving towards the object
        public float speed;

        //The speed moving towards the object
        public float acceleration = 0;

        //The speed moving towards the object
		public float jerk = 0;
	        
		public bool useRange = false;

        //How close the target needs to be before it starts to follow
        [Tooltip("How close the target needs to be before it is followed")]
	    public float maximumRange;

	    //How close to the target it will get
	    [Tooltip("How close it will get to the target before stopping")]
	    public float minimumRange;

	public UnityEvent eventOnComplete = new UnityEvent();
		public bool eventOnCompleteOnlyOnce = true;
		public bool ResetOnEnable = true;
		protected bool completed = false;
		Vector3 OriginalPosition;

	    // Use this for initialization
	
		void Start()
		{
			//OriginalPosition = this.transform.position;
		}
		void OnEnable () {
			completed = false;
			//this.transform.position = OriginalPosition;
	    }

        public void SetTarget(Transform target)
        {
                Target = target;
        }
        

        public void SetSpeed(float _speed)
        {
            speed = _speed;
        }

        public void SetAcceleration(float _acceleration)
        {
            acceleration = _acceleration;
        }
        
	public void ReverseAcceleration(bool resetSpeed)
		{
			acceleration = -acceleration;
			
			if(resetSpeed)
				speed = 0;
		}

        public void SetJerk(float _jerk)
        {
            jerk = _jerk;
        }

        // Update is called once per frame
        void Update () {

            acceleration += jerk * Time.deltaTime;
            speed += acceleration * Time.deltaTime;

            //This adjusts the speed based on the framefrate (also know as clockspeed) of the computer
            float step = speed * Time.deltaTime;//deltaTime is the difference in time between each frame. You could also desribe it as how long each frame takes.

		//If the target is close enough
	        if (!useRange || Vector3.Distance (this.transform.position, Target.position) <= maximumRange) 
		{
			//if the target is not too close
		        if (!useRange || Vector3.Distance (this.transform.position, Target.position) >= minimumRange) 
			{
					if ((Vector3.Distance (this.transform.position, Target.position) <= step)) {
						this.transform.position = Target.position;

						if (!completed || !eventOnCompleteOnlyOnce) {
							eventOnComplete.Invoke ();
							completed = true;
						}
					}
                    else
                	//Move towards the target
                        this.transform.position = Vector3.MoveTowards (this.transform.position, Target.position, step);
			}
		}
	}
}

}