using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour {
	

	public Player.Grondstof ResourceType;

	public AudioClip audioWorking;

	private bool ResourceRequested;
	private ResourceGenerator rg;
	// Use this for initialization
	void Start () {
		ResourceRequested = false;
		rg = new ResourceGenerator ();

		if (ResourceType == Player.Grondstof.Voedsel)
			audioWorking = Resources.Load<AudioClip> ("Sounds/FX_voedsel");
		else if (ResourceType == Player.Grondstof.Textiel)
			audioWorking = Resources.Load<AudioClip> ("Sounds/FX_textiel");
		else if (ResourceType == Player.Grondstof.Steenkool)
			audioWorking = Resources.Load<AudioClip> ("Sounds/FX_kool");

		audio.clip = audioWorking;
	}
	// Update is called once per frame
	void Update () {
		if (!rg.Done && ResourceRequested) {
			rg.Tick ();
		}
		else if (rg.Done && ResourceRequested) {
			ResourceRequested = false;
			if (ResourceType == Player.Grondstof.Voedsel)
				Player.resource_1 += rg.Amount;
			else if (ResourceType == Player.Grondstof.Textiel)
				Player.resource_2 += rg.Amount;
			else if (ResourceType == Player.Grondstof.Steenkool)
				Player.resource_3 += rg.Amount;
		}
	}
	
	void OnGUI ()
	{
		Vector2 boxPosition = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
		
		GUIStyle ResourceName = new GUIStyle();
		ResourceName.alignment = TextAnchor.UpperCenter;
		ResourceName.normal.textColor = Color.black;
		
		if(ResourceType == Player.Grondstof.Voedsel)
			GUI.Label (new Rect(boxPosition.x - 40,Screen.height - boxPosition.y-50,80,50),"Voedsel",ResourceName);
		else if(ResourceType == Player.Grondstof.Textiel)
			GUI.Label (new Rect(boxPosition.x - 40,Screen.height - boxPosition.y-50,80,50),"Textiel",ResourceName);
		else if(ResourceType == Player.Grondstof.Steenkool)
			GUI.Label (new Rect(boxPosition.x - 40,Screen.height - boxPosition.y-50,80,50),"Steenkool",ResourceName);
		
		if (ResourceRequested) {
			GUI.Label (new Rect(boxPosition.x - 40, Screen.height - boxPosition.y+50, 80, 50), "Percent: "+rg.PercentageDone, ResourceName);
		}
	}
	
	void OnMouseDown() {
		//kick timer aan
		if (!ResourceRequested && Player.GameState == Player.gameState.Ingame) {
			ResourceRequested = true;
			rg = new ResourceGenerator ();
			audio.Play();
		}
	}
}

public class ResourceGenerator {
	
	float count = 0;
	float count_t = 1;
	
	public ResourceGenerator()
	{
		_amount = Random.Range (1, 10);
		_done = false;
	}
	
	public void Tick()
	{
		count += Time.deltaTime * 1;
		if (count >= count_t)
			_done = true;
	}
	
	public int PercentageDone
	{
		get{
			int p = (int)((count/count_t)*100);
			return p;
		}
	}
	
	//Protected waarde om te controleren of de generator klaar is
	private bool _done;
	public bool Done
	{
		get {
			return _done;
		}
	}
	
	//Protected hoeveelheid die hij geeft als de generator klaar is
	private int _amount;
	public int Amount {
		get {
			return _amount;
		}
	}
}