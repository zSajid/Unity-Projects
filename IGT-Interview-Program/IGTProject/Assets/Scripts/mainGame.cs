// This class will focus on game logic
using UnityEngine;
using System.Collections;

public class mainGame : MonoBehaviour {
	// Holds the slot machine and real
	private GameObject mainMachine;

	// Holds the player credit amount
	private Player primaryPlayer;

	// Amount of money player won
	private int wonCash = 0;

	int tmp= 0;
	// If the spin button is already used, wait 3 seconds
	private int spinBusy = 0;

	// Use this for initialization
	void Start () {
		// Instantiate both a new player and main machine and get desired game object
		primaryPlayer = new Player ();
		mainMachine= Instantiate(Resources.Load("PreFabs/slotMachine", typeof(GameObject))) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (spinBusy == 2) {
			wonCash = mainMachine.GetComponent<slotMachine> ().payout ();
			// If cash is greater than 0 add it to total
			if (wonCash > 0) {
				primaryPlayer.addCredit (wonCash);
				spinBusy = 0;
			}

		}
	}

	void OnGUI(){
		GUI.Label(new Rect(Screen.width/2 - 105,2, 50, 20), "Credit");
		GUI.Label(new Rect(Screen.width/2 + 50, 2, 90, 20), "Win Amount");	
		GUI.Box(new Rect(Screen.width/2 - 105, 20, 10+primaryPlayer.getCredit().ToString().Length * 15, 20), primaryPlayer.getCredit().ToString());
			GUI.Box (new Rect (Screen.width / 2 + 50, 20, 10 + wonCash.ToString ().Length * 23, 20), wonCash.ToString ());



		// Buttons that add credit to the screen, and clears the screen
		if (GUI.Button (new Rect (5, 5, 200,50), "Add Credit")) {
			primaryPlayer.addCredit (100);
		}

		if (GUI.Button (new Rect (5, 65, 200,50), "Clear")) {
			primaryPlayer.clearCredit();
		}


		// Check if player has enough money before letting them click the spin button
		if (primaryPlayer.getCredit () >= 10 && spinBusy == 0) {
			if (GUI.Button(new Rect (Screen.width/2 -55 , Screen.height / 2 +200, 120, 30), "Spin")) {
				// Iniatilize cash and subtract credit
				wonCash = 0;
				primaryPlayer.subtractCredit (10);
				mainMachine.GetComponent<slotMachine> ().spin ();

				// Pause three seconds so the user does not click the spin button repeatedely
				StartCoroutine (DisableGUI ());

				}
			}
		//Otherwise, just show a unclickable spin button
		 else {
			
			GUI.Box(new Rect (Screen.width/2 -55 , Screen.height / 2 +200, 120, 24), "Spin");
		}

	}

	// Couroutine function to wait 3 seconds and set booleans
	IEnumerator DisableGUI() {
		spinBusy = 1;
		yield return new WaitForSeconds(3);
		spinBusy = 2;

		yield return new WaitForSeconds(0.5f);

		spinBusy = 0;

	}
}
