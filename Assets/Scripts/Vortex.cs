using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vortex : MonoBehaviour {

	private float initialDistance;
	private Vector3 distanceVector;

	public float gravityForce;
	public void OnTriggerEnter(Collider other)
	{
		Transform main = other.transform.root;
		distanceVector =this.transform.position-main.position  ;
		initialDistance = distanceVector.magnitude;

		string tag = other.transform.root.tag;
		Debug.Log("Entra en Chicken" + other.name);
		if ( tag== "Duck" || tag == "Chicken")
		{
			deviateVelocity (distanceVector, other);
		}

	}
	public void OnTriggerStay(Collider other)
	{
		Transform main = other.transform.root;
		distanceVector =  this.transform.position-main.position  ;

		string tag = other.transform.root.tag;
		Debug.Log("Entra en Chicken" + other.name);
		if ( tag== "Duck" || tag == "Chicken")
		{
			deviateVelocity (distanceVector, other);
		}

	}

	private void deviateVelocity(Vector3 distanceVector,Collider other){
		var rb = other.transform.root.GetComponent<Rigidbody> ();
		float close = distanceVector.magnitude;
		rb.velocity += (close / initialDistance)*gravityForce * distanceVector.normalized;

	}
}
