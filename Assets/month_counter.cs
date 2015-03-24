using UnityEngine;
using System.Collections;

public class month_counter : MonoBehaviour {

	private int Month = 0;
	private int SecondsPerMonth = 15;

	private float c = 0;

	private bool timerRunning = false;

	Sprite[] imageCollection = new Sprite[12];

	SpriteRenderer s;

	// Use this for initialization
	void Start () {
		s = this.gameObject.GetComponent<SpriteRenderer> ();
		//plaatjes inladen voor het font
		for (int i=1; i < imageCollection.Length; i++)
			imageCollection [i-1] = Resources.Load<Sprite> ("Sprites/ui/font_months/" + i);
	}
	
	// Update is called once per frame
	void Update () {
		if (Player.GameState == Player.gameState.Ingame) {
			c += Time.deltaTime * 1f;
			if (c >= SecondsPerMonth) {
				c = 0;
				Month++;
			}
			if (Month > 11) {
				Debug.Log ("gewonnen");
				Player.GameState = Player.gameState.Gewonnen;
				Player.sGewonnen.SetActive(true);
			}
			/*else
			{
				Debug.Log (Month);
			}
			*/
		}

		s.sprite = imageCollection [Month];
	}
}