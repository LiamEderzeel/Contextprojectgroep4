using UnityEngine;
using System.Collections;

public class month_counter : MonoBehaviour {

	private int Month = 0;
	private int SecondsPerMonth = 15;

	private float c = 0;

	private bool timerRunning = false;

	// Use this for initialization
	void Start () {
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
			}
			else
			{
				Debug.Log (Month);
			}
		}

	}
}