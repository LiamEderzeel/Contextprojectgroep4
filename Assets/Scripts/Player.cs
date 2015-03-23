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

	public enum gameState
	{
		Title,
		Instructions,
		Ingame,
		Dialog,
		Rioting,
		Gameover,
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
}
