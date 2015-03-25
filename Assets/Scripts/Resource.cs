using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour {
	

	public Player.Grondstof ResourceType;

	public AudioClip audioWorking;

	private GameObject cartObject;
	private bool ResourceRequested;
	// Use this for initialization
	void Start () {
		ResourceRequested = false;
		if (ResourceType == Player.Grondstof.Voedsel)
			audioWorking = Resources.Load<AudioClip> ("Sounds/FX_voedsel");
		else if (ResourceType == Player.Grondstof.Textiel)
			audioWorking = Resources.Load<AudioClip> ("Sounds/FX_textiel");
		else if (ResourceType == Player.Grondstof.Steenkool)
			audioWorking = Resources.Load<AudioClip> ("Sounds/FX_kool");

		audio.clip = audioWorking;
	}
	// Update is called once per frame
	void Update () {
	}

	public void spawnResource()
	{
		int Amount = Random.Range (1, 3);
		ResourceRequested = false;
		if (ResourceType == Player.Grondstof.Voedsel)
			Player.resource_1 += Amount;
		else if (ResourceType == Player.Grondstof.Textiel)
			Player.resource_2 += Amount;
		else if (ResourceType == Player.Grondstof.Steenkool)
			Player.resource_3 += Amount;
	}

	void spawnCart () {

		//GameObject instance = Instantiate(Resources.Load("Riot")) as GameObject;
		Vector3 newPosition = this.gameObject.transform.position;
		Quaternion newRotation = Quaternion.identity;
		cartObject = (GameObject)Instantiate (Resources.Load ("Cart"), newPosition, newRotation);
		cartObject.GetComponent<Cart> ().attachedResource = this; //lazy as fuck jeweetzelf.
		cartObject.GetComponent<Cart> ().Waypoints = GetWaypoints ();
		cartObject.GetComponent<Cart> ().StartCart ();
	}

	public ArrayList GetWaypoints()
	{
		GameObject wc = transform.FindChild ("WaypointCollection").gameObject;
		ArrayList Waypoints = new ArrayList();
		
		foreach (Transform child in wc.gameObject.transform) {
			Waypoints.Add(child.position);
		}
		Waypoints.Insert(0, this.gameObject.transform.position); //Stad is begin.
		Waypoints.Add(GameObject.Find("Player").transform.position); //Player is eind.
		return Waypoints;
	}

	void OnMouseDown() {
		//kick timer aan
		if (!ResourceRequested && Player.GameState == Player.gameState.Ingame) {
			ResourceRequested = true;
			audio.Play();
			spawnCart();

			//Player.DobbelForDialog();
		}
	}
}