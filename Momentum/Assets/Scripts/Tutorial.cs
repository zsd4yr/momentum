﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

	GameObject redBall;
	GameObject greenBall;
	GameObject canvas;
	Text[] textValue;
	public EditModeScript EMS;
	float timer = 0;
	float timeToWait = 0.25f;
	bool checkingTime;
	bool timerDone;
	bool state2;



	// Use this for initialization
	void Start () {
		greenBall = GameObject.Find("circleGreen");
		redBall = GameObject.Find ("circleRed");
		canvas = GameObject.Find("Canvas");
		textValue = canvas.GetComponentsInChildren<Text>();
		EMS = GetComponent<EditModeScript>();
		EMS.enabled = false;
		Debug.LogError("ayylmao");
		foreach(Text txt in textValue)
		{
			txt.enabled = false;
		}
		textValue [0].enabled = true;
		checkingTime = true;
	}

	// Update is called once per frame
	void Update () {


		if (checkingTime)
		{
			timer += 0.001f;
			Debug.LogError(timer);

			if (timer >= timeToWait)
			{
				timerDone = true;
				checkingTime = false;
				timer = 0;
			}
		}

		if (timerDone)
		{
			textValue [0].enabled = false;
			textValue [1].enabled = true;
			EMS.enabled = true;
			timerDone = false;
		}

		if (Input.GetButtonDown ("Pause") && textValue [1].enabled == true) {
			textValue [1].enabled = false;
			textValue [2].enabled = true;
			state2 = true;
		}

		if (Input.GetButtonUp("ClearTargets"))
		{
			ClearTargets();
		}

		if(Input.GetButtonDown("Pause") && textValue[2].enabled == true && state2)
		{
			textValue [2].enabled = false;
			textValue [3].enabled = true;
		}
		if (Input.GetMouseButtonUp(0))
		{
			Debug.LogError("work");
		}

	}

	private void ClearTargets()
	{
		ClearDest();
		ClearSource();
	}

}
