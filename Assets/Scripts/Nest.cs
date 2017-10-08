using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nest : MonoBehaviour {

    protected GameController gc;
    protected TerrainController tc;

   public virtual void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        tc = GameObject.FindGameObjectWithTag("Terrain").GetComponent<TerrainController>();

    }
    public virtual void removechicken(GameObject duckling) {
        tc.removeDucklingFromList(duckling);

    }

    public virtual void OnTriggerEnter(Collider other)
    {
        Debug.Log("borrando...");
        removechicken(other.gameObject);
    }
    
}
