using UnityEngine;
using System;
using System.Collections;

public class TrafficController {

	
	private TrafficLightLamp[] lights;
		
		public TrafficController() {
			lights = GameObject.FindObjectsOfType(typeof(TrafficLightLamp)) as TrafficLightLamp[];
			//Find all GameObjects with LampColourManager; all gameobjects that are lights.
		}
		
		public void printAll(){
			Debug.Log(lights.Length);
			for(int i  = 0; i < lights.Length; i++){
				try{
					Debug.Log(i + ": " + lights[i].LightID.inMessage.toString());
				} catch (NullReferenceException e) {
					Debug.Log(e.Message);
				}
			}
		}
		
		public void setLight(InMessage im){
			foreach(TrafficLightLamp light in lights){
				try{
					if(light.LightID.inMessage.vehicle  == im.vehicle &&
					   light.LightID.inMessage.inbound  == im.inbound &&
					   light.LightID.inMessage.outbound == im.outbound){
						light.changeColour(im.setting);
						//Check if light is same as requested,
						//set colour if so.
					}
				} catch (NullReferenceException e) {
					Debug.Log(e.Message);
				}
				
			}
		}
	}
