using UnityEngine;
 using System.Collections;
 
 public class Child : MonoBehaviour {
 
	 public Transform parentTransform;
 
	 // If true, will attempt to scale the child accurately as the parent scales
	 // Will not be accurate if starting rotations are different or irregular
	 // Experimental
	 public bool attemptChildScale = false;
 
	 Vector3 startParentPosition;
	 Quaternion startParentRotationQ;
	 Vector3 startParentScale;
 
	 Vector3 startChildPosition;
	 Quaternion startChildRotationQ;
	 Vector3 startChildScale;
 
	 Matrix4x4 parentMatrix;
 
	 void Start () {
 
		 startParentPosition = parentTransform.position;
		 startParentRotationQ = parentTransform.rotation;
		 startParentScale = parentTransform.lossyScale;
 
		 startChildPosition = transform.position;
		 startChildRotationQ = transform.rotation;
		 startChildScale = transform.lossyScale;
 
		 // Keeps child position from being modified at the start by the parent's initial transform
		 startChildPosition = DivideVectors(Quaternion.Inverse(parentTransform.rotation) * (startChildPosition - startParentPosition), startParentScale);
	 }
     
	 public Matrix4x4 ParentMatrix(Transform parent)
	 {
	 	return Matrix4x4.TRS(parent.position, parent.rotation, parent.lossyScale);
	 }
     
	 public Vector3 ChildPosition(Matrix4x4 parentMatrix, Vector3 childPosition)
	 {
		 return parentMatrix.MultiplyPoint3x4(childPosition);
	 }
     
	 public Quaternion ChildRotation(Matrix4x4 parentMatrix, Quaternion childRotation)
	 {
		 return (parentTransform.rotation * startChildRotationQ);
		 //transform.rotation = (parentTransform.rotation * Quaternion.Inverse(startParentRotationQ)) * startChildRotationQ;
	 }
     
	 void Update () {
         
		 parentMatrix = Matrix4x4.TRS(parentTransform.position, parentTransform.rotation, parentTransform.lossyScale);
 
		 transform.position = parentMatrix.MultiplyPoint3x4(startChildPosition);
 
		 transform.rotation = (parentTransform.rotation * Quaternion.Inverse(startParentRotationQ)) * startChildRotationQ;
 
		 // Incorrect scale code; it scales the child locally not gloabally; Might work in some cases, but will be inaccurate in others
		 if (attemptChildScale) {
			 transform.localScale = Vector3.Scale(startChildScale, DivideVectors(parentTransform.lossyScale, startParentScale));
		 }
 
		 // Scale code 2; I was working on to scale the child globally through it's local scale, but turned out to be impossible using localScale
		 /*
		 Vector3 modVec;
 
		 float angleX = Mathf.Abs(Vector3.Angle(transform.right, parentTransform.right));
 
		 modVec.x = Mathf.Abs(angleX - 90) / 90;
 
		 float angleY = Mathf.Abs(Vector3.Angle(transform.up, parentTransform.up));
 
		 modVec.y = Mathf.Abs(angleY - 90) / 90;
 
		 float angleZ = Mathf.Abs(Vector3.Angle(transform.forward, parentTransform.forward));
 
		 modVec.z = Mathf.Abs(angleZ - 90) / 90;
 
		 transform.localScale = Vector3.Scale(startChildScale, Vector3.Scale(DivideVectors(parentTransform.lossyScale, startParentScale), modVec));
		 */
	 }
 
	 Vector3 DivideVectors(Vector3 num, Vector3 den) {
 
		 return new Vector3(num.x / den.x, num.y / den.y, num.z / den.z);
 
	 }
 }