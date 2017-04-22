﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDownDoor : InteractionGeneric {
	private Vector3 endMarker;
	private Vector3 initialPosition;
	public float speed = 1.0f;
	private float startTime;
	private float journeyLength;
	private bool isGoingUp = false;
	private bool isGoingDown = false;
	private bool isDown = true;


	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
		endMarker = transform.GetChild (0).transform.position;
	}

	// Update is called once per frame
	void Update () {
		if (isGoingUp) 
		{
			transform.position = Vector3.MoveTowards (transform.position, endMarker, speed);
			if (Vector3.Distance(transform.position,endMarker) < 0.005f) 
			{
				isGoingUp = false;
				isDown = false;
			}
		}

		if (isGoingDown)
		{
			transform.position = Vector3.MoveTowards (transform.position, initialPosition, speed);
			if (Vector3.Distance(transform.position, initialPosition) < 0.005f) 
			{
				isGoingDown = false;
				isDown = true;
			}
		}

		if (Input.GetKeyDown (KeyCode.Q))
			CloseDoors();
	}

	public override void Interaction ()
	{
		if (isDown)
			isGoingUp = true;
		else
			isGoingDown = true;
	}

	public void CloseDoors (){
		isGoingDown = true;
	}
}