using UnityEngine;
using System.Collections;

public class Gewonnen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Player.sGewonnen = this.gameObject;
		Player.sGewonnen.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		Application.LoadLevel ("scene_1"); 
	}
}
