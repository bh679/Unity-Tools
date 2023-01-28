using UnityEngine;
using UnityEngine.Events;

namespace Generic.Move
{
	[AddComponentMenu("SiliconVagabond/Move/Move Target Towards Target")]
    public class MoveTargetTowardsTarget : MonoBehaviour {


        //This is the object we are following
        [Tooltip("Drag the object to follow here")]
        public Transform TargetTomove;

        //This is the object we are following
        [Tooltip("Drag the object to follow here")]
        public Transform MoveTowardsTarget;

        //The speed moving towards the object
        public float speed;

        //The speed moving towards the object
        public float acceleration = 0;

        //The speed moving towards the object
	    public float jerk = 0;
        
	    public bool usingRange = false;

        //How close the target needs to be before it starts to follow
        [Tooltip("How close the target needs to be before it is followed")]
        public float maximumRange;

        //How close to the target it will get
        [Tooltip("How close it will get to the target before stopping")]
	    public float minimumRange;
        
	    public UnityEvent onFinished = new UnityEvent();
	    public bool CallOnFinishedOnlyOnce = true;
	    bool called = false;


        // Use this for initialization
        void Start()
        {

        }

        public void SetTarget(Transform target)
        {
            MoveTowardsTarget = target;
        }

        public void SetSpeed(float _speed)
        {
            speed = _speed;
        }

        public void SetAcceleration(float _acceleration)
        {
            acceleration = _acceleration;
        }

        public void SetJerk(float _jerk)
        {
            jerk = _jerk;
        }

        // Update is called once per frame
        void Update()
        {

            acceleration += jerk * Time.deltaTime;
            speed += acceleration * Time.deltaTime;

            //This adjusts the speed based on the framefrate (also know as clockspeed) of the computer
            float step = speed * Time.deltaTime;//deltaTime is the difference in time between each frame. You could also desribe it as how long each frame takes.

            //If the target is close enough
	        if (!usingRange || Vector3.Distance(TargetTomove.transform.position, MoveTowardsTarget.position) <= maximumRange)
            {
                //if the target is not too close
		        if (!usingRange || Vector3.Distance(TargetTomove.transform.position, MoveTowardsTarget.position) >= minimumRange)
                {
			        if ((Vector3.Distance(TargetTomove.transform.position, MoveTowardsTarget.position) <= step))
			        {
			        	if((CallOnFinishedOnlyOnce && !called) || !CallOnFinishedOnlyOnce)
			        	{
			        		called = true;
			        		onFinished.Invoke();
			        	}
			        	
				        TargetTomove.transform.position = MoveTowardsTarget.position;
			        }
                    else
                        //Move towards the target
                        TargetTomove.transform.position = Vector3.MoveTowards(TargetTomove.transform.position, MoveTowardsTarget.position, step);
                }
            }
        }
    }

}