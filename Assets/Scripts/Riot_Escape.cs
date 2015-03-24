using UnityEngine;
using System.Collections;

public class Riot_Escape : MonoBehaviour {

	public AudioClip rabbleSound;
	private AudioSource audio;

	// Use this for initialization
	void Start () {

		audio = this.GetComponent<AudioSource> ();
		audio.clip = rabbleSound;
		audio.loop = true;

		Player.sRiot = this.gameObject;
		this.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (!audio.isPlaying && Player.GameState == Player.gameState.Rioting)
			audio.Play ();
		if (audio.isPlaying && Player.GameState != Player.gameState.Rioting)
			audio.Stop ();
	}
}