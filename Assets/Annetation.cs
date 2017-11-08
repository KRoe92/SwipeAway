using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Annetation : MonoBehaviour {

	public GameObject message;

	bool scalingUp;
	bool scalingDown;
	float value;
	float t;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(scalingUp)
		{
			value = Mathf.Lerp(0, 1, t);
			t += Time.deltaTime * 2;
			message.GetComponent<RectTransform>().localScale = new Vector3(value, value, value);
		}
		else if (scalingDown)
		{
			value = Mathf.Lerp(1, 0, t);
			t += Time.deltaTime * 2;
			message.GetComponent<RectTransform>().localScale = new Vector3(value, value, value);
		}
		
	}

	public void setMessage(bool val)
	{
		scalingUp = val;
		scalingDown = !scalingUp;
		t = 0;
	}
}
