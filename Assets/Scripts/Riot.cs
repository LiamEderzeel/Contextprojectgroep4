using UnityEngine;
using System.Collections;

public class Riot : MonoBehaviour {
	private Vector3 endPosition;
	private Vector3 startPosition;
	
	private Vector3 currentWaypoint;
	private int currentIndex;

	public ArrayList Waypoints;
    public float moveSpeed = 10.0f;
	public float minDistance = 2.0f;

	void Start () {
	}

	public void StartRiot()
	{
		if (currentWaypoint != null)
			currentWaypoint = (Vector3)Waypoints [0];
		currentIndex = 0;
	}

	void Update () {
		MoveTowardWaypoint ();

		if (Vector3.Distance (currentWaypoint, transform.position) < minDistance) {
			currentIndex++;
			if (currentIndex == Waypoints.Count) {
				if (Player.AvailableEscapes > 0)
				{
					Player.GameState = Player.gameState.Rioting;
					Player.PlaySound ();
					Player.sRiot.SetActive(true);
				}
				else
				{
					Player.GameState = Player.gameState.Gameover;
					Player.PlaySound ();
					Player.sGameOver.SetActive(true);
				}
				Destroy (this.gameObject);
			}
			else {
				currentWaypoint = (Vector3) Waypoints [currentIndex];
			}
		}
	}

	void MoveTowardWaypoint () {

		Vector3 direction = currentWaypoint - transform.position;
		Vector3 moveVector = direction.normalized * moveSpeed * Time.deltaTime;
		transform.position += moveVector;
	}
}