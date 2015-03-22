using UnityEngine;
using System.Collections;

public class Stats_City : MonoBehaviour {

	public GameObject watchedCity;
	private City c;

	//badges
	private SpriteRenderer bT;
	private SpriteRenderer bO;
	//counters
	private doubleDigitCounter cT;
	private doubleDigitCounter cO;

	// Use this for initialization
	void Start () {
		c = watchedCity.GetComponent<City> ();

		bT = this.gameObject.transform.FindChild ("badgeT").gameObject.GetComponent<SpriteRenderer> ();
		bO = this.gameObject.transform.FindChild ("badgeO").gameObject.GetComponent<SpriteRenderer> ();
		cT = this.gameObject.transform.FindChild ("counterT").gameObject.GetComponent<doubleDigitCounter> ();
		cO = this.gameObject.transform.FindChild ("counterO").gameObject.GetComponent<doubleDigitCounter> ();

	}
	
	// Update is called once per frame
	void Update () {
	 	cT.Value = c.rc.Tekort;
	 	cO.Value = c.rc.Overschot;
		Sprite sT = Resources.Load<Sprite> ("Sprites/voedsel");
		Sprite sO = Resources.Load<Sprite> ("Sprites/voedsel");

		if (c.rc.Tekort > 0) {
			if (c.rc.TekortType == Player.Grondstof.Voedsel)
				sT = Resources.Load<Sprite> ("Sprites/voedsel");
			else if (c.rc.TekortType == Player.Grondstof.Textiel)
				sT = Resources.Load<Sprite> ("Sprites/textiel");
			else if (c.rc.TekortType == Player.Grondstof.Steenkool)
				sT = Resources.Load<Sprite> ("Sprites/steenkool");
			else
				sT = null;
		}
		else
			sT = null;

		if (c.rc.Overschot > 0) {
			if (c.rc.OverschotType == Player.Grondstof.Voedsel)
				sO = Resources.Load<Sprite> ("Sprites/voedsel");
			else if (c.rc.OverschotType == Player.Grondstof.Textiel)
				sO = Resources.Load<Sprite> ("Sprites/textiel");
			else if (c.rc.OverschotType == Player.Grondstof.Steenkool)
				sO = Resources.Load<Sprite> ("Sprites/steenkool");
			else
				sO = null;
		} else {
			sO = null;
		}
		bT.sprite = sT;
		bO.sprite = sO;

	}
}
