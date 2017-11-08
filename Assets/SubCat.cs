using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubCat : MonoBehaviour {
	
	public Transform parent;
	public GameObject[] subCats;
	public GameObject backGround;
	public string SubCatName;

	public void createSubCat()
	{
		GameObject g = Instantiate(backGround, new Vector3(0, 0, 0), Quaternion.identity);
		g.transform.SetParent(parent);
		g.transform.SetSiblingIndex (1);
		g.GetComponent<RectTransform>().localPosition = new Vector3(0, -370, 0);
		g.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
		g.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = SubCatName;
		
		Vector3 initPos = new Vector3(80, 840, 0);
		for(int i = 0; i < subCats.Length; i++)
		{
			subCats[i].transform.SetParent(g.transform.GetChild(0).GetChild(0));
			subCats[i].GetComponent<RectTransform>().localPosition = initPos - new Vector3(0, 150 * i, 0);
		}
		

		
	}
	
	
}
