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
		string tag = other.transform.root.tag;
		Debug.Log("Entra en Chicken" + other.name);
        if ( tag== "Duck")
        {
            Debug.Log("pero es duck");
            gc.failedRescue();
			base.OnTriggerEnter(other);
        }
        else if (tag == "Chicken")
        {
            Debug.Log("y es tag correcto");
            gc.rescueChicken();
			base.OnTriggerEnter(other);

        }
        
    }
}
