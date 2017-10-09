using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class TutorialController : MonoBehaviour {

	public string[] phrases;
	public string[] waitingPhrases;

	public Sprite[] faces;

	public GameObject talker;
	public GameObject textBox;
	public GameObject compass;

	private int index=0;
	private int waitingIndex=0;

	private Image img;
	private bool end=false;

	// Use this for initialization
	void Start () {
		Invoke ("FirstApparition", 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void changePhrase(){
		
		textBox.GetComponentInChildren<Text> ().text = phrases [index];
		talker.GetComponent<Image> ().sprite = faces [index];
		index++;

		if (index == phrases.Length) {
			Invoke ("EnableCompass", 3f);

		} else if (index > phrases.Length) {
			return;
		} else {
			Invoke ("changePhrase", 3f);
		}
	}

	void FirstApparition(){

		textBox.SetActive (true);
		talker.SetActive (true);

		Invoke ("changePhrase", 0.5f);

	}

	void EnableCompass(){
		compass.SetActive (true);
		textBox.SetActive (false);
		Invoke ("Waiting", 5f);
		//Spawn pollito y gallinita

	}

	void Waiting(){
		textBox.SetActive (true);

		if (!end) {
			textBox.GetComponentInChildren<Text> ().text = waitingPhrases [waitingIndex];
			waitingIndex++;
			if (waitingIndex >= waitingPhrases.Length)
				waitingIndex = 0;
			Invoke ("DisableBox", 3f);

		}

	}

	void DisableBox(){		
		textBox.SetActive (false);
		Invoke ("Waiting", 3f);

	}

	public void Back(){
		SceneManager.LoadScene (0);
	}


	public void Win(){
		textBox.SetActive (true);
		textBox.GetComponentInChildren<Text> ().text = "GREAT! You can start now!";

	
	}

	private void StartGame(){
		SceneManager.LoadScene (1);
	}
}
