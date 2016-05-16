// This class will hold the three reels for the user
using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;
using System.Text;

public class slotMachine : MonoBehaviour {
	// Holds information about cash payout
	public class winnings{
		private string [] arr; // Holds symbols
		private int payout; // Holds values

		// Constructor
		public winnings(string one, string two, string three, int pay){
			arr = new string[3];
			arr[0] = one;
			arr[1] = two;
			arr[2] = three;
			payout = pay;
		}

		// Get and set function
		public void setPayout(int p){
			payout = p;
		}

		public int getPayout(){
			return payout;
		}

		// Function to check if the set of characters matches with the ones retrieved from the reels
		public int checkCharacters(string one, string two, string three){
			if ((arr [0] == one) && (arr [1] == two) && (arr [2] == three)) {
				return getPayout();
			} 

			if (arr [0] == "AB" && arr [1] == "AB" && arr [2] == "AB") {
				if ((one == "1B" || one == "2B" || one == "3B")  &&
				   (two == "1B" || two == "2B" || two == "3B") &&
				   (three == "1B" || three == "2B" || three == "3B")) {
					return getPayout();
				}
			}

			return 0;
		}
	}

	// Objects that will hold the three reels
	GameObject One, Two, Three;

	// Object to hold the winnings
	List<winnings> payAmount = new List<winnings>();

	// Use this for initialization
	void Start () {
		string[] seperators = { " " };

		// Instantiate a prefab for each of the objects
		One = Instantiate(Resources.Load("PreFabs/singleReel", typeof(GameObject))) as GameObject;
		Two = Instantiate(Resources.Load("PreFabs/singleReel", typeof(GameObject))) as GameObject;
		Three = Instantiate(Resources.Load("PreFabs/singleReel", typeof(GameObject))) as GameObject;

		// Intialize the names of each of the reel to relate back to them later
		One.GetComponent<slotReel>().setName ("reel1");
		Two.GetComponent<slotReel> ().setName ("reel2");
		Three.GetComponent<slotReel> ().setName ("reel3");

		// Add the list of rating payouts to the list
		payAmount.Add (new winnings("R7", "R7", "R7", 100));
		payAmount.Add (new winnings("3B", "3B", "3B", 60));
		payAmount.Add (new winnings("2B", "2B", "2B", 40));
		payAmount.Add (new winnings("1B", "1B", "1B", 20));
		payAmount.Add (new winnings("AB", "AB", "AB", 10));
		payAmount.Add (new winnings("OR", "OR", "OR", 5));
		payAmount.Add (new winnings("PL", "PL", "PL", 4));
		payAmount.Add (new winnings("CH", "CH", "CH", 3));
	}
	
	// Update is called once per frame
	void Update () {
	}

	// This function ask the other three reels to spin
	public void spin(){
		string x, y, z;
		One.GetComponent<slotReel> ().setSpin (true);

		Two.GetComponent<slotReel> ().setSpin (true);

		Three.GetComponent<slotReel> ().setSpin (true);

		StartCoroutine (Example ());

	}

	// This function will be used to wait 3 seconds before the spinning stops
	IEnumerator Example() {
		yield return new WaitForSeconds(3);
		One.GetComponent<slotReel> ().setSpin (false);
		Two.GetComponent<slotReel> ().setSpin (false);
		Three.GetComponent<slotReel> ().setSpin (false);

	}


	public int payout(){
		int cash = 0;
		for (int j = 0; j < payAmount.Count; j++) {
			int tmp = 0;	
			tmp = payAmount [j].checkCharacters (One.GetComponent<slotReel> ().getResults ()
				, Two.GetComponent<slotReel> ().getResults (), Three.GetComponent<slotReel> ().getResults ());

			if (tmp > cash) {
				cash = tmp;
			}

		}
		return cash;
	}

}
