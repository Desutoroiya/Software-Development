using UnityEngine;
using System.Collections;

public class Stoptrigger : MonoBehaviour {

	public bool stopping = true;
	public TrafficLightLamp lamp;
	public bool usageLamp = true;
	public bool stopTrain = false;

	void OnTriggerEnter(Collider other)
	{
		NavMeshAgent nav = other.gameObject.GetComponent<NavMeshAgent>();
		if((stopping || stopTrain) && nav != null)
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
		if((stopping || stopTrain) && nav != null)
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
		if(usageLamp)
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
}
