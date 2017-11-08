using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class crossOut : MonoBehaviour {

	// Use this for initialization
	void Start () {

		GetComponent<Button> ().onClick.AddListener (() => strikeThrough ());
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void strikeThrough()
	{
		Text name = transform.GetChild (0).GetComponent<Text> ();
		transform.parent.GetComponent<populate> ().removeSring (name.text);
		print (name.text);
		string strikethrough = "";
		foreach(char c in name.text)
		{
			strikethrough = strikethrough + c +  '\u0336';
		}

		name.text = strikethrough;
		GetComponent<Button> ().enabled = false;

	}
}
