﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionTextLog : InteractionGeneric {

	public string logType;

	private TextLogUIHandler textLogUIHandler;
	private bool triggeredDialogue = false;


	// Use this for initialization
	void Start () 
	{
		textLogUIHandler = GameObject.Find ("TextLogUI").GetComponent<TextLogUIHandler>();
		interactionMessage = "Press \"E\" to read the text log";
	}
		

	public override void Interaction ()
	{
		textLogUIHandler.Enable (logType, TextLogList.dialoguesList[logType], this.name);
	}
}
