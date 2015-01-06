using UnityEngine;
using System.Collections;

public class Spoorboom : MonoBehaviour {

	public CrossingBoom[] spoorbomen;
	public Stoptrigger[] stopTriggers;
	public TrafficLightLamp[] lampManagers;
	private bool wasOpen = true;
	public bool open = true;
	private bool fullOpened;
	public float openingTime = 5.0f;
	private float openingCounter = 0.0f;
	
	// Update is called once per frame
	void Update () {
		if(!fullOpened){
			openingCounter+=Time.deltaTime;
			if(openingCounter > openingTime){
				fullOpened = true;
				setDrive (true);
			}
		}
		if(open != wasOpen){
			wasOpen = open;
			if(open){
				setBarriers (true);
				fullOpened = false;
				openingCounter = 0.0f;
			} else {
				setDrive(false);
				setBarriers(false);
				fullOpened = true;
			}
		}
	}
	
	private void setDrive (bool value){
		foreach(Stoptrigger trigger in stopTriggers){
			trigger.stopTrain = !value;
		}
	}
	
	private void setBarriers (bool value){
		foreach(CrossingBoom spoorboom in spoorbomen){
			spoorboom.open = value;
		}
	}
}
