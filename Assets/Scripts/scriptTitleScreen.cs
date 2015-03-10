using UnityEngine;
using System.Collections;

public class scriptTitleScreen : MonoBehaviour {

	GameObject gMain;

	// Use this for initialization
	void Start () {

		gMain = GameObject.Find ("sMain");
		gMain.SetActive (false); //killen die handel

		//muziekje enzo.
	}
	
	// Update is called once per frame
	void Update () {
		//rolling credits enzo
	}

	public void StartGame()
	{
		Player.GameState = Player.gameState.Ingame;
		gMain.SetActive(true); //aan met de handel

		//nuke that motherfucker.
		Object.Destroy(this.gameObject);


	}
}
