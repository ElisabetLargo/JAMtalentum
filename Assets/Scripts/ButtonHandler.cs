using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonHandler : MonoBehaviour {

	public Animator animW, animE, animS, animN;
    private GameObject terrain;
    private TerrainController tc;

	private enum COORDS{SOUTH,NORTH,EAST,WEST};

    public Toggle N,S,E,W;
	// Use this for initialization
	void Start () {
        if (!terrain)
        {
            terrain = GameObject.FindGameObjectWithTag("Terrain");
            tc = terrain.GetComponent<TerrainController>();
        }
        N.onValueChanged.AddListener(northClick);
        S.onValueChanged.AddListener(southClick);
        E.onValueChanged.AddListener(eastClick);
        W.onValueChanged.AddListener(westClick);
    }
	
    void northClick(bool activated)
    {
        Debug.Log(Vector3.forward * (activated ? -1 : 1));
        tc.changeWindDirection(Vector3.forward * (activated?-1:1));
		animateBlower (COORDS.NORTH, activated);
       
    }
    void southClick(bool activated)
    {
        //northClick(!activated);
		tc.changeWindDirection(-1*Vector3.forward * (activated?-1:1));

		animateBlower (COORDS.SOUTH, activated);

    }
    void eastClick(bool activated)
    {
        Debug.Log(Vector3.right * (activated ? -1 : 1));
        tc.changeWindDirection(Vector3.right * (activated ? -1 : 1));
		animateBlower (COORDS.EAST, activated);

    }

    void westClick(bool activated)
    {
        //eastClick(!activated);
		Debug.Log(Vector3.right * (activated ? -1 : 1));
		tc.changeWindDirection(-1*Vector3.right * (activated ? -1 : 1));
		animateBlower (COORDS.WEST, activated);

    }

	void animateBlower(COORDS c, bool b){
	
		Debug.Log ("animate " + c + " " + b);
		switch (c) {

		case COORDS.EAST:
			animE.SetBool ("blow", b);
			break;

		case COORDS.NORTH:
			animN.SetBool ("blow", b);

			break;

		case COORDS.SOUTH:
			animS.SetBool ("blow", b);

			break;

		case COORDS.WEST:
			animW.SetBool ("blow", b);
 
			break;

		}
	}
		
}
