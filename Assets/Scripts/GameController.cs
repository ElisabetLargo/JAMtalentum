using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private float rescuedDucks, rescuedChickens,failedRescues, currentTime;
    public  float TotalTime, TotalChickens, TotalDucks;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        if (currentTime>=TotalTime )
        {
            gameOver(false);
        }
        
        if(rescuedChickens + rescuedDucks + failedRescues == TotalDucks + TotalChickens)
        {
            if(failedRescues / (TotalChickens + TotalDucks)> 0.4f)
            {
                gameOver(false);
            }
            else
            {
                gameOver(true);
            }
        }

	}
    public void rescueDuck()
    {
        rescuedDucks++;
    }

    public void rescueChicken()
    {
        rescuedChickens++;
    }
    public void failedRescue()
    {
        failedRescues++;
    }
    public void gameOver(bool win) {
        if (win)
        {

        }
        else
        {

        }

    }


}
