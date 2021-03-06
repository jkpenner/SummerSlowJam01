﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputMapper : MonoBehaviour {

	[System.Serializable]
	public class InputMap{
		public string referenceName;
		public string inputManagerNameBase;
	}

	public PlayerId playerId;
	public InputMap[] inputs;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string GetMappedInput(string inputName){
		foreach(InputMap inputMap in inputs){
			if(inputName == inputMap.referenceName){
				return inputMap.inputManagerNameBase + (int)playerId;
			}
		}
		Debug.LogError("Input '"+inputName+"' Not Found");
		return "";
	}

	public void SetPlayerId(PlayerId playerId){
		this.playerId = playerId;
	}
}
