using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameController : MonoBehaviour {


    public int TotalTime, TotalChickens, TotalDucks;
    public ScoreManager sManager;

	public AudioSource soundVictory,soundFail;

	public Text ducks,chicken;
	public GameObject Results;
	public Image[] cascos;
	public Sprite blackCasco;
	public GameObject menubtn,tryagain,next;
	private int rescuedDucks, rescuedChickens, failedRescues;
	private float currentTime;
	private bool end=false;


	void Start(){
		/*rescuedChickens = rescuedDucks = 6;
		failedRescues = 0;
		*/
		//TotalDucks = TotalChickens=6;

		sManager.updatebirds( rescuedChickens,  TotalChickens, false);
		sManager.updatebirds( rescuedDucks,  TotalDucks, true);
	}


	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
        currentTime += Time.deltaTime;
        sManager.UpdateTime(TotalTime - currentTime);
        if (currentTime>=TotalTime )
        {
			if(!end) gameOver(false);
        }
        
        if(rescuedChickens + rescuedDucks + failedRescues >= TotalDucks + TotalChickens)
        {
           /* if(failedRescues / (TotalChickens + TotalDucks)> 0.4f)
            {
                gameOver(false);
            }
            else
            {
                gameOver(true);
            }*/

			if(!end)gameOver (true);

        }

	}
    public void rescueDuck()
    {
        rescuedDucks++;
        sManager.updatebirds(rescuedDucks, TotalDucks, true);
    }

    public void rescueChicken()
    {
        rescuedChickens++;
        sManager.updatebirds(rescuedChickens, TotalChickens, false);
    }
    public void failedRescue()
    {
        failedRescues++;
    }
    public void gameOver(bool win) {

		end = true;
		ducks.text = rescuedDucks + "/" + TotalDucks;
		chicken.text = rescuedChickens + "/" + TotalChickens;

		int duckProp;
		if (TotalDucks == 0)
			duckProp = 1;
		
		else duckProp= rescuedDucks / TotalDucks*10;

		int chickenProp;

		if (TotalChickens == 0)
			chickenProp = 1;
		
		else chickenProp= rescuedChickens / TotalChickens*10;

		int finalProp = (duckProp + chickenProp) / 2*100;

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
			soundVictory.Play ();
			cascos [3].sprite = blackCasco;
			next.SetActive (true);
		}
		if(finalProp>=90){				
			cascos [4].sprite = blackCasco;
		}

		Results.SetActive (true);
		tryagain.SetActive (true);
		menubtn.SetActive (true);

		if (finalProp < 70) {
			soundFail.Play ();

		}		
			

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
		if(i!=6) SceneManager.LoadScene (i + 1);
		else SceneManager.LoadScene (0);
	}
}
