using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class TutorialController : MonoBehaviour {

	public string[] phrases;
	public string[] waitingPhrases;

	public GameObject[] talkers;

	public GameObject textBox;
	public GameObject compass;


	private int index=0;
	private int waitingIndex=0;
	private int lastWaiter=0;

	private Image img;
	private bool end=false;
	public GameObject duck;

	// Use this for initialization
	void Start () {
		Invoke ("FirstApparition", 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void changePhrase(){
		
		textBox.GetComponentInChildren<Text> ().text = phrases [index];

		if (index != 0) {
			talkers[index-1].SetActive(false);
		}
		talkers[index].SetActive(true);
		index++;

		if (index == phrases.Length) {
			Invoke ("EnableCompass", 5f);

		} else if (index > phrases.Length) {
			return;
		} else {
			Invoke ("changePhrase", 5f);
		}
	}

	void FirstApparition(){

		textBox.SetActive (true);
		talkers[index].SetActive(true);

		//talker.SetActive (true);

		Invoke ("changePhrase", 0.5f);

	}

	void EnableCompass(){
		compass.SetActive (true);
		textBox.SetActive (false);
		talkers[index-1].SetActive(false);
		duck.SetActive (true);

		Invoke ("Waiting", 7f);
		//Spawn pollito y gallinita

	}
	void DisableTalker(){
		talkers[index].SetActive(false);

	}

	void Waiting(){
		textBox.SetActive (true);
		talkers[waitingIndex].SetActive(true);


		if (!end) {
			textBox.GetComponentInChildren<Text> ().text = waitingPhrases [waitingIndex];
			lastWaiter = waitingIndex;
			waitingIndex++;
			if (waitingIndex >= waitingPhrases.Length)
				waitingIndex = 0;
			Invoke ("DisableBox", 3f);

		}

	}

	void DisableBox(){		
		textBox.SetActive (false);

		talkers[lastWaiter].SetActive(false);

		Invoke ("Waiting", 5f);

	}

	public void Back(){
		SceneManager.LoadScene (0);
	}


	public void Win(){
		end = true;
		textBox.SetActive (true);
		textBox.GetComponentInChildren<Text> ().text = "GREAT! You can start now!";
		Invoke ("StartGame", 5f);

	
	}

	private void StartGame(){
		SceneManager.LoadScene (0);
	}
}
