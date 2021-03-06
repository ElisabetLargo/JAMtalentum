﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angel : MonoBehaviour {
	public float frequency = 2.5f; // Speed of sine movement
	public float magnitude = 0.3f; // Size of sine movement

	public float speed = 1.8f;

	public float delay = 7.0f; //This implies a delay of 2 seconds.
	// Use this for initialization

	private Vector3 axis;
	void Start () {
		axis = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//transform.position = Vector3.Lerp(transform.position, end.position, Time.time);

		//transform.Translate (Vector3.up * Time.deltaTime * speed);
		axis += transform.right * Time.deltaTime * speed;
		transform.position = axis + axis * Mathf.Sin (Time.time * frequency) * magnitude;

		Destroy (gameObject, delay);
	}
} 
		





