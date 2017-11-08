using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Remove : MonoBehaviour {

	float t = 0.0f;
	public bool lerping = false;
	Vector2 starting;
	Vector2 val;
	public bool left = false;
	public Vector2 endPos;

	// Use this for initialization
	void Start () {

	/*	if (left)
			endPos = -20000;
		else
			endPos = 20000; */
		starting.x = GetComponent<RectTransform> ().localPosition.x;
		starting.y = GetComponent<RectTransform> ().localPosition.y;

	}

	// Update is called once per frame
	void Update () {

		if (lerping) {	
			val.x = Mathf.Lerp (starting.x, endPos.x, t);
			val.y = Mathf.Lerp (starting.y, endPos.y, t);
			t += Time.deltaTime/6;
			GetComponent<RectTransform> ().localPosition = new Vector3 (val.x, val.y, 0);
		}
	}
}
