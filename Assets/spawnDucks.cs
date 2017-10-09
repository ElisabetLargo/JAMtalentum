using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnDucks : MonoBehaviour {
	public GameObject[] duckschickens;
	public float spawnTime;
	public int forceRight;
	public int forceUP;
	// Use this for initialization
	void Start () {

		InvokeRepeating ("launchDuck", 2, spawnTime);

		InvokeRepeating ("launchChiken", 2, 2.08f);

	}
	
	// Update is called once per frame
	void Update () {

	}

	void launchDuck(){
		var projectile1 = Instantiate(duckschickens[Random.Range(0,duckschickens.Length)] ,
			transform.position,
			transform.rotation);
		projectile1.GetComponent<Rigidbody>().AddForce (transform.up * (forceUP + Random.Range(1f,10f)));
		projectile1.GetComponent<Rigidbody>().AddForce (transform.right * (forceRight + Random.Range(1f,10f)));

		Destroy (projectile1, 10);
	}




}
