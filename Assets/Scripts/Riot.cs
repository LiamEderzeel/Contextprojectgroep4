using UnityEngine;
using System.Collections;

public class Riot : MonoBehaviour {

	private Vector3 endPosition;
	private Vector3 startPosition;
	private float pos;
	private float speed = 0.05f;

	// Use this for initialization
	void Start () {
		//GameObject.Find("startPosotion").transform.position
		startPosition = this.gameObject.transform.position;
		endPosition = GameObject.Find("Player").transform.position;		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(startPosition, endPosition, pos);
		pos += speed * Time.deltaTime;
	}
}