using UnityEngine;
using System.Collections;

public class City : MonoBehaviour {
	int RequestResource_1;
	int RequestResource_2;
	int RequestResource_3;


	public static int City1RequestResource_1;
	public static int City1RequestResource_2;
	public static int City1RequestResource_3;

	public static int City2RequestResource_1;
	public static int City2RequestResource_2;
	public static int City2RequestResource_3;

	public static int City3RequestResource_1;
	public static int City3RequestResource_2;
	public static int City3RequestResource_3;


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
		int RandomResource_1 = Random.Range(0,7);
		int RandomResource_2 = Random.Range(0,7);
		int RandomResource_3 = Random.Range(0,7);
		
		if(RandomResource_1 > 4)
		{
			if(RandomResource_1 == 5)
			{
				RequestResource_1 = 1;
			}
			else if(RandomResource_1 == 6)
			{
				RequestResource_1 = 2;
			}	
		}
		else
		{
			RequestResource_1 = 0;
		}
		if(RandomResource_2 > 4)
		{
			if(RandomResource_2 == 5)
			{
				RequestResource_2 = 1;
			}
			else if(RandomResource_2 == 6)
			{
				RequestResource_2 = 2;
			}	
		}
		else
		{
			RequestResource_2 = 0;
		}
		if(RandomResource_3 > 4)
		{
			if(RandomResource_3 == 5)
			{
				RequestResource_3 = 1;
			}
			else if(RandomResource_3== 6)
			{
				RequestResource_3 = 2;
			}	
		}
		else
		{
			RequestResource_3 = 0;
		}

		if(this.gameObject.name == "City_1")
		{
			City1RequestResource_1 = RequestResource_1;
			City1RequestResource_2 = RequestResource_2;
			City1RequestResource_3 = RequestResource_3;
		} else if(this.gameObject.name == "City_2") {
			City2RequestResource_1 = RequestResource_1;
			City2RequestResource_2 = RequestResource_2;
			City2RequestResource_3 = RequestResource_3;
		} else if(this.gameObject.name == "City_3") {
			City3RequestResource_1 = RequestResource_1;
			City3RequestResource_2 = RequestResource_2;
			City3RequestResource_3 = RequestResource_3;
		}
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

		if(this.gameObject.name == "City_1")
		{
			GUI.Label (new Rect(boxPosition.x - 40, Screen.height - boxPosition.y-25,80,50),"Amsterdam",CityName);
		}
		if(this.gameObject.name == "City_2")
		{
			GUI.Label (new Rect(boxPosition.x - 40, Screen.height - boxPosition.y-25,80,50),"Rotterdam",CityName);
		}
		if(this.gameObject.name == "City_3")
		{
			GUI.Label (new Rect(boxPosition.x - 40, Screen.height - boxPosition.y-25,80,50),"Utrecht",CityName);
		}

		if (RequestResource_1 != 0)
		{
			GUI.Label (new Rect(boxPosition.x - 40, Screen.height - boxPosition.y+16,80,20),"Graan " + RequestResource_1,CityRequest);
		}
		if (RequestResource_2 != 0)
		{
			GUI.Label (new Rect(boxPosition.x - 40, Screen.height - boxPosition.y+32,80,20),"Vlees " + RequestResource_2,CityRequest);
		}
		if (RequestResource_3 != 0)
		{
			GUI.Label (new Rect(boxPosition.x - 40, Screen.height - boxPosition.y+48,80,20),"Water " + RequestResource_3,CityRequest);
		}
	}
}