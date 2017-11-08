using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientation : MonoBehaviour {

	public Transform choices;
	public Transform endMessage;
	public Transform Desc;
	Vector3 currentRotation;
	Vector3 desiredRotation;
	bool rotated = false;

	// Use this for initialization
	void Start () {
		
		currentRotation = Vector3.zero;
		desiredRotation = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {


		currentRotation = Vector3.Lerp (currentRotation, desiredRotation, Time.deltaTime * 2.5f);
		for(int i = 0; i < choices.childCount; i++)
		{
			choices.GetChild (i).eulerAngles = currentRotation;
		}
		endMessage.eulerAngles = currentRotation;
		Desc.eulerAngles = currentRotation;

		
	}


	public void flip()
	{
		if (rotated) {

			desiredRotation = new Vector3 (0, 0, 0);
			endMessage.position += new Vector3 (0, 200, 0);
			rotated = false;
		} else {
			desiredRotation = new Vector3 (0, 0, 180);
			endMessage.position -= new Vector3 (0, 200, 0);
			rotated = true;
		}
	}
}
