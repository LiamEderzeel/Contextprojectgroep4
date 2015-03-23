﻿using UnityEngine;
using System.Collections;

public class DialogSystem : MonoBehaviour {


	ArrayList Dialogs = new ArrayList();

	// Use this for initialization
	void Start () {
		//inladen van elke 
		foreach (Transform child in this.gameObject.transform) {
			Dialogs.Add (child.gameObject);
			child.gameObject.SetActive(false);
		}
		Player.sDialog = this.gameObject;
		Player.sDialog.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Player.GameState != Player.gameState.Dialog)
			this.gameObject.SetActive (false);
		//kill yourself.
	}

	void SpawnDialog ()
	{
		int banana = Random.Range (1, Dialogs.Count);
		GameObject dia = (GameObject)Dialogs [banana];
		Player.GameState = Player.gameState.Dialog;
		dia.SetActive (true);
	}
}