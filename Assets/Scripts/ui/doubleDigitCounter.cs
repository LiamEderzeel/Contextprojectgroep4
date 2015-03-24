using UnityEngine;
using System.Collections;

public class doubleDigitCounter : MonoBehaviour {

	public int Value;
	public string DigitFolder;
	public bool HideZero = false;
	public Color fontcolor = new Color (255, 0, 0);

	//private

	Sprite[] imageCollection = new Sprite[10];

	SpriteRenderer numLow;
	SpriteRenderer numHigh;

	// Use this for initialization
	void Start () {
		//gameobjects van de nummers zoeken zodat we de sprites kunnen veranderen
		numLow = transform.FindChild("numLow").gameObject.GetComponent<SpriteRenderer> ();
		numHigh = transform.FindChild("numHigh").gameObject.GetComponent<SpriteRenderer> ();

		if (DigitFolder == "" || DigitFolder == null)
			DigitFolder = "Sprites/ui/font_counter/";

		//plaatjes inladen voor het font

		for (int i=0; i < 10; i++)
			imageCollection [i] = Resources.Load<Sprite> (DigitFolder + i);
	}
	
	// Update is called once per frame
	void Update () {
		//waarde van 2 digits kan max 99 zijn
		Value = Mathf.Clamp (Value, 0, 99);
		//forex 25
		int intLow  = Value % 10; //5
		int intHigh = Value / 10; //2

		numLow.sprite = imageCollection [intLow];
		numHigh.sprite = imageCollection [intHigh];

		numLow.color = fontcolor;
		numHigh.color = fontcolor;

		if (HideZero && intLow == 0 && intHigh == 0) {
			numLow.GetComponent<SpriteRenderer> ().sprite = null;
			numHigh.GetComponent<SpriteRenderer> ().sprite = null;
		}

	}
}
