using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Player.sGameOver = this.gameObject;
		Player.sGameOver.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		Application.LoadLevel ("scene_1");
	}
}
