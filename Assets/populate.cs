using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class populate : MonoBehaviour {
	public GameObject item;
	public int row;
	public int total;
	int column;
	private int width = 220;
	private int height = 200;
	[HideInInspector] public List<string> itemNames;

	// Use this for initialization
	void Start () {

		column = total / row;
		itemNames = new List<string> ();
		itemNames.Add("Pizza");
		itemNames.Add("Burger");
		itemNames.Add("Sushi");
		itemNames.Add("Lasagna");
		itemNames.Add("Bacon");
		itemNames.Add("Chocolate");
	/*	itemNames.Add("Burrito");
		itemNames.Add("Ice Cream");
		itemNames.Add("Duck");
		itemNames.Add("Pancake");
		itemNames.Add("Peanut Butter");
		itemNames.Add("Soda");
		itemNames.Add("Coffee");
		itemNames.Add("Milkshake");
		itemNames.Add("Popcorn");
		itemNames.Add("Cheesecake");
		itemNames.Add("Kebab");
		itemNames.Add("Croissant");*/

		createItems ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void createItems()
	{
		column = (int)Mathf.Ceil(itemNames.Count / (float)row);
		total = itemNames.Count;
		for(int i = 1; i < total; i++)
		{
			int x = (i % row);
			float tempy = ((float)i/row);
			int y = (int)Mathf.Ceil(tempy);

			Vector3 pos = new Vector3 ( /*((width/(row)) * x) - (width/2)*/ 0,(height/2) - ((height/(column)) * y), 0 );
			GameObject inst = Instantiate (item, new Vector3 (0, 0, 0), Quaternion.identity);
			inst.transform.SetParent (transform);
			inst.GetComponent<RectTransform> ().localPosition = pos;
			Text name = inst.transform.GetChild (0).GetComponent<Text> ();
			name.text = "blurg";
			float f = 24f / (name.text.Length / 8f);
			name.fontSize = (int)f;
			if (name.fontSize > 24)
				name.fontSize = 24;
			inst.transform.SetParent (transform);
		}
	}

	public void removeSring(string name)
	{
		itemNames.Remove (name);
	}

	public void rePopulate()
	{
		var children = new List<GameObject>();
		foreach (Transform child in transform) children.Add(child.gameObject);
		children.ForEach(child => Destroy(child));

		column = (int)Mathf.Ceil(itemNames.Count / (float)row);
		total = itemNames.Count;

		for(int i = 0; i < total; i++)
		{
			int x = (total % i) + 1;
			int y = (total/i) + 1;
			Vector3 pos = new Vector3 ((width/x) - (width/2), (height/y) - (height/2), 0 );
			GameObject inst = Instantiate (item, new Vector3 (0, 0, 0), Quaternion.identity);
			inst.transform.SetParent (transform);
			inst.GetComponent<RectTransform> ().localPosition = pos;
			Text name = inst.transform.GetChild (0).GetComponent<Text> ();
			name.text = "blurg";
			float f = 24f / (name.text.Length / 8f);
			name.fontSize = (int)f;
			if (name.fontSize > 24)
				name.fontSize = 24;
			inst.transform.SetParent (transform);
		}

	}
}
