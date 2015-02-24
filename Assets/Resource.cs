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

		//boxPosition.x = Screen.width - boxPosition.x;
		//boxPosition.y = Screen.height - boxPosition.y;

		GUIStyle ResourceName = new GUIStyle();
		ResourceName.alignment = TextAnchor.UpperCenter;
		ResourceName.normal.textColor = Color.cyan;

		if(ResourceType == Grondstof.Graan)
		{
			GUI.Label (new Rect(boxPosition.x - 40,Screen.height - boxPosition.y-25,80,50),"Graan",ResourceName);
		}
		if(ResourceType == Grondstof.Vlees)
		{
			GUI.Label (new Rect(boxPosition.x - 40,Screen.height - boxPosition.y-25,80,50),"Vlees",ResourceName);
		}
		if(ResourceType == Grondstof.Water)
		{
			GUI.Label (new Rect(boxPosition.x - 40,Screen.height - boxPosition.y-25,80,50),"Water",ResourceName);
		}
	}
}
