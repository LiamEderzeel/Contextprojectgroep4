using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	int MyVar;
	int resource_1;
	int resource_2;
	int resource_3;
	System.Random rnd = new System.Random();

	// Use this for initialization
	void Start ()
	{
		resource_1 = 0;
		resource_2 = 0;
		resource_3 = 0;
	}	

	void CityRequest()
	{
		Debug.Log("working1");
		int RequestResource_1 = rnd.Next(0, 7);
		int RequestResource_2 = rnd.Next(0, 7);
		int RequestResource_3 = rnd.Next(0, 7);
		if(RequestResource_1 > 4)
		{
			if(RequestResource_1 == 5)
			{
				MyVar = 1;
			}
			else if(RequestResource_1 == 6)
			{
				MyVar = 2;
			}	
		}
		else
		{
			MyVar = 0;
		}
	}
	void CastRay()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100))
		{
			//Debug.DrawLine(ray.origin, hit.point);
			Debug.Log("Hit object: " + hit.collider.name);
			if(hit.collider.name == "Resource_1")
			{
				resource_1 ++;
			}
			else if (hit.collider.name == "Resource_2")
			{
				resource_2 ++;
			}
			else if (hit.collider.name == "Resource_3")
			{
				resource_3 ++;
			}

			if(hit.collider.name == "City_1")
			{
				Debug.Log("click city 1");
				CityRequest();
			}
			else if (hit.collider.name == "City_2")
			{
				Debug.Log("click city 2");
			}
			else if (hit.collider.name == "City_3")
			{
				Debug.Log("click city 3");
			}
		}
	}
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown(0)) {
			//Debug.Log("Pressed left click, casting ray.");
			CastRay();
		}
	}
	void OnGUI ()
	{
		GUI.Label (new Rect (0,0,100,50), "Graan " + resource_1);
		GUI.Label (new Rect (0,16,100,50), "Vlees " + resource_2);
		GUI.Label (new Rect (0,32,100,50), "Water " + resource_3);

		GUI.Label (new Rect (0,64,100,50), "city 1 wants Graan " + MyVar);
	}
}
