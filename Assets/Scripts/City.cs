﻿using UnityEngine;
using System.Collections;

public class City : MonoBehaviour {


	#region Properties

	public ResourceCount rc;

	//namen en identifiers voor de steden, als twee stedendezelfde naam hebben is het niet zeker welke van de twee de code zal kiezen
	public enum KnownCities 
	{
		Amsterdam,
		Rotterdam,
		Utrecht
	}
	public KnownCities cityName; //naam die je uitkiest als je een city GameObject maakt.
	
	//enum die de staten aangeeft waar een stad zich in kan verkeren.
	public enum CityState
	{
		Idle,
		Requesting,
	}
	public CityState cityState;

	//Als de stad niets nodig heeft
	float counterIdle = 0;
	float counterIdleThreshold;
	float counterIdleThresholdNew()
	{
		return Random.Range (5, 10);
	}

	//Als de stad iets nodig heeft
	//tellers zijn in principe voor het teruglopen van de HP
	float counterRequesting = 0;
	float counterRequestingThreshold;
	float counterRequestingThresholdNew()
	{
		return Random.Range (1, 5);
	}
	public int CityHP;

	AudioClip fxTrade;
	AudioClip fxNo;
	AudioClip fxRiot;

	#endregion

	void Start () {
		CityHP = 100;

		fxTrade = Resources.Load<AudioClip> ("Sounds/FX_genoeg");
		fxNo    = Resources.Load<AudioClip> ("Sounds/FX_niet_genoeg");
		fxRiot  = Resources.Load<AudioClip> ("Sounds/FX_opstand");

		rc = new ResourceCount ();
		counterIdleThreshold = counterIdleThresholdNew ();
		counterRequestingThreshold = counterRequestingThresholdNew ();
		cityState = CityState.Idle;
	}

	/// <summary>
	/// Update this instance. Bevat alle subroutines voor de afzonderlijke citystates
	/// </summary>
	void Update ()
	{
		if (cityState == CityState.Idle && Player.GameState == Player.gameState.Ingame) {
			counterIdle += Time.deltaTime * 1; //1 per seconde
			if (counterIdle > counterIdleThreshold) {
				counterIdle = 0;
				counterIdleThreshold = counterIdleThresholdNew();
				cityState = CityState.Requesting;
				CityRequest();
			}
		}

		if (cityState == CityState.Requesting && Player.GameState == Player.gameState.Ingame) {
			//tellen en zorgen dat HP terugloopt
			/*
			 * vanuit hier ruilhandel plegen, als roep niet beantwoord wordt terugvallen naar state 1
			 * */
			counterRequesting += Time.deltaTime * 3; //3 per seconde
			if (counterRequesting > counterRequestingThreshold)
			{
				counterRequesting = 0;
				counterRequestingThreshold = counterRequestingThresholdNew();
				if (CityHP - 5 >= 0 && !Player.CityIsRioting)
				CityHP -= 5;
			}

			if (CityHP == 0 && !Player.CityIsRioting)
			{
				//dan is er een kans dat er een riot komt.
				Player.CityIsRioting = true;
				spawnRiot();
			}

			//we hoeven alleen te pollen voor deze waarde, het daadwerkelijke terugtellen gebeurt vanuit de player.
			bool isCitySatisfied = rc.Tekort == 0;
			if (isCitySatisfied) {
				counterIdle = 0;
				counterIdleThreshold = counterIdleThresholdNew();
				cityState = CityState.Idle;
			}
		}
	}

	void spawnRiot () {
		//GameObject instance = Instantiate(Resources.Load("Riot")) as GameObject;
		Vector3 newPosition = this.gameObject.transform.position;
		Quaternion newRotation = Quaternion.identity;
		GameObject riotObject = (GameObject)Instantiate(Resources.Load("Riot"), newPosition, newRotation);
		riotObject.GetComponent<Riot> ().Waypoints = GetWaypoints ();
		riotObject.GetComponent<Riot> ().StartRiot ();
		audio.clip = fxRiot;
		audio.Play ();
	}

	#region Requests
	/// <summary>
	/// Genereert random requestdata voor de stad.
	/// </summary>
	void CityRequest()
	{
		int r;
		int r2;
		r = (int)Random.Range (1, 3);
		rc.TekortType = (Player.Grondstof)r;
		rc.Tekort += AddResourceTekort ();
		r2 = (int)Random.Range (1, 3);
		//zorgen dat het overschot niet gelijk kan zijn aan het tekort.
		//dus: zolang r2 en r gelijk zijn, verzin maar iets nieuws voor r2.
		while (r2 == r) {
			r2 = (int)Random.Range (1, 3);
		}
		rc.OverschotType = (Player.Grondstof)r2;
		rc.Overschot += AddResourceTekort ();
	}

	public ResourceCount GenerateResource()
	{
		ResourceCount rc = new ResourceCount ();
		int rr = Random.Range (1, 3);
		rc.Tekort = rr;
		return rc;
	}

	public int AddResourceTekort()
	{
		int rr = Random.Range (1, 5);
		return rr;
	}

	#endregion

	/*void OnGUI ()
	{
		Vector2 boxPosition = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);

		GUIStyle g_CityName = new GUIStyle();
		g_CityName.alignment = TextAnchor.UpperCenter;
		g_CityName.normal.textColor = Color.white;

		GUIStyle g_CityRequest = new GUIStyle();
		g_CityRequest.alignment = TextAnchor.MiddleCenter;
		g_CityRequest.normal.textColor = Color.white;

		if(cityName == KnownCities.Amsterdam)
		GUI.Label (new Rect(boxPosition.x - 40, Screen.height - boxPosition.y-50,80,50),"Amsterdam",g_CityName);
		else if(cityName == KnownCities.Rotterdam)
		GUI.Label (new Rect(boxPosition.x - 40, Screen.height - boxPosition.y-50,80,50),"Rotterdam",g_CityName);
		else if(cityName == KnownCities.Utrecht)
		GUI.Label (new Rect(boxPosition.x - 40, Screen.height - boxPosition.y-50,80,50),"Utrecht",g_CityName);

		//ook lelijke code... dit kan sneller en mooier.
		if (rc.Tekort != 0) {
			if (rc.TekortType == Player.Grondstof.Voedsel)
			GUI.Label (new Rect (boxPosition.x - 40, Screen.height - boxPosition.y + 16, 80, 20), "Voedsel: ", g_CityRequest);
			else if (rc.TekortType == Player.Grondstof.Steenkool)
			GUI.Label (new Rect (boxPosition.x - 40, Screen.height - boxPosition.y + 16, 80, 20), "Steenkool: ", g_CityRequest);
			else if (rc.TekortType == Player.Grondstof.Textiel)
			GUI.Label (new Rect (boxPosition.x - 40, Screen.height - boxPosition.y + 16, 80, 20), "Textiel: ", g_CityRequest);

			GUI.Label (new Rect (boxPosition.x - 40, Screen.height - boxPosition.y + 32, 80, 20), rc.Tekort.ToString (), g_CityRequest);
		}

		if (rc.Overschot != 0) {
			if (rc.OverschotType == Player.Grondstof.Voedsel)
				GUI.Label (new Rect (boxPosition.x - 40, Screen.height - boxPosition.y + 48, 80, 20), "Voedsel: ", g_CityRequest);
			else if (rc.OverschotType == Player.Grondstof.Steenkool)
				GUI.Label (new Rect (boxPosition.x - 40, Screen.height - boxPosition.y + 48, 80, 20), "Steenkool: ", g_CityRequest);
			else if (rc.OverschotType == Player.Grondstof.Textiel)
				GUI.Label (new Rect (boxPosition.x - 40, Screen.height - boxPosition.y + 48, 80, 20), "Textiel: ", g_CityRequest);
			
			GUI.Label (new Rect (boxPosition.x - 40, Screen.height - boxPosition.y + 64, 80, 20), rc.Overschot.ToString (), g_CityRequest);
		}

		g_CityRequest.normal.textColor = Color.red;
		if (CityHP != 100)
		GUI.Label (new Rect(boxPosition.x - 40, Screen.height - boxPosition.y+128,80,20),"HP: " + CityHP, g_CityRequest);

	}*/

	//klikevent van de steden, controleert of de player genoeg resources heeft en pleegt dan ruilhandel
	void OnMouseDown()
	{

		if (Player.GameState == Player.gameState.Ingame) {
			this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (0.75f, 0.5f, 0.5f);
			/*dit stuk code hieronder moeten we echt even netjes maken.*/
			bool ruilen = false;
			//Substracting the resources when clicked on city with request.
			if (rc.TekortType == Player.Grondstof.Voedsel && Player.resource_1 >= rc.Tekort) {
				Player.resource_1 -= rc.Tekort;
				rc.Tekort = 0;
				ruilen = true;
			} else if (rc.TekortType == Player.Grondstof.Textiel && Player.resource_2 >= rc.Tekort) {
				Player.resource_2 -= rc.Tekort;
				rc.Tekort = 0;
				ruilen = true;
			} else if (rc.TekortType == Player.Grondstof.Steenkool && Player.resource_3 >= rc.Tekort) {
				Player.resource_3 -= rc.Tekort;
				rc.Tekort = 0;
				ruilen = true;
			}

			if (ruilen) {
				//Adding the resources when clicked on city with too much of a resource.
				if (rc.OverschotType == Player.Grondstof.Voedsel) {
					Player.resource_1 += rc.Overschot;
					rc.Overschot = 0;
				} else if (rc.OverschotType == Player.Grondstof.Textiel) {
					Player.resource_2 += rc.Overschot;
					rc.Overschot = 0;
				} else if (rc.OverschotType == Player.Grondstof.Steenkool) {
					Player.resource_3 += rc.Overschot;
					rc.Overschot = 0;
				}
				rc = new ResourceCount(); //zodat stad geen resource tekort en overschottype heeft
				ruilen = false;
				audio.clip = fxTrade;
				audio.Play();
				Player.DobbelForDialog();
			}
			else
			{
				//niet ruilen, niet genoeg resources.
				audio.clip = fxNo;
				audio.Play();
			}
		}
	}
	void OnMouseUp()
	{
		this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f);
	}

	public ArrayList GetWaypoints()
	{
		GameObject wc = transform.FindChild ("WaypointCollection").gameObject;
		ArrayList Waypoints = new ArrayList();
		foreach (Transform child in wc.gameObject.transform) {
			Waypoints.Add(child.position);
		}
		Waypoints.Insert(0, this.gameObject.transform.position); //Stad is begin.
		Waypoints.Add(GameObject.Find("Player").transform.position); //Player is eind.
		return Waypoints;
	}
}

public struct ResourceCount
{
	public int Overschot;
	public Player.Grondstof OverschotType;
	public int Tekort;
	public Player.Grondstof TekortType;
}