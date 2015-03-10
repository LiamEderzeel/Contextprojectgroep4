﻿using UnityEngine;
using System.Collections;

public class City : MonoBehaviour {

#region Properties

	public ResourceCount rGraan = new ResourceCount();
	public ResourceCount rVlees = new ResourceCount();
	public ResourceCount rWater = new ResourceCount();

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
		Revolting
	}
	public CityState cityState;

	//Als de stad niets nodig heeft
	float counterIdle = 0;
	float counterIdleThreshold;
	float counterIdleThresholdNew()
	{
		return Random.Range (5, 15);
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

#endregion

	void Start () {
		//random getal aan startresources
		rGraan = GenerateResource ();
		rVlees = GenerateResource ();
		rWater = GenerateResource ();
		CityHP = 100;

		counterIdleThreshold = counterIdleThresholdNew ();
		counterRequestingThreshold = counterRequestingThresholdNew ();
		cityState = CityState.Idle;
	}

	/// <summary>
	/// Update this instance. Bevat alle subroutines voor de afzonderlijke citystates
	/// </summary>
	void Update ()
	{
		//mousedown event
		if (Input.GetMouseButtonDown(0))
			CastRay();
		
		if (cityState == CityState.Idle) { //of cityState == CityState.Idle;
			counterIdle += Time.deltaTime * 1; //1 per seconde

			if (counterIdle > counterIdleThreshold) {
				counterIdle = 0;
				counterIdleThreshold = counterIdleThresholdNew();
				
				//do stuff
				cityState = CityState.Requesting;
				CityRequest();
				//melden!
			}
		}

		if (cityState == CityState.Requesting) {
			//tellen en zorgen dat HP terugloopt
			/*
			 * vanuit hier ruilhandel plegen, als roep niet beantwoord wordt terugvallen naar state 1
			 * */
			counterRequesting += Time.deltaTime * 1; //1 per seconde
			if (counterRequesting > counterRequestingThreshold)
			{
				counterRequesting = 0;
				counterRequestingThreshold = counterRequestingThresholdNew();
				if (CityHP - 5 >= 0)
					CityHP -= 5;
			}

			if (CityHP == 0)
				Player.GameOver = true;

			//we hoeven alleen te pollen voor deze waarde, het daadwerkelijke terugtellen gebeurt vanuit de player.
			bool isCitySatisfied = rGraan.Tekort == 0 && rVlees.Tekort == 0 && rWater.Tekort == 0;
			if (isCitySatisfied) {
				counterIdle = 0;
				counterIdleThreshold = counterIdleThresholdNew();
				cityState = CityState.Idle;
			}
		}
	}

#region Requests

	void CityRequest()
	{
		rGraan.Tekort += AddResourceTekort ();
		rVlees.Tekort += AddResourceTekort ();
		rWater.Tekort += AddResourceTekort ();
	}

	public ResourceCount GenerateResource()
	{
		ResourceCount rc = new ResourceCount ();
		int rr = Random.Range (0, 3);
		rc.Tekort = rr;
		return rc;
	}

	public int AddResourceTekort()
	{
		int rr = Random.Range (0, 5);
		return rr;
	}

#endregion

	void OnGUI ()
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

		if (rGraan.Tekort != 0)
			GUI.Label (new Rect(boxPosition.x - 40, Screen.height - boxPosition.y+16,80,20),"t Graan: " + rGraan.Tekort, g_CityRequest);
		if (rVlees.Tekort != 0)
			GUI.Label (new Rect(boxPosition.x - 40, Screen.height - boxPosition.y+32,80,20),"t Vlees: " + rVlees.Tekort, g_CityRequest);
		if (rWater.Tekort != 0)
			GUI.Label (new Rect(boxPosition.x - 40, Screen.height - boxPosition.y+48,80,20),"t Water: " + rWater.Tekort, g_CityRequest);

		g_CityRequest.normal.textColor = Color.red;
		if (CityHP != 100)
			GUI.Label (new Rect(boxPosition.x - 40, Screen.height - boxPosition.y+64,80,20),"HP: " + CityHP, g_CityRequest);

	}

	//raycast voor klikevent van de steden, controleert of de player genoeg resources heeft en pleegt dan ruilhandel
	void CastRay()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100))
		{
			City HitCity = hit.collider.GetComponent<City>();
			if (HitCity == null)
				return;
			
			//Substracting the resources when clicked on city with request.
			
			//cityName == KnownCities.Amsterdam
			
			if(Player.resource_1 >= HitCity.rGraan.Tekort && Player.resource_2 >= HitCity.rVlees.Tekort && Player.resource_3 >= HitCity.rWater.Tekort)
			{
				Player.resource_1 -= HitCity.rGraan.Tekort;
				Player.resource_2 -= HitCity.rVlees.Tekort;
				Player.resource_3 -= HitCity.rWater.Tekort;
				
				HitCity.rGraan.Tekort = 0;
				HitCity.rVlees.Tekort = 0;
				HitCity.rWater.Tekort = 0;
				
				//todo resources ook echt van steden afhalen in plaats van player
				
			}
		}
	}


}

public struct ResourceCount
{
	public int Overschot;
	public int Tekort;
}