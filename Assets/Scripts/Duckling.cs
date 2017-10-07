using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duckling : MonoBehaviour {

    public static GameObject terrain;


    public float ForceMod;
    
    private Vector3 p,LBC;
    private float w, h;

	private bool isRandomMove = true;

	private Rigidbody duckRb;


    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(LBC, 1);
        Gizmos.DrawCube(LBC, new Vector3(w, 0.1f, h));
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(p,1);

    }
	// Use this for initialization
	void Start () {
        if (!terrain)
        {
            terrain = GameObject.FindGameObjectWithTag("Terrain");
        }
	//	duckRb =this.transform.GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
		if (isRandomMove) {
			//RandomMovement ();
		}
        controlDucklingMovement();
        //var r =this.transform.GetComponent<Rigidbody>();
       // r.AddForce((Vector3.right + Vector3.up) * 100);
	}

    void controlDucklingMovement()
    {
        p = this.transform.position;

        LBC = terrain.transform.position- new Vector3(terrain.transform.localScale.x,0, terrain.transform.localScale.z) * 5;

        w = terrain.transform.localScale.x*10f;
        h = terrain.transform.localScale.z*10f;


        p = new Vector3((p.x -LBC.x)/w, p.y ,(p.z-LBC.z)/h);
        p.x = p.x - Mathf.Floor(p.x);
        p.z = p.z - Mathf.Floor(p.z);

        p.x *= w;
        p.z *= h;
        p.x += LBC.x;
        p.z += LBC.z;
       // Debug.Log(p);
        this.transform.position = p;
       

    }

	/*void RandomMovement(){
		isRandomMove = false;

		int r = Random.Range (10, 350);
		Vector3 newDirection = Quaternion.Euler (0, r, 0) *Vector3.forward;
		duckRb.AddForce (ForceMod * newDirection);

		Invoke ("EnableRandomMovement", 2f);
	}
	void EnableRandomMovement(){
		isRandomMove = true;
	}*/


    ///TODO: make random movement
    ///TODO: know if goal Reached and update gameState
    ///TODO: recovery from being blown away by the wind
    ///TODO: rebounds from ducklings
}
