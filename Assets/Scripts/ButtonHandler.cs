using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonHandler : MonoBehaviour {

    private GameObject terrain;
    private TerrainController tc;

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
//        Debug.Log(Vector3.forward * (activated ? -1 : 1));
        tc.changeWindDirection(Vector3.forward * (activated?-1:1));
       
    }
    void southClick(bool activated)
    {
        northClick(!activated);
    }
    void eastClick(bool activated)
    {
		tc.changeWindDirection(Vector3.right * (activated ? -1 : 1));

    }
    void westClick(bool activated)
    {
        eastClick(!activated);
    }
}
