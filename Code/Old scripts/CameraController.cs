using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;

	public Vector3 offset;
	public float zoomSpeed = 4f;
	public float minZoom = 2f;
	public float maxZoom = 8f;

	public float pitch = 2f;

	public float yawSpeed = 100f;

	private float currentZoom = 6f;
	private float currentYaw = 0f;

	void Update ()
	{
		currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
		currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

		currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
	}

	void LateUpdate ()
	{
		transform.position = target.position - offset * currentZoom;
		transform.LookAt(target.position + Vector3.up * pitch);

		transform.RotateAround(target.position, Vector3.up, currentYaw);
	}

}
