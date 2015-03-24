using UnityEngine;
using System.Collections;

public class Stats_City : MonoBehaviour {

	public City AttachedCity;

	//badges
	private SpriteRenderer bT;
	private SpriteRenderer bO;
	//counters
	private doubleDigitCounter cT;
	private doubleDigitCounter cO;

	// Use this for initialization
	void Start () {
		bT = this.gameObject.transform.FindChild ("badgeT").gameObject.GetComponent<SpriteRenderer> ();
		bO = this.gameObject.transform.FindChild ("badgeO").gameObject.GetComponent<SpriteRenderer> ();
		cT = this.gameObject.transform.FindChild ("counterT").gameObject.GetComponent<doubleDigitCounter> ();
		cO = this.gameObject.transform.FindChild ("counterO").gameObject.GetComponent<doubleDigitCounter> ();
		if (!AttachedCity)
			AttachedCity = this.gameObject.transform.parent.gameObject.GetComponent<City> ();
	}
	
	// Update is called once per frame
	void Update () {
		cT.Value = AttachedCity.rc.Tekort;
		cO.Value = AttachedCity.rc.Overschot;
		Sprite sT = Resources.Load<Sprite> ("Sprites/voedsel");
		Sprite sO = Resources.Load<Sprite> ("Sprites/voedsel");

		if (AttachedCity.rc.Tekort > 0) {
			if (AttachedCity.rc.TekortType == Player.Grondstof.Voedsel)
				sT = Resources.Load<Sprite> ("Sprites/voedsel");
			else if (AttachedCity.rc.TekortType == Player.Grondstof.Textiel)
				sT = Resources.Load<Sprite> ("Sprites/textiel");
			else if (AttachedCity.rc.TekortType == Player.Grondstof.Steenkool)
				sT = Resources.Load<Sprite> ("Sprites/steenkool");
			else
				sT = null;
		}
		else
			sT = null;

		if (AttachedCity.rc.Overschot > 0) {
			if (AttachedCity.rc.OverschotType == Player.Grondstof.Voedsel)
				sO = Resources.Load<Sprite> ("Sprites/voedsel");
			else if (AttachedCity.rc.OverschotType == Player.Grondstof.Textiel)
				sO = Resources.Load<Sprite> ("Sprites/textiel");
			else if (AttachedCity.rc.OverschotType == Player.Grondstof.Steenkool)
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
