using UnityEngine;
using System.Collections;

public class Escape : MonoBehaviour {

	private bool used = false;

	// Use this for initialization
	void Start () {
	
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
		}
	}

	public bool isUsed
	{
		get { return used;}
	}
}