using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour {

	public enum Grondstof
	{
		Graan,
		Vlees,
		Water
	}
	public Grondstof ResourceType;

	// Use this for initialization
	void Start () {

	}
	// Update is called once per frame
	void Update () {

	}
	void OnGUI ()
	{
		Vector2 boxPosition = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);

		GUIStyle ResourceName = new GUIStyle();
		ResourceName.alignment = TextAnchor.UpperCenter;
		ResourceName.normal.textColor = Color.cyan;

		if(ResourceType == Grondstof.Graan)
			GUI.Label (new Rect(boxPosition.x - 40,Screen.height - boxPosition.y-50,80,50),"Graan",ResourceName);
		else if(ResourceType == Grondstof.Vlees)
			GUI.Label (new Rect(boxPosition.x - 40,Screen.height - boxPosition.y-50,80,50),"Vlees",ResourceName);
		else if(ResourceType == Grondstof.Water)
			GUI.Label (new Rect(boxPosition.x - 40,Screen.height - boxPosition.y-50,80,50),"Water",ResourceName);
	}

	void OnMouseDown() {
		if (ResourceType == Grondstof.Graan)
			Player.resource_1 += 50;
		else if (ResourceType == Grondstof.Vlees)
			Player.resource_2 += 50;
		else if (ResourceType == Grondstof.Water)
			Player.resource_3 += 50;
	}
}