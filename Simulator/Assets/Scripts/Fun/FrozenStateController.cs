using UnityEngine;
using System.Collections;

public class FrozenStateController : MonoBehaviour {
	public GameObject snowman;
	public GameObject notASnowman;
	public int state = 0;
	private int width = 300;
	private int height = 70;
	public AudioClip knock;
	private float knockDelay;
	public AudioClip first;
	public AudioClip second;
	public AudioClip bye;
	public AudioSource AC;
	private float time;
	private bool knockBool;
	// Use this for initialization
	void Start () {
		knockDelay = knock.length;
	}
	
	// Update is called once per frame
	void Update () {
		if(knockBool){
			time += Time.deltaTime;
		}
	}

	public bool play = false;

	void OnGUI () {
		if(play){
			state = 0;
			play = false;
		}
		var centeredStyle = GUI.skin.GetStyle("Label");
		centeredStyle.alignment = TextAnchor.UpperCenter;
		var centeredStyleButton = GUI.skin.GetStyle("Button");
		centeredStyleButton.alignment = TextAnchor.UpperCenter;
		switch (state){
		case 0:
			if(Input.GetKey(KeyCode.F)){
				state = 1;
				AC.PlayOneShot(knock);
			}
			break;
		case 1:
			knockBool = true;
			if(time > knockDelay){
				state = 2;
				AC.PlayOneShot(first);
			}
			break;
		case 2:
			GUI.Box(new Rect((Screen.width/2) - (width/2), (Screen.height/2) - (height/2), width, height), "");
			GUI.Label(new Rect(((Screen.width/2) - (width/2)) + 50, ((Screen.height/2) - (height/2)) + 10, 200, 40), "Do you want to build a snowman?", centeredStyle);
			if(GUI.Button(new Rect((Screen.width/2) + 30, ((Screen.height/2) + (height/2) + 20) - 50, 50, 20), "Yes", centeredStyleButton)){
				snowman.SetActive(true);
				state = 0;
			}
			if(GUI.Button(new Rect(((Screen.width/2)-50) - 30, ((Screen.height/2) + (height/2) + 20) - 50, 50, 20), "No", centeredStyleButton)){
				snowman.SetActive(false);
				state = 3;
				AC.PlayOneShot(second);
			}
			break;
		case 3:
			GUI.Box(new Rect((Screen.width/2) - (width/2), (Screen.height/2) - (height/2), width, height), "");
			GUI.Label(new Rect(((Screen.width/2) - (width/2)) + 50, ((Screen.height/2) - (height/2)) + 10, 200, 40), "It doesn't have to be a snowman...", centeredStyle);
			if(GUI.Button(new Rect((Screen.width/2) + 30, ((Screen.height/2) + (height/2) + 20) - 50, 50, 20), "Ok", centeredStyleButton)){
				notASnowman.SetActive(true);
				state = 0;
			}
			if(GUI.Button(new Rect(((Screen.width/2)-50) - 30, ((Screen.height/2) + (height/2) + 20) - 50, 50, 20), "No", centeredStyleButton)){
				notASnowman.SetActive(false);
				AC.PlayOneShot(bye);
				state = 0;
			}
			break;
		default:
			break;
		}
	}
	public void buildSnowman(bool doYouWanToBuildASnowman){
		this.gameObject.renderer.enabled = doYouWanToBuildASnowman;
	}
}
