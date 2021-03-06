﻿using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	public float speed = 2.0f;
	public float mouseSensitivity = 60f;
	public float verticalRange = 80f;

	private Vector3 movement;
	private Rigidbody playerRB;
	private float rotV = 0f;

	// Use this for initialization
	void Awake () {
		playerRB = GetComponent<Rigidbody> ();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
	
		Move (h,v);
	}

	void Move (float h, float v) {
		float rotH = Input.GetAxis ("Mouse X") * mouseSensitivity;


		rotV -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		rotV = Mathf.Clamp(rotV, -verticalRange, verticalRange);

		Camera.main.transform.localRotation = Quaternion.Euler(rotV,0,0);


		transform.Rotate(0,rotH,0);

		movement.Set (h, 0f, v);
		movement = transform.rotation * movement.normalized * speed * Time.deltaTime;

		playerRB.MovePosition (transform.position + movement);
	}
}
	