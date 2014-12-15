﻿using UnityEngine;
using System.Collections;


public class TrafficLightLamp : MonoBehaviour {
	
	// Use this for initialization
	private Material rood;
	private Material oranje;
	private Material groen;	
	//public InMessageBehaviour TrafficLightID;
	
	public enum Colours{ Rood, Oranje, Groen }
	public Colours nextColour = Colours.Rood;
	[HideInInspector]
	private Colours currentColour = Colours.Groen;
	void Start () {
		//TrafficLightID = gameObject.GetComponent<InMessageBehaviour> ();
		foreach (Transform child in transform) {
				if (child.gameObject.name == "Rood") {
						rood = child.transform.renderer.material;
				}
				if (child.gameObject.name == "Oranje") {
						oranje = child.transform.renderer.material;
				}
				if (child.gameObject.name == "Groen") {
						groen = child.transform.renderer.material;
				}
		}

	}
	public void changeColour (InMessage.Settings colours){
		switch (colours){
		case InMessage.Settings.Rood:
			changeColour(Colours.Rood);
			break;
		case InMessage.Settings.Oranje:
			changeColour(Colours.Oranje);
			break;
		case InMessage.Settings.Groen:
			changeColour(Colours.Groen);
			break;
		}
	}
	public void changeColour (Colours colour){
		rood.color = Color.black;
		oranje.color = Color.black;
		groen.color = Color.black;
		switch(colour){
		case Colours.Rood:
			rood.color = Color.red;
			break;
		case Colours.Oranje:
			oranje.color = Color.yellow;
			break;
		case Colours.Groen:
			groen.color = Color.green;
			break;
		}
	}
	// Update is called once per frame
	void Update () {
		if(nextColour != currentColour){
			changeColour(nextColour);
			currentColour = nextColour;
		}
	}
}