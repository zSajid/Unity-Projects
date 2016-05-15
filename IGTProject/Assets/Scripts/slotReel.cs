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
	private int positionOne = 0, positionTwo = 1, positionThree = 2;

	// This is to hold the position of the different things
	int reelOneGUIROW =  223;
	int reelTwoGUIROW = 345;
	int reelThreeGUIROW = 465;

	int reelOneGUICOL = 50;
	int reelTwoGUICOL  = 170;
	int reelThreeGUICOL = 290;
	int reelFourGUICOL = 290+120;

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

	public void setName(string reelName){
		name = reelName;
	}

	public string getName(){
		return name;
	}




	void OnGUI(){


		if (spin) {
			float time = 0.0f;
			while (time < 3.0f) {
				
				System.Random r = new System.Random ();
				int x = r.Next (0, 11);
				int y = r.Next (0, 15);
				int z = r.Next (0, 18);

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
					

				time += Time.deltaTime;

				positionOne += x;
				positionTwo += y;
				positionThree +=z;




				if (name == "reel1") {
					GUI.Label (new Rect (reelOneGUIROW, reelOneGUICOL, 128, 128), symbols [symbolReferences [positionOne]]);
					GUI.Label (new Rect (reelOneGUIROW, reelTwoGUICOL, 128, 128), symbols [symbolReferences [positionTwo]]);
					GUI.Label (new Rect (reelOneGUIROW, reelThreeGUICOL, 128, 128), symbols [symbolReferences [positionThree]]);
					GUI.Label (new Rect (reelOneGUIROW, reelThreeGUICOL, 128, 128), symbolReferences [positionThree]);

				} else if (name == "reel2") {
					GUI.Label (new Rect (reelTwoGUIROW, reelOneGUICOL, 128, 128), symbols [symbolReferences [positionOne]]);
					GUI.Label (new Rect (reelTwoGUIROW, reelTwoGUICOL, 128, 128), symbols [symbolReferences [positionTwo]]);
					GUI.Label (new Rect (reelTwoGUIROW, reelThreeGUICOL, 128, 128), symbols [symbolReferences [positionThree]]);
					GUI.Label (new Rect (reelTwoGUIROW, reelFourGUICOL, 128, 128), symbolReferences[positionTwo]);

				} else if (name == "reel3") {
					GUI.Label (new Rect (reelThreeGUIROW, reelOneGUICOL, 128, 128), symbols [symbolReferences [positionOne]]);
					GUI.Label (new Rect (reelThreeGUIROW, reelTwoGUICOL, 128, 128), symbols [symbolReferences [positionTwo]]);
					GUI.Label (new Rect (reelThreeGUIROW, reelThreeGUICOL, 128, 128), symbols [symbolReferences [positionThree]]);
					GUI.Label (new Rect (reelThreeGUIROW, reelFourGUICOL, 128, 128), symbolReferences[positionTwo]);
				}
			}
			spin = false;

		} else {

			if (name == "reel1") {
				GUI.Label (new Rect (reelOneGUIROW, reelOneGUICOL, 128, 128), symbols [symbolReferences [positionOne]]);
				GUI.Label (new Rect (reelOneGUIROW, reelTwoGUICOL, 128, 128), symbols [symbolReferences [positionTwo]]);
				GUI.Label (new Rect (reelOneGUIROW, reelThreeGUICOL, 128, 128), symbols [symbolReferences [positionThree]]);
				GUI.Label (new Rect (reelOneGUIROW +50, reelFourGUICOL , 128, 128), symbolReferences [positionTwo]);

			} else if (name == "reel2") {
				GUI.Label (new Rect (reelTwoGUIROW, reelOneGUICOL, 128, 128), symbols [symbolReferences [positionOne]]);
				GUI.Label (new Rect (reelTwoGUIROW, reelTwoGUICOL, 128, 128), symbols [symbolReferences [positionTwo]]);
				GUI.Label (new Rect (reelTwoGUIROW, reelThreeGUICOL, 128, 128), symbols [symbolReferences [positionThree]]);
				GUI.Label (new Rect (reelTwoGUIROW +50, reelFourGUICOL, 128, 128), symbolReferences[positionTwo]);

			} else if (name == "reel3") {
				GUI.Label (new Rect (reelThreeGUIROW, reelOneGUICOL, 128, 128), symbols [symbolReferences [positionOne]]);
				GUI.Label (new Rect (reelThreeGUIROW, reelTwoGUICOL, 128, 128), symbols [symbolReferences [positionTwo]]);
				GUI.Label (new Rect (reelThreeGUIROW, reelThreeGUICOL, 128, 128), symbols [symbolReferences [positionThree]]);
				GUI.Label (new Rect (reelThreeGUIROW +50, reelFourGUICOL, 128, 128), symbolReferences[positionTwo]);

			}

		}
	}

	public void setSpin(bool s){
		spin = s;
	}

	public string getResults(){
		return (symbolReferences [positionTwo]);
	
	}
}
