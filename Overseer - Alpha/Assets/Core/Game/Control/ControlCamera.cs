using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControlCamera : MonoBehaviour {

	public Transform mainCamera;
	public float rotateSpeed;
	public float zoomSpeed;

	void Update () 
	{
		transform.Rotate(Vector3.down*rotateSpeed*Input.GetAxis("Horizontal")*Time.deltaTime);
		mainCamera.RotateAround(transform.position,mainCamera.right,rotateSpeed*Input.GetAxis("Vertical")*Time.deltaTime);
		mainCamera.position = Vector3.MoveTowards(mainCamera.position,transform.position,zoomSpeed*Input.GetAxis("Mouse ScrollWheel")*Time.deltaTime);
	}
}
