using UnityEngine;
using System.Collections;

public class Cart : MonoBehaviour {
	private Vector3 endPosition;
	private Vector3 startPosition;
	
	private Vector3 currentWaypoint;
	private int currentIndex;
	
	public GameObject Waypoint;
	
	public Vector3[] waypoints = new Vector3[2];
	public float moveSpeed = 10.0f;
	public float minDistance = 2.0f;
	
	void Start () {
		currentWaypoint = waypoints[0];
		currentIndex = 0;
		waypoints[0] = Waypoint.transform.position;
		waypoints[1] = GameObject.Find ("Player").transform.position;
	}
	
	void Update () {
		
		MoveTowardWaypoint ();
		if (Vector3.Distance (currentWaypoint, transform.position) < minDistance) {
			print(currentIndex);
			++currentIndex;
			
			if(currentIndex == 2){
				Destroy(this.gameObject);
			} else {
				currentWaypoint = waypoints [currentIndex];
			}
		}
	}
	
	void MoveTowardWaypoint () {
		Vector3 direction = currentWaypoint - transform.position;
		Vector3 moveVector = direction.normalized * moveSpeed * Time.deltaTime;
		transform.position += moveVector;
	}
}