using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private int rescuedDucks, rescuedChickens, failedRescues;
    private float currentTime;
    public int TotalTime, TotalChickens, TotalDucks;
    public ScoreManager sManager;

	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        sManager.UpdateTime(TotalTime - currentTime);
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
        sManager.updatebirds(ref rescuedDucks, ref TotalDucks, true);
    }

    public void rescueChicken()
    {
        rescuedChickens++;
        sManager.updatebirds(ref rescuedChickens, ref TotalChickens, false);
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
            Debug.Log("perdiste");
        }

    }


}
