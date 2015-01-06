using UnityEngine;
using System.Collections;

public class TrainController : MonoBehaviour {

	public Spoorboom sp;
	public bool cleared = false;
	private bool once = true;
	// Use this for initialization
	void Start () {
		if (GameObject.FindObjectsOfType (this.GetType ()).Length > 1)
						Destroy (this);
		sp.open = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(cleared && once) 
		{
			sp.open = true;
			once = false;
		}
	
	}
}
