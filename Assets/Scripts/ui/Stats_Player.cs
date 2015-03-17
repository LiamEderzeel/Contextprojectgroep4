using UnityEngine;
using System.Collections;

public class Stats_Player : MonoBehaviour {

	public GameObject CounterVoedsel;
	public GameObject CounterTextiel;
	public GameObject CounterSteenkool;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CounterVoedsel.GetComponent<doubleDigitCounter> ().Value = Player.resource_1;
		CounterTextiel.GetComponent<doubleDigitCounter> ().Value = Player.resource_2;
		CounterSteenkool.GetComponent<doubleDigitCounter> ().Value = Player.resource_3;
	}
}
