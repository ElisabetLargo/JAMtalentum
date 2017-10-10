using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckNest : Nest {
    
    void Start()
    {
        base.Start();
    }
    public void OnTriggerEnter(Collider other)
    {
       // Debug.Log(other.tag);
		if(other.transform.root.tag == "Duck")
        {
			Debug.Log ("Entra en Ducknest con tag duck");
            gc.rescueDuck();
			base.OnTriggerEnter(other);
        }
        else if(other.transform.root.tag =="Chicken")
        {

			Debug.Log ("Entra en Ducknest con tag chicken");
            gc.failedRescue();
			base.OnTriggerEnter(other);
        }
    }
    
}
