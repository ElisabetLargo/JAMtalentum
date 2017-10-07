using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainModifiers : MonoBehaviour {

	public float modifier;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == "Duck") {

			col.gameObject.GetComponent<Duckling>().ForceMod=modifier;
			Debug.Log ("ha pasado");
		}
	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Duck") {

			col.gameObject.GetComponent<Duckling>().ForceMod=1;
			Debug.Log ("ha salido");
		}
	}

}
