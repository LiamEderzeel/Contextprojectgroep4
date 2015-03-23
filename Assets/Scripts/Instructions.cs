using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		Player.GameState = Player.gameState.Ingame;
		this.gameObject.SetActive (false);
	}
}