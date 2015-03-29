using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour {

	int counter = 3;

	dialogswitch dia1;
	dialogswitch dia2;

	GameObject dia3;
	GameObject dia4;
	GameObject dia5;


	// Use this for initialization
	void Start () {
		dia1 = transform.FindChild ("dia1").gameObject.GetComponent<dialogswitch> ();
		dia2 = transform.FindChild ("dia2").gameObject.GetComponent<dialogswitch> ();

		dia3 = transform.FindChild ("dia3").gameObject;
		dia4 = transform.FindChild ("dia4").gameObject;
		dia5 = transform.FindChild ("dia5").gameObject;

		//dia1.gameObject.SetActive (false);
		dia2.gameObject.SetActive (false);
		dia3.gameObject.SetActive (false);
		dia4.gameObject.SetActive (false);
		dia5.gameObject.SetActive (false);

		Player.sInstructions = this.gameObject;
		Player.sInstructions.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (dia2) {
			if (!dia1 && !dia2.gameObject.activeSelf) {
				dia2.gameObject.SetActive (true);
			}
		} else if (counter < 0) {
			counter = 3;
		}

		if (counter == 3 && !dia3.activeSelf)
			dia3.SetActive (true);
		else if (counter != 3 && dia3.activeSelf)
			dia3.SetActive (false);
		if (counter == 4 && !dia4.activeSelf)
			dia4.SetActive (true);
		else if (counter != 4 && dia4.activeSelf)
			dia4.SetActive (false);
		if (counter == 5 && !dia5.activeSelf)
			dia5.SetActive (true);
		else if (counter != 5 && dia5.activeSelf)
			dia5.SetActive (false);
	}

	void OnMouseDown()
	{
		if (counter < 5) {
			counter++;
		} else {
			Player.GameState = Player.gameState.Ingame;
			this.gameObject.SetActive (false);
		}
	}
}