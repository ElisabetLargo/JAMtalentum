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
		
		if(other.transform.root.tag == "Duck")
		{
			if (!other.transform.root.GetComponent<Duckling> ().detected) {
				other.transform.root.GetComponent<Duckling> ().detected = true;
				Debug.Log ("Entra en Ducknest con tag duck");
				gc.failedRescue ();
				base.OnTriggerEnter (other);
				fail.Play ();
			}
		}
		else if(other.transform.root.tag =="Chicken")
		{
			if (!other.transform.root.GetComponent<Duckling> ().detected) {
				other.transform.root.GetComponent<Duckling> ().detected = true;
				Debug.Log ("Entra en Ducknest con tag chicken");
				gc.rescueChicken ();
				base.OnTriggerEnter (other);
				win.Play ();
			}
		}
        
    }
}
