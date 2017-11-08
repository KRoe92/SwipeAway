using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clean : MonoBehaviour {

	public GameObject manager;

	// Use this for initialization
	void Start () {
		GetComponent<Button> ().onClick.AddListener (() => clear ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void clear()
	{
		manager.GetComponent<populate> ().rePopulate ();
	}
}
