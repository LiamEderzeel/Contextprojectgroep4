using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour {

	dialogswitch dia1;
	dialogswitch dia2;



	// Use this for initialization
	void Start () {
		dia1 = transform.FindChild ("dia1").gameObject.GetComponent<dialogswitch> ();
		dia2 = transform.FindChild ("dia2").gameObject.GetComponent<dialogswitch> ();
		//dia1.gameObject.SetActive (false);
		dia2.gameObject.SetActive (false);

		Player.sInstructions = this.gameObject;
		Player.sInstructions.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (dia2) {
			if (!dia1 && !dia2.gameObject.activeSelf) {
				dia2.gameObject.SetActive (true);
			}
		}
	}

	void OnMouseDown()
	{
		if (!dia2) {
			Player.GameState = Player.gameState.Ingame;
			this.gameObject.SetActive (false);
		}
	}
}