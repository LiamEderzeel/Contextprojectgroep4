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



	GameObject s;
	private Texture boxTexture;


	private int dialogIndex = 0;

	// Use this for initialization
	void Start ()
	{

		//snippet ActorLeft = Resources.Load<Sprite> ("Sprites/voedsel");

		aLeft = transform.FindChild ("actorLeft").gameObject;
		aRight = transform.FindChild ("actorRight").gameObject;
		aLeft.GetComponent<Image> ().sprite = ActorLeft;
		aRight.GetComponent<Image> ().sprite = ActorRight;


		boxTexture = Resources.Load<Texture> ("Sprites/dialog/textframe");

		s = GameObject.Find ("dialogoverlay");
		text_line = ActorText [dialogIndex];
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
			}
		}

		GameObject g = GameObject.Find ("dialogText");
		g.GetComponent<Text>().text = text_temp;
	}
	//bool b = false;

	public void incrementDialog()
	{
		Debug.Log ("hoi");
		//s.renderer.enabled = !s.renderer.enabled;
		//s.SetActive (b);
		//b = !b;

		if (!text_scrolling && dialogIndex + 1 < ActorText.Length) {
			text_scrolling = true;
			dialogIndex++;
			//laden van tekst in een tijdelijke string.
			text_line = ActorText [dialogIndex]; 
		}
	}


}