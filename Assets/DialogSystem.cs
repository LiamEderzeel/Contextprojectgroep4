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
		/*if (Player.GameState != Player.gameState.Dialog)
			this.gameObject.SetActive (false);
		//kill yourself.
		*/
	}

	public void SpawnDialog ()
	{
		Dialogs.Clear ();
		foreach (Transform child in this.gameObject.transform) {
			Dialogs.Add (child.gameObject);
		}
		if (Dialogs.Count > 0)
			//soms kan het zijn dat je ineens alle dialogen opgemaakt hebt, dan mag je geen nullreference krijgen!
		{
			int i = Random.Range (1, Dialogs.Count);
			GameObject dia = (GameObject)Dialogs [i];
			Player.GameState = Player.gameState.Dialog;
			dia.SetActive (true);
		} else {
			//lui
			if (Player.GameState == Player.gameState.Dialog) {
				Player.GameState = Player.gameState.Ingame;
				Player.sDialog.SetActive(false);
			}
			else if (Player.GameState == Player.gameState.Rioting) {
				Player.GameState = Player.gameState.Ingame;
				Player.CityIsRioting = false;
				Player.sDialog.SetActive(false);
			}
		}
	}
}