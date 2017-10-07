using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainModifiers : MonoBehaviour {

    public enum TypeOfTerrain { ICE,MUD,IDLE }
    public TypeOfTerrain terrainType;
	private float modifier;
	// Use this for initialization
	void Start () {
        //http://www.sc.ehu.es/sbweb/fisica/dinamica/rozamiento/general/rozamiento.htm
        switch (terrainType)
        {
            case TypeOfTerrain.ICE:
                modifier = 0.98f;
                break;
            case TypeOfTerrain.MUD:
                modifier = 0.1f;
                break;
            case TypeOfTerrain.IDLE:
                modifier = 0.9f;
                break;
            default:
                break;
        }
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

			col.gameObject.GetComponent<Duckling>().ForceMod=0.2f;
			Debug.Log ("ha salido");
		}
	}
		
}
