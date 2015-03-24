using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (!Player.dlc)
			transform.Find ("goty").gameObject.SetActive (false);
		Player.PlaySound ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		Player.GameState = Player.gameState.Instructions;
		Player.PlaySound ();
		this.gameObject.SetActive (false);
	}
}