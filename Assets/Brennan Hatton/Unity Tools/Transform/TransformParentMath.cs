using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformParentMath : MonoBehaviour
{
    
     
	public static Matrix4x4 ParentMatrix(Transform parent)
	{
		return Matrix4x4.TRS(parent.position, parent.rotation, parent.lossyScale);
	}
     
	public static Vector3 ChildPosition(Matrix4x4 parentMatrix, Vector3 childPosition)
	{
		return parentMatrix.MultiplyPoint3x4(childPosition);
	}
     
	public static Quaternion ChildRotation(Quaternion parentRotation, Quaternion childRotation)
	{
		return (parentRotation * childRotation);
		//transform.rotation = (parentTransform.rotation * Quaternion.Inverse(startParentRotationQ)) * startChildRotationQ;
	}
}
