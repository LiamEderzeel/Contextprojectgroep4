using UnityEngine;
using System.Collections;

public class LifeCounter : MonoBehaviour {

	public City AttachedCity;

	GameObject bar;

	// Use this for initialization
	void Start () {
		bar = transform.Find ("life_high").gameObject;
		//if (!AttachedCity)
		AttachedCity = this.gameObject.transform.parent.gameObject.GetComponent<City> ();
	}

	// Update is called once per frame
	void Update () {
		float percentage = (float)AttachedCity.CityHP / 100f;
		bar.transform.localScale = new Vector3(percentage, 1, 1);
		Debug.Log (percentage);
	}
}