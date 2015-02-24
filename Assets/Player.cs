using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	

	int resource_1;
	int resource_2;
	int resource_3;

	// Use this for initialization
	void Start ()
	{
		resource_1 = 0;
		resource_2 = 0;
		resource_3 = 0;

		
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
				if(resource_1 > 0 && City.City1RequestResource_1 > 0)
				{
					resource_1 = resource_1 - City.City1RequestResource_1;
				}
				if(resource_2 > 0 && City.City1RequestResource_2 > 0)
				{
					resource_2 = resource_2 - City.City1RequestResource_2;
				}
				if(resource_3 > 0 && City.City1RequestResource_3 > 0)
				{
					resource_3 = resource_3 - City.City1RequestResource_3;
				}
				//City.City1RequestResource_1 = 0;
				//City.City1RequestResource_2 = 0;
				//City.City1RequestResource_3 = 0;
				Debug.Log("RequestResource_1" + City.City1RequestResource_1);
				Debug.Log("RequestResource_2" + City.City1RequestResource_2);
				Debug.Log("RequestResource_3" + City.City1RequestResource_3);
			}
			else if (hit.collider.name == "City_2")
			{
				if(resource_1 > 0 && City.City2RequestResource_1 > 0)
				{
					resource_1 = resource_1 - City.City2RequestResource_1;
				}
				else if(resource_2 > 0 && City.City2RequestResource_2 > 0)
				{
					resource_2 = resource_2 - City.City2RequestResource_2;
				}
				else if(resource_3 > 0 && City.City2RequestResource_3 > 0)
				{
					resource_3 = resource_3 - City.City2RequestResource_3;
				}
				//City.City2RequestResource_1 = 0;
				//City.City2RequestResource_2 = 0;
				//City.City2RequestResource_3 = 0;
			}
			else if (hit.collider.name == "City_3")
			{
				if(resource_1 > 0 && City.City3RequestResource_1 > 0)
				{
					resource_1 = resource_1 - City.City3RequestResource_1;
				}
				else if(resource_2 > 0 && City.City3RequestResource_2 > 0)
				{
					resource_2 = resource_2 - City.City3RequestResource_2;
				}
				else if(resource_3 > 0 && City.City3RequestResource_3 > 0)
				{
					resource_3 = resource_3 - City.City3RequestResource_3;
				}
				//City.City3RequestResource_1 = 0;
				//City.City3RequestResource_2 = 0;
				//City.City3RequestResource_3 = 0;
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
	void OnGUI ()
	{
		GUIStyle Resouces = new GUIStyle();
		Resouces.alignment = TextAnchor.UpperLeft;
		Resouces.normal.textColor = Color.white;

		GUI.Label (new Rect (0,0,60,50), "Graan " + resource_1,Resouces);
		GUI.Label (new Rect (80,0,60,50), "Vlees " + resource_2,Resouces);
		GUI.Label (new Rect (160,0,60,50), "Water " + resource_3,Resouces);
	}
}
