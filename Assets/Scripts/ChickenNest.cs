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
        if (other.tag == "Duck")
        {
            gc.failedRescue();
            base.OnTriggerEnter(other);
        }
        else if (other.tag == "Chicken")
        {
            Debug.Log("tag correcto");
            gc.rescueChicken();
            base.OnTriggerEnter(other);

        }
        
    }
}
