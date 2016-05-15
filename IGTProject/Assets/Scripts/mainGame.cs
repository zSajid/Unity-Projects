// This class will focus on controlling all of the game mechanics and such
using UnityEngine;
using System.Collections;

public class mainGame : MonoBehaviour {
	// Variables
	private GameObject mainMachine;
	private Player primaryPlayer;
	private int wonCash = 0;

	// Use this for initialization
	void Start () {
		primaryPlayer = new Player ();
		mainMachine= Instantiate(Resources.Load("PreFabs/slotMachine", typeof(GameObject))) as GameObject;
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI(){

		GUI.Label(new Rect(Screen.width/2, 5, 10+primaryPlayer.getCredit().ToString().Length * 23, 20), primaryPlayer.getCredit().ToString());

		if (GUI.Button (new Rect (5, 5, 200,50), "Add Credit")) {
			primaryPlayer.addCredit (100);
		}

		if (GUI.Button (new Rect (5, 65, 200,50), "Clear")) {
			primaryPlayer.clearCredit();
		}

			
			if (GUI.Button (new Rect (Screen.width / 2 + 100, Screen.height / 2 + 100, 100, 100), "Spin")) {
			if (primaryPlayer.getCredit () >= 10) {
				
				wonCash = 0;
				primaryPlayer.subtractCredit (10);
				wonCash = mainMachine.GetComponent<slotMachine> ().spin ();


				if (wonCash > 0) {
					primaryPlayer.addCredit (wonCash);

				}
			}
		}

		GUI.Label(new Rect(Screen.width/2 + 50, 5, 10+wonCash.ToString().Length * 23, 20), wonCash.ToString());

		//GUI.Box(new Rect(0,0,Screen.width,Screen.height), backgroundGUITexture);
	}
}
