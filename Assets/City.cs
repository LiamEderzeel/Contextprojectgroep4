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

			if(Player.resource_1 > 0 && rGraan.Tekort > 0)
			{
				Player.resource_1 = Player.resource_1 - rGraan.Tekort;
			}
			if(Player.resource_2 > 0 && rVlees.Tekort > 0)
			{
				Player.resource_2 = Player.resource_2 - rVlees.Tekort;
			}
			if(Player.resource_3 > 0 && rWater.Tekort > 0)
			{
				Player.resource_3 = Player.resource_3 - rWater.Tekort;

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