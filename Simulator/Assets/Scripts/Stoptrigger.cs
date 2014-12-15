using UnityEngine;
using System.Collections;

public class Stoptrigger : MonoBehaviour {

	public bool stopping = true;
	public TrafficLightLamp lamp;

	void OnTriggerEnter(Collider other)
	{
		NavMeshAgent nav = other.gameObject.GetComponent<NavMeshAgent>();
		if(stopping && nav != null)
		{
			nav.Stop();
		}
		else
		{
			nav.Resume();
		}
	}

	void OnTriggerStay(Collider other)
	{
		NavMeshAgent nav = other.gameObject.GetComponent<NavMeshAgent>();
		if(stopping && nav != null)
		{
			nav.Stop();
		} 
		else 
		{
			nav.Resume();
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		NavMeshAgent nav = other.gameObject.GetComponent<NavMeshAgent>();
		nav.Resume();
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch(lamp.currentColour)
		{
		case TrafficLightLamp.Colours.Groen:
			this.stopping = false;
			break;

		case TrafficLightLamp.Colours.Oranje:
			this.stopping = true;
			break;

		case TrafficLightLamp.Colours.Rood:
			this.stopping = true;
			break;
		}
	}
}
