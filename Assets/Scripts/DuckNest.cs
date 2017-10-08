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
        Debug.Log(other.tag);
        if(other.tag == "Duck")
        {
            gc.rescueDuck();
            Destroy(other.gameObject);
        }
        else if(other.tag =="Chicken")
        {
            gc.failedRescue();
            Destroy(other.gameObject);
        }
    }
    
}
