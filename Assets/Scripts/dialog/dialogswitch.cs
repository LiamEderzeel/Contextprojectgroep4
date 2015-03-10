using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class dialogswitch : MonoBehaviour {

	//dialog actors
	public Sprite ActorLeft;
	public Sprite ActorRight;
	//collection of strings that the actors need to speak
	public string[] ActorText;
	//1 is high, 0 is low.
	public int[] ActorPitch;
	private GameObject aLeft;
	private GameObject aRight;

	//op welke plek de dialog speelt
	private int dialogIndex = 0;

	public AudioClip audioLow;
	public AudioClip audioHigh;

	// Use this for initialization
	void Start ()
	{
		aLeft = transform.FindChild ("actorLeft").gameObject;
		aRight = transform.FindChild ("actorRight").gameObject;
		aLeft.GetComponent<Image> ().sprite = ActorLeft;
		aRight.GetComponent<Image> ().sprite = ActorRight;
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

				//knip audio off
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

			setAudioPitch(dialogIndex);
			audio.Play ();
		}


	}

	void setAudioPitch(int i)
	{
		if (ActorPitch [i] == 1)
			audio.clip = audioHigh;
		else if (ActorPitch [i] == 0)
			audio.clip = audioLow;
	}

}