using UnityEngine;
using System;
using System.Collections;

public class NavController : MonoBehaviour {
	public bool useBreak = true;
	public float breakSpeed = 0.0f;
	public Spawning spawner;
	public NavMeshAgent nav;
	public Transform target;
	public float mindist = 10.0f;
	public GameObject brakeLineStart;
	public GameObject brakeLineEnd;
	private GameObject[] wayPoints;
	private int wayPointIndex = 0;
	public GameObject Explosion;

	// Use this for initialization
	void Start(){
		normalSpeed = nav.speed;
	}
	
	// Update is called once per frame
	void Update () {
		try{
			if(Vector3.Distance(wayPoints[wayPointIndex].transform.position, transform.position) > mindist){
				//Nothing as of yet
			} else {
				nextWaypoint();
			}
		} catch (IndexOutOfRangeException e){
;
			Destroy(this.gameObject);
		}
		if(useBreak)
		{
			RaycastHit hitting;
			if(Physics.Linecast(brakeLineStart.transform.position,
			                    brakeLineEnd.transform.position))
			{
				nav.speed = hitting.distance/2 > breakSpeed ? hitting.distance/2 : breakSpeed;
				if(hitting.distance < 5)
				{
					nav.speed = breakSpeed;
				}
			}
		}
		else
		{
			nav.speed = normalSpeed;
		}
		//Debug.DrawLine(nav.steeringTarget, this.transform.position);
	}
	
	public void setWaypoints(GameObject[] wayPoints){
		this.wayPoints = wayPoints;
		wayPointIndex = 0;
		nav.SetDestination(wayPoints[wayPointIndex].transform.position);
	}
	
	private void nextWaypoint(){
		wayPointIndex++;
		try{
			nav.SetDestination(wayPoints[wayPointIndex].transform.position);
		} catch (NullReferenceException e){
			Destroy(this.gameObject);
		}
	}
	
	void OnDestroy(){
		try{
			spawner.carDestroyed();
		} catch (NullReferenceException e){
			Debug.Log("Car already destroyed!");
		}
	}
}
