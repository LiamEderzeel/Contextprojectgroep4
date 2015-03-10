using UnityEngine;
using System.Collections;

public class dialogswitch : MonoBehaviour {

	//dialog actors
	private Sprite ActorLeft;
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

		ActorLeft = Resources.Load<Sprite> ("Sprites/voedsel");

		aLeft = transform.FindChild ("actorLeft").gameObject;
		aRight = transform.FindChild ("actorRight").gameObject;
		aLeft.GetComponent<SpriteRenderer> ().sprite = ActorLeft;
		aRight.GetComponent<SpriteRenderer> ().sprite = ActorRight;


		boxTexture = Resources.Load<Texture> ("Sprites/dialog/textframe");

		s = GameObject.Find ("dialogoverlay");
	}
	
	// Update is called once per frame
	void Update ()
	{


	}
	bool b = false;

	void OnMouseDown()
	{
		//s.renderer.enabled = !s.renderer.enabled;
		//s.SetActive (b);
		//b = !b;

		if (dialogIndex + 1 < ActorText.Length)
			dialogIndex++;
	}

	void OnGUI ()
	{
		//if (s.activeSelf) {
			Vector2 boxPosition = Camera.main.WorldToScreenPoint (this.gameObject.transform.position);
			GUIStyle ResourceName = new GUIStyle ();
			ResourceName.alignment = TextAnchor.UpperCenter;
			ResourceName.normal.textColor = Color.cyan;
			ResourceName.wordWrap = true;

		GUI.DrawTexture(new Rect (50, Screen.height - 100, Screen.width - 100, 50), boxTexture, ScaleMode.StretchToFill, true, 10.0F);

			GUI.Box (new Rect (50, Screen.height - 100, Screen.width - 100, 50), ActorText[dialogIndex], ResourceName);
		//}
	}
}