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

	}

	void OnGUI () {
		GUI.Label (new Rect (0,0,100,50), "Graan " + resource_1);
		GUI.Label (new Rect (0,16,100,50), "Vlees " + resource_2);
		GUI.Label (new Rect (0,32,100,50), "Water " + resource_3);
	}
}
