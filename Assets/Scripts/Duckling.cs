using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duckling : MonoBehaviour {

    public static GameObject terrain;

    //[HideInInspector]
    public float ForceMod =0.2f;

    Vector3 duckForceMovement;

	public float DuckSpeed=50;
    
    private Vector3 p,LBC;
    private float w, h;
    
	public static bool isRandomMove = true;

	private Rigidbody duckRb;


    void OnDrawGizmos()
    {
       /* Gizmos.DrawSphere(LBC, 1);
        Gizmos.DrawCube(LBC, new Vector3(w, 0.1f, h));
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(p,1);*/

    }
	// Use this for initialization
	void Start () {
        if (!terrain)
        {
            terrain = GameObject.FindGameObjectWithTag("Terrain");
        }
		duckRb =this.transform.GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(isRandomMove);
		if (isRandomMove) {
			RandomMovement ();
		}
        controlDucklingMovement();
        //Sumatorio de fuerzas El viento + el movimiento + el rozamiento del suelo si lo hay
        duckRb.AddForce(TerrainController.Wind + duckForceMovement - (duckForceMovement * (1f-ForceMod)) ,ForceMode.Force);
        duckForceMovement = Vector3.zero;
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

	void RandomMovement(){
		isRandomMove = false;
        Debug.Log("moving");
		int r = Random.Range (10, 350);
		Vector3 newDirection = Quaternion.Euler (0, r, 0) *Vector3.forward;
        ///F = V/t * m . Suponiendo ac=0 puesto que V es constante
		//duckRb.AddForce ( (newDirection*DuckSpeed)/Time.deltaTime * duckRb.mass);
        duckForceMovement = (newDirection * DuckSpeed) / Time.deltaTime * duckRb.mass;

        Invoke ("EnableRandomMovement", 2f);
	}
	void EnableRandomMovement(){
		isRandomMove = true;
	}


    ///TODO: make random movement
    ///TODO: know if goal Reached and update gameState
    ///TODO: recovery from being blown away by the wind
    ///TODO: rebounds from ducklings
}
