using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnDucks : MonoBehaviour {
	public GameObject duck;
	public float spawnTime;
	public int force;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("launch", 2, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void launch(){
		var projectile = Instantiate(duck,
			transform.position,
			transform.rotation);
		projectile.GetComponent<Rigidbody>().AddForce (transform.up * (force + Random.Range(1f,10f)));
		projectile.GetComponent<Rigidbody>().AddForce (transform.right * (force+ Random.Range(1f,10f)));

		Destroy (projectile, 5);
	}


}
