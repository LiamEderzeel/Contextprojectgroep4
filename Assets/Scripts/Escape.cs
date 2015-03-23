using UnityEngine;
using System.Collections;

public class Escape : MonoBehaviour {

	private bool used = false;

	public enum escapeType
	{
		Worst,
		Leger,
		Propaganda
	};

	public escapeType EscapeType;

	public GameObject Dialogsaus;

	// Use this for initialization
	void Start () {
		Dialogsaus.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (used) {
			SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
			Color c = sr.material.color;
			c.a = 0.25f;
			sr.material.color = c;
		}
	}

	void OnMouseDown(){
		if (!used) {
			used = true;
			Dialogsaus.SetActive (true);
			Player.AvailableEscapes--;
		}
	}

	public bool isUsed
	{
		get { return used;}
	}
}