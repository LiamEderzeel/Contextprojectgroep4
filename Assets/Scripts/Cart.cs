using UnityEngine;
using System.Collections;

public class Cart : MonoBehaviour {
	private Vector3 endPosition;
	private Vector3 startPosition;
	
	private Vector3 currentWaypoint;
	private int currentIndex;
	
	public ArrayList Waypoints;
	public float moveSpeed = 10.0f;
	public float minDistance = 2.0f;

	public Resource attachedResource;

	void Start () {
		if (Player.dlc) {
			this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/cartdlc");
		}
	}
	
	public void StartCart()
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
				attachedResource.spawnResource();
				attachedResource.gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 1f);
				AudioSource.PlayClipAtPoint(Resources.Load<AudioClip> ("Sounds/FX_collect"), new Vector3(0,0,0));
				Destroy (this.gameObject);
			}
			else {
				currentWaypoint = (Vector3) Waypoints [currentIndex];
			}
		}
	}
	
	void MoveTowardWaypoint () {
		Vector3 direction = currentWaypoint - transform.position;
		Vector3 moveVector = direction.normalized * (Time.deltaTime * moveSpeed);
		transform.position += (moveVector);
	}
}