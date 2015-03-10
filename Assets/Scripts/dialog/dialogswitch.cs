using UnityEngine;
using System.Collections;

public class dialogswitch : MonoBehaviour {

	GameObject s;
	public Texture aTexture;

	// Use this for initialization
	void Start ()
	{
		s = GameObject.Find ("dialogoverlay");



	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	bool b = false;

	void OnMouseDown()
	{
		//s.renderer.enabled = !s.renderer.enabled;
		s.SetActive (b);
		b = !b;
	}

	void OnGUI ()
	{
		if (s.activeSelf) {
			Vector2 boxPosition = Camera.main.WorldToScreenPoint (this.gameObject.transform.position);
		
			GUIStyle ResourceName = new GUIStyle ();
			ResourceName.alignment = TextAnchor.UpperCenter;
			ResourceName.normal.textColor = Color.cyan;
			ResourceName.wordWrap = true;

			GUI.DrawTexture(new Rect (50, Screen.height - 100, Screen.width - 100, 50), aTexture, ScaleMode.StretchToFill, true, 10.0F);

			GUI.Box (new Rect (50, Screen.height - 100, Screen.width - 100, 50), "dit is een net te lang stuk tekst, ik hoop dat het zich op een gegeven moment gaat wrappen en dan kan ik gewoon simpelweg een dialog gui maken die dan de text zelf in een box zet met de juiste alignment enzovoorts. dat zou wel het mooiste zijn denk ik.", ResourceName);
		}
	}
}