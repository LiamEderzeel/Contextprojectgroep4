using UnityEngine;
using System.Collections;

public class Riot_Escape : MonoBehaviour {
	// Use this for initialization
	void Start () {

		Player.sRiot = this.gameObject;
		this.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	}
}