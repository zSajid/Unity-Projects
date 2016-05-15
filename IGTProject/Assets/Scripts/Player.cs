using UnityEngine;
using System.Collections;

public class Player  {
	// This is how much the player has currently to play the game
	private int credit = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int getCredit(){
		return credit;
	}

	public void addCredit(int c){
		if (c > 0) {
			credit += c;
		}
	}

	public void clearCredit(){
		credit = 0;
	}

	public void subtractCredit(int s){
			credit -= s;

	}
}
