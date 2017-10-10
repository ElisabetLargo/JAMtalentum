using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenNest : Nest {

    void Start()
    {
        base.Start();
    }
    public override void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entra en Chicken");
		Debug.Log ("tag es " + other.gameObject.name);
        if (other.tag == "Duck")
        {
            Debug.Log("es duck");
            gc.failedRescue();
            base.OnTriggerEnter(other);
        }
        else if (other.tag == "Chicken")
        {
            Debug.Log("tag correcto");
            gc.rescueChicken();
            base.OnTriggerEnter(other);

        }
		else if(other.tag=="TutoDuck"){
			Debug.Log("tag tuto");

			GameObject.FindGameObjectWithTag("Canvas").GetComponent<TutorialController>().Win();
			base.OnTriggerEnter(other);

		}
        
    }
}
