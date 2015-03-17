using UnityEngine;
using System.Collections;

public class DialogSystem : MonoBehaviour {


	ArrayList Dialogs = new ArrayList();

	// Use this for initialization
	void Start () {
		//inladen van elke 
		foreach (Transform child in this.gameObject.transform) {
			Dialogs.Add (child.gameObject);
			//child.gameObject.SetActive(false);
		}

		//int banana = Random.Range (1, Dialogs.Count);
		//GameObject dia = (GameObject)Dialogs [banana];
		//dia.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
