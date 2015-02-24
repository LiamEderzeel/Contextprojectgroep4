using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour {

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
		ResourceName.normal.textColor = Color.white;

		if(this.gameObject.name == "Resource_1")
		{
			GUI.Label (new Rect(boxPosition.x - 40,Screen.height - boxPosition.y-25,80,50),"Graan",ResourceName);
		}
		if(this.gameObject.name == "Resource_2")
		{
			GUI.Label (new Rect(boxPosition.x - 40,Screen.height - boxPosition.y-25,80,50),"Vlees",ResourceName);
		}
		if(this.gameObject.name == "Resource_3")
		{
			GUI.Label (new Rect(boxPosition.x - 40,Screen.height - boxPosition.y-25,80,50),"Water",ResourceName);
		}
	}
}
