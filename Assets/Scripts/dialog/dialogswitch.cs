using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class dialogswitch : MonoBehaviour {

	//dialog actors
	public Sprite ActorLeft;
	public Sprite ActorRight;
	public Sprite Background;
	//collection of strings that the actors need to speak
	public string[] ActorText;
	//1 is high, 0 is low.
	public int[] ActorPitch;
	//private GameObject aLeft;
	//private GameObject aRight;

	//op welke plek de dialog speelt
	private int dialogIndex = 0;

	public AudioClip audioLow;
	public AudioClip audioHigh;

	// Use this for initialization
	void Start ()
	{
		transform.FindChild ("ActorLeft").gameObject.GetComponent<SpriteRenderer> ().sprite = ActorLeft;
		transform.FindChild ("ActorRight").gameObject.GetComponent<SpriteRenderer> ().sprite = ActorRight;
		transform.FindChild ("DialogBackground").gameObject.GetComponent<SpriteRenderer> ().sprite = Background;

		text_line = ActorText [dialogIndex];
		audio.loop = true;
		setAudioPitch(dialogIndex);
		audio.Play ();
		text_scrolling = true;
	}

	//text scrolling values.
	bool text_scrolling = false;
	float text_index = 0f;
	string text_line; //tijdelijke complete tekstregel
	string text_temp; //afgeknipte regel die door de gui wordt weergeven.

	// Update is called once per frame
	void Update ()
	{
		//laat de dialoogtekst scrollen.
		if (text_scrolling) {
			if (text_index <= text_line.Length) {
				text_temp = text_line.Substring (0, (int)text_index);
				text_index ++;
			} else {
				text_index = 0;
				text_scrolling = false;
				audio.Stop ();
			}
		}
		GameObject g = GameObject.Find ("dialogText");
		g.GetComponent<Text>().text = text_temp;
	}

	//schuift de dialogregels een op
	public void incrementDialog()
	{
		if (!text_scrolling && dialogIndex + 1 < ActorText.Length) {
			text_scrolling = true;
			dialogIndex++;
			//laden van tekst in een tijdelijke string.
			text_line = ActorText [dialogIndex];
			setAudioPitch (dialogIndex);
			audio.Play ();
		} else if (dialogIndex + 1 >= ActorText.Length) {
			Debug.Log("einde van dialog - dialogswitch.cs");
			Destroy(this.gameObject);
			//in principe verder met de game zelf.
			if (Player.GameState == Player.gameState.Dialog) {
				Player.GameState = Player.gameState.Ingame;
				Player.sDialog.SetActive(false);
			}
			else if (Player.GameState == Player.gameState.Rioting) {
				Player.ResetCities();
				Player.GameState = Player.gameState.Ingame;
				Player.CityIsRioting = false;
				GameObject.Find("sRiot").gameObject.SetActive (false);
			}
		}
	}

	void setAudioPitch(int i)
	{
		if (ActorPitch [i] == 1)
			audio.clip = audioHigh;
		else if (ActorPitch [i] == 0)
			audio.clip = audioLow;
	}

	void OnMouseDown()
	{
		incrementDialog ();
	}
}