using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	public static int resource_1; //voedsel
	public static int resource_2; //textiel
	public static int resource_3; //steenkool

	public static bool CityIsRioting = false;
	public static bool GameOver = false;


	public enum gameState
	{
		Tile,
		Instructions,
		Ingame,
		Dialog,
		Gameover,
		Credits
	};

	public static gameState GameState;

	public enum Grondstof
	{
		Voedsel = 1,
		Textiel = 2,
		Steenkool = 3
	}

	// Use this for initialization
	void Start ()
	{
		//entry point for application

		GameState = gameState.Tile;

		resource_1 = 0;
		resource_2 = 0;
		resource_3 = 0;
	}	

	//raycaster voor resource adding.
	void CastRay()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100))
		{
			Resource HitGrondstof = hit.collider.GetComponent<Resource>();
			if (HitGrondstof == null)
				return;

			//Debug.DrawLine(ray.origin, hit.point);
			Debug.Log("Hit object: " + hit.collider.name);
			if (HitGrondstof.ResourceType == Grondstof.Voedsel)
				resource_1 ++;
			else if (HitGrondstof.ResourceType == Grondstof.Textiel)
				resource_2 ++;
			else if (HitGrondstof.ResourceType == Grondstof.Steenkool)
				resource_3 ++;
		}
	}
	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			//Debug.Log("Pressed left click, casting ray.");
			CastRay();
		}
	}
	/* //niet langer nodig, wordt opgevangen door het schildje
	void OnGUI ()
	{
		GUIStyle pGui = new GUIStyle();
		pGui.alignment = TextAnchor.UpperLeft;
		pGui.normal.textColor = Color.white;
		pGui.fontSize = Screen.height / 20;

		GUI.Label (new Rect (0, 0, 60, 50), "Voedsel " + resource_1, pGui);
		GUI.Label (new Rect (80, 0, 60, 50), "Textiel " + resource_2, pGui);
		GUI.Label (new Rect (160, 0, 60, 50), "Steenkool " + resource_3, pGui);

		if (GameOver) {
			pGui.normal.textColor = Color.red;
			GUI.Label (new Rect (Screen.width / 2, Screen.height / 4, 60, 50), "GAMEOVER", pGui);
		}
	}
	*/
}
