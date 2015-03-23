using UnityEngine;
using System.Collections;

public class Riot_Escape : MonoBehaviour {

	Escape eWorst;
	Escape eLeger;
	Escape ePropaganda;

	// Use this for initialization
	void Start () {
		eWorst = 		GameObject.Find ("eWorst").GetComponent 	 < Escape> ();
		eLeger = 		GameObject.Find ("eLeger").GetComponent 	 < Escape> ();
		ePropaganda = 	GameObject.Find ("ePropaganda").GetComponent < Escape> ();

		Player.sRiot = this.gameObject;
		this.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (eWorst.isUsed && eLeger.isUsed && ePropaganda.isUsed) {
			Player.GameOver = true;
			Player.GameState = Player.gameState.Gameover;
		}
		*/
	}
}