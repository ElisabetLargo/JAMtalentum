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
		Debug.Log(other.name);

		if(other.transform.root.tag == "Duck")
        {
			if (!other.transform.root.GetComponent<Duckling> ().detected) {
				other.transform.root.GetComponent<Duckling> ().detected = true;
				Debug.Log ("Entra en Ducknest con tag duck");
				gc.rescueDuck ();
				base.OnTriggerEnter (other);
				win.Play ();
			}
        }
        else if(other.transform.root.tag =="Chicken")
        {
			if (!other.transform.root.GetComponent<Duckling> ().detected) {
				other.transform.root.GetComponent<Duckling> ().detected = true;
				Debug.Log ("Entra en Ducknest con tag chicken");
				gc.failedRescue ();
				base.OnTriggerEnter (other);
				fail.Play ();
			}
        }
		else if(other.transform.root.tag =="TutoDuck")
		{
			Debug.Log ("ñilhfuouhfksduhkf");
			GameObject.FindGameObjectWithTag ("Canvas").GetComponent<TutorialController> ().Win ();
		}
    }
    
}
