using UnityEngine;
using System.Collections;

public class doubleDigitCounter : MonoBehaviour {

	public int Value;
	public string DigitFolder;
	public bool HideZero = false;

	//private

	Sprite[] imageCollection = new Sprite[10];

	GameObject numLow;
	GameObject numHigh;


	// Use this for initialization
	void Start () {
		//gameobjects van de nummers zoeken zodat we de sprites kunnen veranderen
		numLow = this.gameObject.transform.FindChild("numLow").gameObject;
		numHigh = this.gameObject.transform.FindChild("numHigh").gameObject;

		//plaatjes inladen voor het font
		for (int i=0; i < 10; i++)
			imageCollection [i] = Resources.Load<Sprite> ("Sprites/ui/font_hud/" + i);
	}
	
	// Update is called once per frame
	void Update () {
		//waarde van 2 digits kan max 99 zijn
		Mathf.Clamp (Value, 0, 99);
		//forex 25
		int intLow  = Value % 10; //5
		int intHigh = Value / 10; //2
		numLow.GetComponent<SpriteRenderer> ().sprite = imageCollection [intLow];
		numHigh.GetComponent<SpriteRenderer> ().sprite = imageCollection [intHigh];

		if (HideZero && intLow == 0 && intHigh == 0) {
			numLow.GetComponent<SpriteRenderer> ().sprite = null;
			numHigh.GetComponent<SpriteRenderer> ().sprite = null;
		}

	}
}
