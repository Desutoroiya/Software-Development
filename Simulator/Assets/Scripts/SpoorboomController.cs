using UnityEngine;
using System.Collections;

public class SpoorboomController : MonoBehaviour {

	void OnTriggerExit(Collider other)
	{
		TrainController trainCont = (TrainController)other.gameObject.GetComponent (typeof(TrainController));
		if(trainCont != null)
		{
			trainCont.cleared = true;
		}
	}
}
