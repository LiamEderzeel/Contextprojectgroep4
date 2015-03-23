using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	public static int resource_1; //voedsel
	public static int resource_2; //textiel
	public static int resource_3; //steenkool


	public static bool CityIsRioting = false;
	//public static bool GameOver = false;
	public static int AvailableEscapes = 3;

	//gameobject collection
	public static GameObject sDialog;
	public static GameObject sRiot;


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

	 //niet langer nodig, wordt opgevangen door het schildje
	void OnGUI ()
	{
		GUIStyle pGui = new GUIStyle();
		pGui.alignment = TextAnchor.UpperLeft;
		pGui.normal.textColor = Color.white;
		pGui.fontSize = Screen.height / 20;

		GUI.Label (new Rect (0, 0, 60, 50), "Voedsel " + resource_1, pGui);
		GUI.Label (new Rect (80, 0, 60, 50), "Textiel " + resource_2, pGui);
		GUI.Label (new Rect (160, 0, 60, 50), "Steenkool " + resource_3, pGui);

		if (GameState == gameState.Gameover) {
			pGui.normal.textColor = Color.red;
			GUI.Label (new Rect (Screen.width / 2, Screen.height / 4, 60, 50), "GAMEOVER", pGui);
		}
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
