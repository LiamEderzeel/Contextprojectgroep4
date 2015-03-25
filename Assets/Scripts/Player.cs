using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public static int resource_1; //voedsel
	public static int resource_2; //textiel
	public static int resource_3; //steenkool
	
	public static bool CityIsRioting = false;
	public static int AvailableEscapes = 3;

	//gameobject collection
	public static GameObject sDialog;
	public static GameObject sRiot;
	public static GameObject sGameOver;
	public static GameObject sGewonnen;

	//achtergrondmuziek
	public static AudioClip muTitle;
	public static AudioClip muIngame;
	public static AudioClip muGameover;
	public static AudioClip muGewonnen;

	private static AudioSource audio;

	public static bool dlc = true;

	public enum gameState
	{
		Title,
		Instructions,
		Ingame,
		Dialog,
		Rioting,
		Gameover,
		Gewonnen,
		Credits
	};

	public static gameState GameState;

	public enum Grondstof
	{
		Voedsel = 1,
		Textiel = 2,
		Steenkool = 3
	}

	// Use this for initialization
	void Start ()
	{
		//entry point for application
		GameState = gameState.Title;
		resource_1 = 0;
		resource_2 = 0;
		resource_3 = 0;

		audio = this.gameObject.GetComponent<AudioSource> ();
		audio.volume = 1f;

		muTitle = Resources.Load<AudioClip>("Sounds/MU_startscherm");
		muIngame = Resources.Load<AudioClip>("Sounds/MU_ingame");
		muGameover = Resources.Load<AudioClip>("Sounds/MU_game_over");
		//muGewonnen = Resources.Load<AudioClip> ("Sounds/mu_gewonnen/");
	}	

	void Update ()
	{

	}

	public static void ResetCities()
	{
		foreach (Transform child in GameObject.Find("sMain").gameObject.transform) {
			City c = child.gameObject.GetComponent<City>();
			if (c)
			{
				c.rc.Tekort = 0;
				c.rc.Overschot = 0;
				c.CityHP = 100;
			}
		}
	}

	/// <summary>
	/// Functie voor het aanroepen voor achtergrondmuziek, reageert op de gamestate.
	/// </summary>
	public static void PlaySound()
	{
		if (GameState == gameState.Title) {
			audio.Stop();
			audio.loop = false;
			audio.clip = muTitle;
			audio.Play();
		}
		else if (GameState == gameState.Gameover) {
			audio.Stop();
			audio.loop = true;
			audio.clip = muGameover;
			audio.Play();
		}
		else {
			audio.Stop();
			audio.loop = true;
			audio.clip = muIngame;
			audio.Play();
		}
	}

	public static void DobbelForDialog()
	{
		int r = Random.Range (1, 5);
		if (r == 2) {
			Player.GameState = gameState.Dialog;
			sDialog.SetActive(true);
			sDialog.GetComponent<DialogSystem>().SpawnDialog();
		}
	}
}
