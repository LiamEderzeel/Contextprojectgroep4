using UnityEngine;
using System.Collections;

public class City : MonoBehaviour {

	public ResourceCount rGraan = new ResourceCount();
	public ResourceCount rVlees = new ResourceCount();
	public ResourceCount rWater = new ResourceCount();

	public enum KnownCities 
	{
		Amsterdam,
		Rotterdam,
		Utrecht
	}
	public KnownCities cityName; //naam die je uitkiest als je een city GameObject maakt.


	void Start () {
		//random getal aan startresources
		rGraan = GenerateResource ();
		rVlees = GenerateResource ();
		rWater = GenerateResource ();
		
		InvokeRepeating("CityRequest", 5.0f, 5.0f);
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
	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			//Debug.Log("Pressed left click, casting ray.");
			CastRay();
		}
	}
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

		//if (rGraan.Tekort != 0)
		GUI.Label (new Rect(boxPosition.x - 40, Screen.height - boxPosition.y+16,80,20),"t Graan: " + rGraan.Tekort, g_CityRequest);
		//if (rVlees.Tekort != 0)
		GUI.Label (new Rect(boxPosition.x - 40, Screen.height - boxPosition.y+32,80,20),"t Vlees: " + rVlees.Tekort, g_CityRequest);
		//if (rWater.Tekort != 0)
		GUI.Label (new Rect(boxPosition.x - 40, Screen.height - boxPosition.y+48,80,20),"t Water: " + rWater.Tekort, g_CityRequest);
	}
}
public struct ResourceCount
{
	public int Overschot;
	public int Tekort;
}