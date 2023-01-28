using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
	/// <summary>
	/// The object to look at
	/// </summary>
	Transform _camera;

	/// <summary>
	/// If true will Slerp to the object. If false will use transform.LookAt
	/// </summary>
	public bool UseLerp = true;

	/// <summary>
	/// Slerp speed if UseLerp is true
	/// </summary>
	public float Speed = 20f;

	public bool UseUpdate = false;
	public bool UseLateUpdate = true;


	
	void Start()
	{
		initialize();
	}
	
	public void initialize()
	{
		GameObject cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
		_camera = cameraObject.transform;
	}
	
	
	void Update() {
		if (UseUpdate) {
			lookAt();
		}
	}

	void LateUpdate() {
		if (UseLateUpdate) {
			lookAt();
		}
	}

	void lookAt() {

		if (_camera != null) {

			if (UseLerp) {
				Quaternion rot = Quaternion.LookRotation(_camera.position - transform.position);

				transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * Speed);
			}
			else {
				transform.LookAt(_camera, transform.forward);
			}
		}
	}
}
