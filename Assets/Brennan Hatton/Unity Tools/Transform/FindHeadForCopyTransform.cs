using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(CopyTransform))]
public class FindHeadForCopyTransform : MonoBehaviour
{
	public void Reset()
	{
		
		
#if UNITY_EDITOR			
		CopyTransform copy = this.GetComponent<CopyTransform>();
		var newserializedObject = new SerializedObject(copy);
		newserializedObject.Update();
		SerializedProperty _targetProperty = newserializedObject.FindProperty("target"); 
		
		Transform head = transform.parent.FindDeepChild("head");
		
		// We need to tell Unity we're changing the component object too.
		Undo.RecordObject(copy, "Connected head to copytranform");

		_targetProperty.objectReferenceValue = head;
		newserializedObject.ApplyModifiedProperties();
		//copy.target = head;
#endif
		
		
		/*DecorController myController = (DecorController)target;
		var newserializedObject = new SerializedObject(myController);
		newserializedObject.Update();
		SerializedProperty _featuresProperty = newserializedObject.FindProperty("CAKE"); 
		_featuresProperty.stringValue = "BANANA";
		newserializedObject.ApplyModifiedProperties();*/
	}
	
}
