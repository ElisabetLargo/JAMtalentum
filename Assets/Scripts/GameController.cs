﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameController : MonoBehaviour {


    public int TotalTime, TotalChickens, TotalDucks;
    public ScoreManager sManager;

	public Text ducks,chicken;
	public GameObject Results;
	public Image[] cascos;
	public Sprite blackCasco;
	public GameObject menubtn,tryagain,next;
	private int rescuedDucks, rescuedChickens, failedRescues;
	private float currentTime;


	void Start(){
		/*rescuedChickens = rescuedDucks = 6;
		failedRescues = 0;
		TotalDucks = TotalChickens=6;*/
	}


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
           /* if(failedRescues / (TotalChickens + TotalDucks)> 0.4f)
            {
                gameOver(false);
            }
            else
            {
                gameOver(true);
            }*/

			gameOver (true);

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
		
		ducks.text = rescuedDucks + "/" + TotalDucks;
		chicken.text = rescuedChickens + "/" + TotalChickens;

		int duckProp = rescuedDucks / TotalDucks*10;
		int chickenProp = rescuedChickens / TotalChickens*10;

		int finalProp = (duckProp + chickenProp) / 2*10;

		if(finalProp>=10){
			cascos [0].sprite = blackCasco;
		}
		if(finalProp>=30){
			cascos [1].sprite = blackCasco;

		}
		if(finalProp>=50){				
			cascos [2].sprite = blackCasco;
		}
		if(finalProp>=70){				
			cascos [3].sprite = blackCasco;
			next.SetActive (true);
		}
		if(finalProp>=90){				
			cascos [4].sprite = blackCasco;
		}

		Results.SetActive (true);
		tryagain.SetActive (true);
		menubtn.SetActive (true);

    }

	public void Try(){
		int i = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (i );
	}
	public void Menu(){
		SceneManager.LoadScene (0);
	}
	public void Next(){
		int i = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (i + 1);
	}
}
