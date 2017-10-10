using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nest : MonoBehaviour {

    protected GameController gc;
    protected TerrainController tc;

	protected AudioSource win;
	protected AudioSource fail;

   public virtual void Start()
    {
		if(this.transform.root.tag!="TutoDuck") gc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
        tc = GameObject.FindGameObjectWithTag("Terrain").GetComponent<TerrainController>();

		foreach (var a in this.GetComponents<AudioSource>()) {
			Destroy(a);
		}

		win = gameObject.AddComponent<AudioSource> ();
		fail = gameObject.AddComponent<AudioSource> ();

		win.playOnAwake = false;
		fail.playOnAwake = false;
		fail.clip =(AudioClip) Resources.Load ("Booo");
		win.clip = (AudioClip)Resources.Load ("Yay");

    }
    public virtual void removechicken(GameObject duckling) {
        tc.removeDucklingFromList(duckling);

    }

    public virtual void OnTriggerEnter(Collider other)
    {
        Debug.Log("borrando...");

		removechicken(other.transform.root.gameObject);
    }
    
}
