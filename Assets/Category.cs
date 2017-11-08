using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Category : MonoBehaviour {

	float t = 0.0f;
	public GameObject panel1;
	public GameObject panel2;
	public int width;
	public string catPath;
	public Color bColor;

	Vector3 currentPosition;
	Vector3 desiredPosition; 

	// Use this for initialization
	void Start () {

		GetComponent<Button> ().onClick.AddListener (() => setup());
		currentPosition = new Vector3 (800,0,0);
		desiredPosition = new Vector3 (800,0,0);
	}

	void setup()
	{
		desiredPosition = new Vector3 (0,0,0);
		//inGame.GetComponent<NewBoard> ().populate (catPath);
		//bColor = transform.parent.GetComponent<Image> ().color;
		//inGame.transform.GetChild (0).GetComponent<Image> ().color = bColor;
	}

	// Update is called once per frame
	void Update () {
		currentPosition = Vector3.Lerp (currentPosition, desiredPosition , Time.deltaTime * 4);
		panel2.GetComponent<RectTransform> ().localPosition = currentPosition;
		panel1.GetComponent<RectTransform> ().localPosition = currentPosition - new Vector3 (width, 0, 0);
	}
}
