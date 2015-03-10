using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour {
	
	public enum Grondstof
	{
		Voedsel,
		Textiel,
		Steenkool
	}
	public Grondstof ResourceType;
	private bool ResourceRequested;
	private ResourceGenerator rg;
	// Use this for initialization
	void Start () {
		ResourceRequested = false;
		rg = new ResourceGenerator ();
	}
	// Update is called once per frame
	void Update () {
		if (!rg.Done && ResourceRequested) {
			rg.Tick ();
		}
		else if (rg.Done && ResourceRequested) {
			ResourceRequested = false;
			if (ResourceType == Grondstof.Voedsel)
				Player.resource_1 += rg.Amount;
			else if (ResourceType == Grondstof.Textiel)
				Player.resource_2 += rg.Amount;
			else if (ResourceType == Grondstof.Steenkool)
				Player.resource_3 += rg.Amount;
		}
	}
	
	void OnGUI ()
	{
		Vector2 boxPosition = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
		
		GUIStyle ResourceName = new GUIStyle();
		ResourceName.alignment = TextAnchor.UpperCenter;
		ResourceName.normal.textColor = Color.cyan;
		
		if(ResourceType == Grondstof.Voedsel)
			GUI.Label (new Rect(boxPosition.x - 40,Screen.height - boxPosition.y-50,80,50),"Graan",ResourceName);
		else if(ResourceType == Grondstof.Textiel)
			GUI.Label (new Rect(boxPosition.x - 40,Screen.height - boxPosition.y-50,80,50),"Vlees",ResourceName);
		else if(ResourceType == Grondstof.Steenkool)
			GUI.Label (new Rect(boxPosition.x - 40,Screen.height - boxPosition.y-50,80,50),"Water",ResourceName);
		
		if (ResourceRequested) {
			GUI.Label (new Rect(boxPosition.x - 40, Screen.height - boxPosition.y+50, 80, 50), "Percent: "+rg.PercentageDone, ResourceName);
		}
	}
	
	void OnMouseDown() {
		//kick timer aan
		if (!rg.Done) {
			ResourceRequested = true;
			rg = new ResourceGenerator ();
		}
	}
}

public class ResourceGenerator {
	
	float count = 0;
	float count_t = 3;
	
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