using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControl : MonoBehaviour {
	public GameObject aurora1;
	public GameObject aurora2;
	public GameObject aurora3;
	public GameObject aurora4;
	public float spawnTime1 = 10f;
	public float spawnTime2 = 10f;
	public float spawnTime3 = 10f;
	public float spawnTime4 = 10f;
	Quaternion rota1;
	Quaternion rota2;
	Quaternion rota3;
	Quaternion rota4;
	Vector3 pos1;
	Vector3 pos2;
	Vector3 pos3;
	Vector3 pos4;

	// Use this for initialization
	void Start () {
		rota1 = aurora1.transform.rotation;
		rota2 = aurora2.transform.rotation;
		rota3 =aurora3.transform.rotation;
		rota4 =aurora4.transform.rotation;
		pos1 = aurora1.transform.position;
		pos2 = aurora2.transform.position;
		pos3 = aurora3.transform.position;
		pos4 = aurora4.transform.position;
		InvokeRepeating ("SpawnAurora1", spawnTime1, spawnTime1);
		InvokeRepeating ("SpawnAurora2", spawnTime2, spawnTime2);
		InvokeRepeating ("SpawnAurora3", 1, spawnTime3);
		InvokeRepeating ("SpawnAurora4", 4, spawnTime4);
		aurora1.GetComponent<Renderer> ().sortingOrder = -5;
		aurora2.GetComponent<Renderer> ().sortingOrder = -5;
		aurora3.GetComponent<Renderer> ().sortingOrder = -5;
		aurora4.GetComponent<Renderer> ().sortingOrder = -5;

	}
	
	public void SpawnAurora1(){


		Instantiate(aurora1, pos1,rota1);
	}
	public void SpawnAurora2(){


		Instantiate(aurora2,pos2,rota2);
	}
	public void SpawnAurora3(){


		Instantiate(aurora3, pos3,rota3);
	}
	public void SpawnAurora4(){


		Instantiate(aurora4, pos4,rota4);
	}


	void Update () {
		
	}

}
