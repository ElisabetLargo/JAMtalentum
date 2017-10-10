using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duckling : MonoBehaviour {

    public static GameObject terrain;

   // [HideInInspector]
	public Rigidbody centro;
    public float ForceMod =0.2f;
	public float CollisionForce = 1000f;
	public float DuckSpeed=50;

	public AudioSource choque;
	public LayerMask terrenoLayer;
    [Range(0,10)]
    public float animMultiplyier;
    float duckRotationspeed;
 

    
    private Vector3 p,LBC;
	private Vector3 direction;
    private Vector3 duckForceMovement,auxForce;

    private float w, h, randomMovementTime;

	private bool isRandomMovement = true;
	[HideInInspector]
	public List<Rigidbody> rbList;

	private Rigidbody duckRb;
    public Animator ducklingAnimator;

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

		duckRb = centro;
		rbList = new List<Rigidbody> ();
		rbList.AddRange (this.GetComponents<Rigidbody> ());
		var rb = this.GetComponent<BoxCollider> ();

		direction = this.transform.forward;
        ducklingAnimator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (isRandomMovement) {
			RandomMovement();

		}
        //Sumatorio de fuerzas El viento + el movimiento + el rozamiento del suelo si lo hay
        //aqui asumimos que cuando existe la totalidad del rozamiento, el bicho no se mueve
        //por lo tanto al final se reduce a un modificador de [0-1], que nunca será uno sobre la velocidad que lleva.
        //no es correcto fisicamente del todo.

		duckRb.AddForce((TerrainController.Wind + duckForceMovement )* (1f-ForceMod) ,ForceMode.Force);

        float speed = duckRb.velocity.magnitude / DuckSpeed * animMultiplyier;
        if (TerrainController.Wind == Vector3.zero)
        {
            ducklingAnimator.SetFloat("AnimationSpeedMultiplier", speed);
            
        }
        else
        {

        }


        duckForceMovement = Vector3.zero;
		controlDucklingMovement();

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

	void Move(){		
		this.transform.Translate(DuckSpeed*direction*ForceMod*Time.deltaTime);
	}

	void GetRandomMovement(){

		int r = Random.Range (10, 350);
		Debug.Log ("random angle: " + r);
		direction = Quaternion.Euler (0, r, 0) *Vector3.forward;

		//duckRb.AddForce (ForceMod * newDirection*DuckSpeed);
		
	}



    ///TODO: make random movement

	void RandomMovement(){
		isRandomMovement = false;
       // Debug.Log("moving");
		int r = Random.Range (10, 350);
		Vector3 newDirection = Quaternion.Euler (0, r, 0) *Vector3.forward;
       
        ///F = V/t * m . Suponiendo ac=0 puesto que V es constante
        duckForceMovement = (newDirection * DuckSpeed) / Time.deltaTime * 10;
        auxForce = duckForceMovement;
        this.transform.LookAt(this.transform.position + duckForceMovement.normalized);
        randomMovementTime = Random.Range (1.5f, 2.5f);
        Invoke("EnableRandomMovement", randomMovementTime);
	}
	public void EnableRandomMovement(){
        ///ATENCION: esto fallaba. si se para el viento, la variable se pone a false, pero si esto estaba ya llamado, se pondrá a true igualmente
        
        isRandomMovement = TerrainController.Wind.x ==0 && TerrainController.Wind.y ==0 && TerrainController.Wind.z==0;
	}

    public void setRandomMovement(bool r)
    {
        isRandomMovement = r;
    }

    ///TODO: know if goal Reached and update gameState
    ///TODO: recovery from being blown away by the wind

	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == "Duck" || col.gameObject.tag =="Chicken") {
			Vector3 direction = this.transform.position-col.gameObject.transform.position;
			direction = Vector3.Normalize (direction);

			duckRb.AddForce (CollisionForce * direction);

			col.gameObject.GetComponent<Rigidbody> ().AddForce (CollisionForce * -direction);


		}

	}
}
