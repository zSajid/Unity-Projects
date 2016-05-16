// This class is focused on giving information for each of the slot machine reels.
// Will hold the array of texture 2D's that it will spin/rotate
using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;
using System.Text;


public class slotReel : MonoBehaviour {

	// This will hold the position of where it is in the list of symbol references
	private int  positionOne = 1, positionTwo = 2, positionThree = 3;

	// This is to hold the position of the different things
	int reelOneGUIROW =  323;
	int reelTwoGUIROW = 445;
	int reelThreeGUIROW = 565;

	int reelOneGUICOL = 50;
	int reelTwoGUICOL  = 160;
	int reelThreeGUICOL = 270;
	int reelFourGUICOL = 400 ;
	public Texture2D backgroundGUITexture;

	// This will hold a list of strings by certain reel location
	private List<string> symbolReferences = new List<string>();
	// List of textures for the symbols
	private Dictionary <string, Texture2D> symbols = new Dictionary<string, Texture2D>();

	// Will hold if it is reel 1, 2, or 3
	public string name;

	// This will check if the reels should spin
	private bool spin;

	// Use this for initialization
	void Start () {
		// Find and instantiate the list of textures from the folder
		Texture2D tmp = Resources.Load("Textures/1B") as Texture2D;
		symbols.Add ("1B", tmp);
		tmp = Resources.Load("Textures/2B") as Texture2D;
		symbols.Add ("2B", tmp);
		 tmp = Resources.Load("Textures/3B") as Texture2D;
		symbols.Add ("3B", tmp);
		 tmp = Resources.Load("Textures/CH") as Texture2D;
		symbols.Add ("CH", tmp);
		 tmp = Resources.Load("Textures/OR") as Texture2D;
		symbols.Add ("OR", tmp);
		 tmp = Resources.Load("Textures/PL") as Texture2D;
		symbols.Add ("PL", tmp);
		 tmp = Resources.Load("Textures/R7") as Texture2D;
		symbols.Add ("R7", tmp);

		// Check for name and then open a stream reader to read in information
		if (name == "reel1") {
			StreamReader read = new StreamReader(name + ".txt", false);
			string txt = " ";


			// Read through all of the information from the txt file
			for (int i = 0; i < 21; i++) {
				txt = read.ReadLine ();
				symbolReferences.Add(txt);
			}

			// Close the file, to make sure no other issues
			read.Close ();


		} else if (name == "reel2") {
			StreamReader read = new StreamReader(name + ".txt", false);
			string txt = " ";


			// Read through all of the information from the txt file
			for (int i = 0; i < 21; i++) {
				txt = read.ReadLine ();
				symbolReferences.Add(txt);
			}

			// Close the file, to make sure no other issues
			read.Close ();

		} else if(name == "reel3"){

			StreamReader read = new StreamReader(name + ".txt", false);
			string txt = " ";


			// Read through all of the information from the txt file
			for (int i = 0; i < 21; i++) {
				txt = read.ReadLine ();
				symbolReferences.Add(txt);
			}

			// Close the file, to make sure no other issues
			read.Close ();
		}
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	// Get and set functions
	public void setName(string reelName){
		name = reelName;
	}

	public string getName(){
		return name;
	}

	// Render to the screen 
	void OnGUI(){
		// If the spin button was clicked
		if (spin) {				
				// Get three random ints, and then add that to positions
				System.Random r = new System.Random ();
				int x = r.Next (0, 2);
				int y = r.Next (0, 2);
				int z = r.Next (0, 3);

				// Check if out of bounds
				if (positionOne+x > 20) {
					positionOne = 0;
					positionOne += 1;
				}
				if (positionTwo+y > 20) {
					positionTwo = 0;
					positionTwo += 1;
				} 

			if (positionThree+z > 20) {
					positionThree = 0;
					positionThree += 1;
				}

				// Increment the positions
				positionOne += x;
				positionTwo += y;
				positionThree +=z;

				// Render onto the screen all of teh different images for the slot machines
				if (name == "reel1") {
				GUI.Label (new Rect (reelOneGUIROW, reelOneGUICOL, 128, 128), symbols [symbolReferences [positionOne]]);
					GUI.Label (new Rect (reelOneGUIROW, reelTwoGUICOL, 128, 128), symbols [symbolReferences [positionTwo]]);
					GUI.Label (new Rect (reelOneGUIROW, reelThreeGUICOL, 128, 128), symbols [symbolReferences [positionThree]]);
					GUI.Box (new Rect (reelOneGUIROW , reelFourGUICOL , 110, 30), "First Reel: "+ symbolReferences [positionTwo]);


				} else if (name == "reel2") {
					GUI.Label (new Rect (reelTwoGUIROW, reelOneGUICOL, 128, 128), symbols [symbolReferences [positionOne]]);
					GUI.Label (new Rect (reelTwoGUIROW, reelTwoGUICOL, 128, 128), symbols [symbolReferences [positionTwo]]);
					GUI.Label (new Rect (reelTwoGUIROW, reelThreeGUICOL, 128, 128), symbols [symbolReferences [positionThree]]);
					GUI.Box  (new Rect (reelTwoGUIROW, reelFourGUICOL,110, 30),"Second Reel: " + symbolReferences[positionTwo]);


				} else if (name == "reel3") {
					GUI.Label (new Rect (reelThreeGUIROW, reelOneGUICOL, 128, 128), symbols [symbolReferences [positionOne]]);
					GUI.Label (new Rect (reelThreeGUIROW, reelTwoGUICOL, 128, 128), symbols [symbolReferences [positionTwo]]);
					GUI.Label (new Rect (reelThreeGUIROW, reelThreeGUICOL, 128, 128), symbols [symbolReferences [positionThree]]);
				GUI.Box (new Rect (reelThreeGUIROW , reelFourGUICOL, 110, 30), "Third Reel: " +symbolReferences[positionTwo]);

				}
		} else {
			// Otherwise, render the same thing but at a stand still
			if (name == "reel1") {
				GUI.Label (new Rect (reelOneGUIROW, reelOneGUICOL, 128, 128), symbols [symbolReferences [positionOne]]);
				GUI.Label (new Rect (reelOneGUIROW, reelTwoGUICOL, 128, 128), symbols [symbolReferences [positionTwo]]);
				GUI.Label (new Rect (reelOneGUIROW, reelThreeGUICOL, 128, 128), symbols [symbolReferences [positionThree]]);
				GUI.Box (new Rect (reelOneGUIROW , reelFourGUICOL , 110, 30), "First Reel: "+ symbolReferences [positionTwo]);


			} else if (name == "reel2") {
				GUI.Label (new Rect (reelTwoGUIROW, reelOneGUICOL, 128, 128), symbols [symbolReferences [positionOne]]);
				GUI.Label (new Rect (reelTwoGUIROW, reelTwoGUICOL, 128, 128), symbols [symbolReferences [positionTwo]]);
				GUI.Label (new Rect (reelTwoGUIROW, reelThreeGUICOL, 128, 128), symbols [symbolReferences [positionThree]]);
				GUI.Box  (new Rect (reelTwoGUIROW, reelFourGUICOL,110, 30),"Second Reel: " + symbolReferences[positionTwo]);

			} else if (name == "reel3") {
				GUI.Label (new Rect (reelThreeGUIROW, reelOneGUICOL, 128, 128), symbols [symbolReferences [positionOne]]);
				GUI.Label (new Rect (reelThreeGUIROW, reelTwoGUICOL, 128, 128), symbols [symbolReferences [positionTwo]]);
				GUI.Label (new Rect (reelThreeGUIROW, reelThreeGUICOL, 128, 128), symbols [symbolReferences [positionThree]]);
				GUI.Box (new Rect (reelThreeGUIROW , reelFourGUICOL, 110, 30), "Third Reel: " +symbolReferences[positionTwo]);
			}
		}
	}

	// Set function to access private
	public void setSpin(bool s){
		spin = s;
	}

	// Set function to access private
	public bool getSpin(){
		return spin;
	}
	// Give back the results of each reel to the slotMachine
	public string getResults(){
		return (symbolReferences [positionTwo]);
	
	}

}
