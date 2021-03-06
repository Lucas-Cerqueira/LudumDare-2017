﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {
	private Vector3 endMarker;
	private Vector3 initialPosition;
	public float speed = 1.0f;
	private float startTime;
	private float journeyLength;
	public bool isOpening = false;
	public bool isClosing = false;

	// Use this for initialization
	void Start () 
	{
		initialPosition = transform.position;
		endMarker = transform.GetChild (0).transform.position;
	}

	// Update is called once per frame
	void Update () {
		if (isOpening) 
		{
			transform.position = Vector3.MoveTowards (transform.position, endMarker, speed);
			if (Vector3.Distance(transform.position,endMarker) < 0.005f) 
			{
				isOpening = false;
			}
		}

		if (isClosing)
		{
			transform.position = Vector3.MoveTowards (transform.position, initialPosition, speed);
			if (Vector3.Distance(transform.position, initialPosition) < 0.00005f) 
			{
				isClosing = false;
				print ("closed");
			}
		}

//		if (Input.GetKeyDown (KeyCode.Q))
//			CloseDoors();
	}

	public void OpenDoors()
	{
		isOpening = true;
	}

	public void CloseDoors()
	{
		isClosing = true;
	}

	public Vector3 getInitialPosition ()
	{
		return initialPosition;
	}

	public void setInitialPosition ()
	{
		endMarker = transform.GetChild (0).transform.position;
		initialPosition = transform.position;
	}

}
