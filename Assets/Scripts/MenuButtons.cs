using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour {

	public Animation anim;

	// Use this for initialization
	void Start () {
		
	}


	// Update is called once per frame
	void Update () {
		
	}


	public void Exit(){
		
		Application.Quit();
	}


	public void Tutorial(){
		fadeOut ();
		StartCoroutine(changeScene(1));
	}


	public void StartGame(){
		fadeOut ();
		StartCoroutine(changeScene(2));

	}
	public void Survival(){
		fadeOut ();
		StartCoroutine(changeScene(3));

	}

	void fadeOut(){
		//fadeOutAnim.SetBool ("Fade", true);
		anim.Play();
	}


	IEnumerator changeScene(int scene){
		yield return new WaitForSeconds (1.1f);

		SceneManager.LoadScene (scene);
	}
}
