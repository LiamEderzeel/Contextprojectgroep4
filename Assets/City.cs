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

	//public GUIStyle style;

	// Use this for initialization
	void Start () {
		InvokeRepeating("CityRequest", 5.0f, 5.0f);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void CityRequest()
	{
		rGraan = GenerateResource ();
		rVlees = GenerateResource ();
		rWater = GenerateResource ();
	}


	public ResourceCount GenerateResource()
	{
		ResourceCount rc = new ResourceCount ();
		int rr = Random.Range (0, 7);
		if(rr > 4)
			rc.Tekort = rr - 2;
		return rc;
	}

	void OnGUI ()
	{
		Vector2 boxPosition = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);

		//boxPosition.x = Screen.width - boxPosition.x;
		//boxPosition.y = Screen.height - boxPosition.y;

		var rect = new Rect(boxPosition.x, Screen.height - boxPosition.y, Screen.width, Screen.height);

		GUIStyle CityName = new GUIStyle();
		CityName.alignment = TextAnchor.UpperCenter;
		CityName.normal.textColor = Color.white;

		GUIStyle CityRequest = new GUIStyle();
		CityRequest.alignment = TextAnchor.MiddleCenter;
		CityRequest.normal.textColor = Color.white;

		if(cityName == KnownCities.Amsterdam)
		{
			GUI.Label (new Rect(boxPosition.x - 40, Screen.height - boxPosition.y-25,80,50),"Amsterdam",CityName);
		}
		if(cityName == KnownCities.Rotterdam)
		{
			GUI.Label (new Rect(boxPosition.x - 40, Screen.height - boxPosition.y-25,80,50),"Rotterdam",CityName);
		}
		if(cityName == KnownCities.Utrecht)
		{
			GUI.Label (new Rect(boxPosition.x - 40, Screen.height - boxPosition.y-25,80,50),"Utrecht",CityName);
		}

		if (rGraan.Tekort != 0)
			GUI.Label (new Rect(boxPosition.x - 40, Screen.height - boxPosition.y+16,80,20),"Graan " + rGraan.Tekort ,CityRequest);

		if (rVlees.Tekort != 0)
			GUI.Label (new Rect(boxPosition.x - 40, Screen.height - boxPosition.y+32,80,20),"Vlees " + rVlees.Tekort,CityRequest);

		if (rWater.Tekort != 0)
			GUI.Label (new Rect(boxPosition.x - 40, Screen.height - boxPosition.y+48,80,20),"Water " + rWater.Tekort,CityRequest);
	}
}

public struct ResourceCount
{
	public int Overschot;
	public int Tekort;
}