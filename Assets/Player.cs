using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	int resource_1;
	int resource_2;
	int resource_3;

	// Use this for initialization
	void Start () {
		resource_1 = 0;
		resource_2 = 0;
		resource_3 = 0;
	}	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Debug.Log("Pressed left click, casting ray.");
			CastRay();
		}
	}
	void CastRay() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100)) {
			Debug.DrawLine(ray.origin, hit.point);
			Debug.Log("Hit object: " + hit.collider.name);
			if(hit.collider.name == "Resource_1") {
				resource_1 ++;
			} else if (hit.collider.name == "Resource_2"){
				resource_2 ++;
			} else if (hit.collider.name == "Resource_3"){
				resource_3 ++;
			}
		}
	}


	void OnGUI () {
		GUI.Label (new Rect (0,0,100,50), "Graan " + resource_1);
		GUI.Label (new Rect (0,16,100,50), "Vlees " + resource_2);
		GUI.Label (new Rect (0,32,100,50), "Water " + resource_3);
	}
}
