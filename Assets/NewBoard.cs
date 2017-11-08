using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class NewBoard : MonoBehaviour {

	Color bColor;
    public int playerNum = 1;
    public int numOfPlayers = 1;
    public GameObject header;
    public GameObject Desc;
    public GameObject layOver;
    public bool scalingUp;
    public bool scalingDown;
	public GameObject Sidebar;
	public Text endMessage;
    float val;
    float t = 0.0f;
    int colorValue;

    float currentR;
    float currentG;
    float currentB;

    float desiredR;
    float desiredG;
    float desiredB;

    Vector3[] choicePositions;

    // Use this for initialization
    void Start () {

        currentR = 265f / 255f;
        currentG = 92f / 255f;
        currentB = 71f / 255f;

        desiredR = 265f / 255f;
        desiredG = 92f / 255f;
        desiredB = 71f / 255f;

        Transform board = transform.GetChild(0).GetChild(2);
        choicePositions = new Vector3[board.childCount];
        for (int i = 0; i < board.childCount; i++)
        {
            choicePositions[i] = board.GetChild(i).localPosition;
        }

     }
	
	// Update is called once per frame
	void Update () {
        header.GetComponent<Text>().text = "Player " + playerNum;

        switch ((playerNum + colorValue) % 6)
        {
            case 1:
                desiredR = 265f / 255f;
                desiredG = 92f / 255f;
                desiredB = 71f / 255f;
                break;
            case 2:
                desiredR = 83f / 255f;
                desiredG = 216f / 255f;
                desiredB = 137f / 255f;
                break;
            case 3:
                desiredR = 97f / 255f;
                desiredG = 165f / 255f;
                desiredB = 204f / 255f;
                break;
            case 4:
                desiredR = 251f / 255f;
                desiredG = 165f / 255f;
                desiredB = 2f / 255f;
                break;
            case 5:
                desiredR = 211f / 255f;
                desiredG = 60f / 255f;
                desiredB = 93f / 255f;
                break;
            case 0:
                desiredR = 77f / 255f;
                desiredG = 92f / 255f;
                desiredB = 162f / 255f;
                break;

        }

        currentR = Mathf.Lerp(currentR, desiredR, Time.deltaTime * 2);
        currentG = Mathf.Lerp(currentG, desiredG, Time.deltaTime * 2);
        currentB = Mathf.Lerp(currentB, desiredB, Time.deltaTime * 2);


        transform.GetChild(0).GetComponent<Image>().color = new Color(currentR, currentG, currentB);
        if(scalingUp)
        {
            val = Mathf.Lerp(0, 1, t);
            t += Time.deltaTime * 2;
            Desc.GetComponent<RectTransform>().localScale = new Vector3(val, val, val);
        }
        else if (scalingDown)
        {
            val = Mathf.Lerp(1, 0, t);
            t += Time.deltaTime * 2;
            Desc.GetComponent<RectTransform>().localScale = new Vector3(val, val, val);
        }

    }

    public void setScale(bool val)
    {
        scalingUp = val;
        scalingDown = !scalingUp;
        t = 0;
    }

    public void setNumOfPlayers(string num)
    {
        int.TryParse(num, out numOfPlayers);
		Sidebar.GetComponent<SideBarControl>().sidebarEnable(false);
    }

	public void populate(string path)
	{
		int total = 0;
        TextAsset level = Resources.Load<TextAsset>(path);
        string[] itemNames = new string[250];
        string[] itemDesc = new string[250];
        if (level != null)
        {
            using (StreamReader sr = new StreamReader(new MemoryStream(level.bytes)))
            {
                string line;
                int t = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    string name = line;
                    string desc = line;
                    if (line.Contains("-"))
                    {
                        name = line.Split('-')[0];
                        desc = line.Split('-')[1];
                    }
                    itemNames[t] = name;
                    itemDesc[t] = desc;
                    t += 1;
					total = t;
                }
            }
        }

        //path = Application.dataPath + "/" + path + ".txt";
		//string[] itemNames = System.IO.File.ReadAllLines (path);
		Transform board = transform.GetChild (0).GetChild(2);
        playerNum = 1;
        for (int i = 0; i < board.childCount; i++)
        {
            board.GetChild(i).localPosition = choicePositions[i];
            board.GetChild(i).localScale = new Vector3(1,1,1);
            board.GetChild(i).gameObject.GetComponent<swipe>().reset();
        }

		
		int picked = 0;
		System.Random rnd = new System.Random();
        for(int i = 0; i < board.childCount; i++)
		{
			int num = rnd.Next(total);
			Transform parent = board.GetChild (i);
			Text name = parent.GetChild(0).GetComponent<Text> ();
			name.text = itemNames[num];

            Text desc = parent.GetChild(1).GetComponent<Text>();
            desc.text = itemDesc[num];
			itemNames = removeFromArray(itemNames, num);
			itemDesc = removeFromArray(itemDesc, num);
			total--;
        }
	}
	
    private string[] removeFromArray(string[] array, int id)
    {
        int difference = 0, currentValue=0;
        //get new Array length
        for (int i=0; i<array.Length; i++)
        {
            if (i ==id)
            {
                difference += 1;
            }
        }
        //create new array
        string[] newArray = new string[array.Length-difference];
        for (int i = 0; i < array.Length; i++ )
        {
            if (i != id)
            {
                newArray[currentValue] = array[i];
                currentValue += 1;
            }
        }

        return newArray;
    }
	
	public void setColorValue(int val)
    {
        colorValue = val;
    }

	public void setEndMessage(string message)
	{
		endMessage.text = message;
	}
}
