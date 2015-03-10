using UnityEngine;
using System.Collections;

public class dialogswitch : MonoBehaviour {

	GameObject s;

	// Use this for initialization
	void Start ()
	{
		s = GameObject.Find ("dialogoverlay");
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnMouseDown()
	{
		//s.renderer.enabled = !s.renderer.enabled;
		s.SetActive (false);
	}
}