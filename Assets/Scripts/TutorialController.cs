using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
		Debug.Log ("cambio a frase " + index);


		
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
		Debug.Log ("activando todo");
		textBox.SetActive (true);
		talker.SetActive (true);

		Invoke ("changePhrase", 0.5f);

	}

	void EnableCompass(){
		compass.SetActive (true);
		textBox.SetActive (false);
		Invoke ("Waiting", 2f);

	}
	void Waiting(){
		textBox.SetActive (true);

		if (!end) {
			textBox.GetComponentInChildren<Text> ().text = waitingPhrases [waitingIndex];
			waitingIndex++;
			if (waitingIndex >= waitingPhrases.Length)
				waitingIndex = 0;
			Invoke ("Waiting", 5f);

		}

	}
}
