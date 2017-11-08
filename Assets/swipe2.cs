using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class swipe2 : NetworkBehaviour {


	//inside class
	Vector2 firstPressPos;
	Vector2 secondPressPos;
	Vector2 currentSwipe;
	Vector2 starting;
	Vector2 endPos;
	Vector2 val;
	float t = 0.0f;
	bool selected = false;
	public bool lerping = false;
	float startTime;

	public bool swiped = false;

	void Start () {

		starting.x = GetComponent<RectTransform> ().localPosition.x;
		starting.y = GetComponent<RectTransform> ().localPosition.y;
		transform.SetParent(GameObject.FindGameObjectWithTag ("board").transform);
		transform.localPosition = new Vector3 (10, 5, 0);
		selected = true;

	}

	public void reset()
	{
		t = 0.0f;
		selected = false;
		lerping = false;
		startTime = 0;
		swiped = false;
	}

	void Update()
	{
		CmdNudge ();
	}

	[Command]
	public void CmdNudge()
	{
		if (selected) {
			GetComponent<RectTransform> ().localPosition = new Vector3(Input.mousePosition.x - (Screen.width/2),Input.mousePosition.y - (Screen.height/2), 0);
			SwipeClick ();
			firstPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
		}

		if (lerping) {	
			val.x = Mathf.Lerp (starting.x, endPos.x, t);
			val.y = Mathf.Lerp (starting.y, endPos.y, t);
			t += Time.deltaTime/6;
			GetComponent<RectTransform> ().localPosition = new Vector3 (val.x, val.y, 0);
		}
	}

	public void choose()
	{
		selected = true;
	}

	public void SwipeClick()
	{
		if(Input.GetMouseButtonDown(0))
		{
			//save began touch 2d point
			print("Yo!");

		}
		if(Input.GetMouseButtonUp(0))
		{

			selected = false;
			//save ended touch 2d point
			secondPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);

			//create vector from the two points
			currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

			currentSwipe.Normalize();
			endPos = new Vector2 (10000 * currentSwipe.x, 10000 * currentSwipe.y);
			float dif = Time.time - startTime;
			print (currentSwipe.x);
			if (currentSwipe.x != 0 && currentSwipe.y != 0)
			{
				lerping = true;
				swiped = true;
				starting.x = GetComponent<RectTransform> ().localPosition.x;
				starting.y = GetComponent<RectTransform> ().localPosition.y;
			}
		}	
	}
}
