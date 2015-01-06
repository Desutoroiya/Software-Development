using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour {

	public int maxAlive = 2;
	public int alive = 0;
	public GameObject spawnMe;
	private GameObject spawnMeInst;
	public GameObject targetWaypoint;
	private NavController navC;
	public float SpawnEvery = 5.0f;
	private float counter;
	private GameObject[] wayPoints;
	private int currentPoint;

	public bool messageTreinDelete = false;
	public bool selfSpawner = true;
	private Client net;
	public OutMessageBehaviour treinMessage;
	public bool isTrein = false;
	public Spoorboom sp;
	// Use this for initialization

	void sendMessage(int count)
	{
		if(isTrein)
		{
			net = GameObject.FindObjectOfType(typeof(Client)) as Client;
			OutMessage om = new OutMessage ();
			om.num = treinMessage.num;
			om.inbound = treinMessage.inBound;
			om.outbound = treinMessage.outBound;
			om.vehicle = treinMessage.vehicle;
			treinMessage.count = count;
			om.count = count;
			net.sendMessage (om.toMessage ());
		}
	}

	void Start () {
		spawnMeInst = (GameObject)Instantiate(spawnMe);
		spawnMeInst.SetActive(false);
		wayPoints = new GameObject[targetWaypoint.transform.childCount];
		
		int i = 0;
		foreach(Transform child in targetWaypoint.transform){
			wayPoints[i] = child.gameObject;
			i++;
		}
		/*for(int i = 0; i < targetWaypoint.transform.childCount; i++){
			wayPoints[i] = targetWaypoint.transform.GetChild(i).gameObject;
		}*/
		
		navC = spawnMeInst.GetComponent<NavController>();
		navC.target = targetWaypoint.transform;
		navC.setWaypoints(wayPoints);
		
		spawnMeInst.transform.position = this.transform.position;
		spawnMeInst.transform.rotation = this.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if(selfSpawner)
		{
			if(maxAlive >= 1)
			{
				counter += Time.deltaTime;
				if(counter > this.SpawnEvery)
				{
					if(alive < maxAlive)
					{
						spawner();
						counter = 0.0f;
						alive++;
					}
				}
			}
		}
	}


	public void spawner()
	{
		GameObject spawnee = (GameObject)Instantiate(spawnMeInst);
		if(isTrein)
		{
			TrainController tc = (TrainController)spawnee.GetComponent(typeof(TrainController));
			tc.sp = this.sp;
			sendMessage(1);
		}
		spawnee.SetActive(true);
		NavController nav = spawnee.GetComponent<NavController>();
		nav.setWaypoints(wayPoints);
		nav.spawner = this;
	}


	public void carDestroyed(){
		alive--;
	}
}