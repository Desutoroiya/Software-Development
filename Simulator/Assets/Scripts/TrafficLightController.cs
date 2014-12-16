using UnityEngine;
using System.Collections;

public class TrafficLightController : MonoBehaviour {

	private Client network;
	public OutMessageBehaviour outMessage;
	public float delay = 0.3f;
	private int count;
	private int lastCount;
	private float time;

	// Use this for initialization
	void Start () {
		network = GameObject.FindObjectOfType (typeof(Client)) as Client;
	}

	void OnTriggerEnter(Collider other)
	{
		count++;
	}

	void OnTriggerExit(Collider other)
	{
		count--;
	}

	void Sending()
	{
		OutMessage outmes = new OutMessage ();
		outmes.num = outMessage.num;
		outmes.inbound = outMessage.inBound;
		outmes.outbound = outMessage.outBound;
		outmes.vehicle = outMessage.vehicle;
		outmes.count = count;
		outMessage.count = count;

		network.sendMessage (outmes.toMessage ());
	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if(time > delay && lastCount != count)
		{
			Sending();
			lastCount = count;
			time = 0;
		}

	}
}
