using UnityEngine;
using System.Collections;

public class counter : MonoBehaviour {

	public int val;
	public Sprite[] imageCollection = new Sprite[10];

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = imageCollection [val];
	}
}