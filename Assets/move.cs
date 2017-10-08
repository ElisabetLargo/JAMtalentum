using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
	public float jump;
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis ("Horizontal") * speed;
		float v = Input.GetAxis ("Vertical") * speed;

		GetComponent<Rigidbody>().AddForce (new Vector3 (h, 0, v));

		if(Input.GetKeyDown(KeyCode.Space))
		{
			GetComponent<Rigidbody>().AddForce (Vector3.up * jump);
		}
	}
}
