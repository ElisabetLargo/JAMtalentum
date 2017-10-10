using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TerrainModifiers : MonoBehaviour {

    public enum TypeOfTerrain { ICE,MUD,IDLE,FLOWERS }
    public TypeOfTerrain terrainType;
	private float modifier;
    private bool duckOrchicken(string t,string c, string d)
    {
        return t == c || t == d;
    }
	// Use this for initialization
	void Start () {

        //http://www.sc.ehu.es/sbweb/fisica/dinamica/rozamiento/general/rozamiento.htm
        switch (terrainType)
        {
            case TypeOfTerrain.ICE:
                modifier = -5f;
                break;
            case TypeOfTerrain.MUD:
                modifier = 0.8f;
                break;
			case TypeOfTerrain.FLOWERS:
				modifier = 0.7f;
				break;
            case TypeOfTerrain.IDLE:
                modifier = 0.5f;
                break;
            default:
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		//Debug.Log (col.name +"  " + col.transform.root.name);
		if (duckOrchicken(col.transform.root.tag, "Chicken", "Duck") ) {
			
			col.transform.root.GetComponent<Duckling>().ForceMod=modifier;

//			Debug.Log ("ha pasado "+col.transform.root.name);
		}
	}

	void OnTriggerExit(Collider col){
		if (duckOrchicken(col.transform.root.tag, "Chicken", "Duck")) {
			if (terrainType == TypeOfTerrain.ICE) {
				col.transform.root.GetComponent<Duckling> ().ForceMod = 0.2f;
			} else {
				col.transform.root.GetComponent<Duckling> ().ForceMod = 0.5f;
			}
		//	Debug.Log ("ha salido");
		}
	}
		
}
