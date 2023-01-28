using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(CopyTransform))]
public class FindPlayerHeadForCopyTransform : MonoBehaviour
{
	static GameObject head;
	CopyTransform copy;
	public bool onEnable = false;
	
	public void Reset()
	{
		
#if UNITY_EDITOR
		
		copy = this.GetComponent<CopyTransform>();
		var newserializedObject = new SerializedObject(copy);
		newserializedObject.Update();
		SerializedProperty _targetProperty = newserializedObject.FindProperty("target"); 
		
		head = GameObject.Find("CenterEyeAnchor");
				
		// We need to tell Unity we're changing the component object too.
		Undo.RecordObject(copy, "Connected head to copytranform");

		if(head != null)
		{
			_targetProperty.objectReferenceValue = head.transform;
			newserializedObject.ApplyModifiedProperties();
		}
#endif
	}
	
	void OnEnable()
	{
		if(onEnable)
			FindHead();
	}
	
	public void FindHead()
	{
		if(head == null)
			head = GameObject.Find("CenterEyeAnchor");
		if(copy == null)
			copy = this.GetComponent<CopyTransform>();
			
		copy.target = head.transform;
	}
}
