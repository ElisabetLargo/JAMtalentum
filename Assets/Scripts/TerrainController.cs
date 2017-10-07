﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TerrainController : MonoBehaviour {

    public static Vector3 Wind; 
    private Vector3 windDirection;
    private Vector3 currentWindDirection;
    public float windforce;
    [Range(0f,1f)]
    public float animationTime;
    public Image compass;

    void Update()
    {
        var rt = compass.GetComponent<RectTransform>();
        var a = Mathf.Rad2Deg * Mathf.Atan2(Wind.z, Wind.x);
        rt.rotation = Quaternion.Euler(Vector3.forward * a);
    }
	public void changeWindDirection(Vector3 newWindDirection)
    {
        /*  windDirection += newWindDirection;
          windDirection.Normalize();
          Debug.Log("new wind direction is " + windDirection);
          Wind = windDirection * windforce;*/
        StartCoroutine(changewindDirectionCoroutine(0.5f, newWindDirection));
      
    }

    IEnumerator changewindDirectionCoroutine( float aTime, Vector3 newWindDirection)
    {
        Vector3 cWD = windDirection;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            windDirection = Vector3.Lerp(cWD, cWD + newWindDirection, t);
            Wind = windDirection * windforce;
            yield return null;
        }
        if (windDirection.sqrMagnitude.Equals(0f))
        {
            Duckling.isRandomMove = true;
        }
        else
        {

            Duckling.isRandomMove = false;
        }
    }
}
