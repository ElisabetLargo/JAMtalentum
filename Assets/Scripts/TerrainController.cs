using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TerrainController : MonoBehaviour {

    public static Vector3 Wind; 
    private Vector3 windDirection;
    private List<GameObject> Ducks;
    public float WindVelocity;
    [Range(0f,1f)]
    public float animationTime;
    public Image compass;


    void Start()
    {
        Ducks = new List<GameObject>();
        Ducks.AddRange(GameObject.FindGameObjectsWithTag("Duck"));
        Ducks.AddRange(GameObject.FindGameObjectsWithTag("Chicken"));
    }
	void Awake(){
		StopAllCoroutines ();
		Wind = Vector3.zero;
	}
    void Update()
    {
      //  var rt = compass.GetComponent<RectTransform>();
        var a = Mathf.Rad2Deg * Mathf.Atan2(Wind.z, Wind.x);
        //rt.rotation = Quaternion.Euler(Vector3.forward * a);
        Debug.DrawLine(this.transform.position, this.transform.position + Wind, Color.cyan);
    }
	public void changeWindDirection(Vector3 newWindDirection)
    {
        StartCoroutine(changewindDirectionCoroutine(0.5f, newWindDirection));
      
    }

    IEnumerator changewindDirectionCoroutine( float aTime, Vector3 newWindDirection)
    {
        Vector3 cWD = windDirection;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            windDirection = Vector3.Lerp(cWD, cWD + newWindDirection, t);
            Wind = windDirection * WindVelocity;
            yield return null;
        }
        bool randomMovement = false;
        if (Mathf.Round(Wind.sqrMagnitude)==0)
        {
            Wind = Vector3.zero;
            randomMovement = true;
        }
    //    Debug.Log("setting random movement a " + randomMovement);
        for (int i = 0; i < Ducks.Count; i++)
        {
            if (Ducks[i])
            {
                Ducks[i].GetComponent<Duckling>().setRandomMovement(randomMovement);
            }
        }

    }

    public void removeDucklingFromList(GameObject Duckling)
    {
        for (int i = 0; i < Ducks.Count; i++)
        {
            if(Ducks[i]== Duckling)
            {
                Ducks.RemoveAt(i);
                Destroy(Duckling);
                break;
            }
        }
    }
}
