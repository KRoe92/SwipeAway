using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class navigate : MonoBehaviour {

	float t = 0.0f;
	public GameObject panel;
	public GameObject sidebar;
	public int width;
	Vector3 currentPosition;
	Vector3 desiredPosition;
	public Transform playerBoard;
    bool sliding;
    bool holding;
    float currentTime;

    // Use this for initialization
    void Start () {
		currentPosition = new Vector3 (0,0,0);
        desiredPosition = currentPosition;
        currentTime = 0f;

    }

    public void HoldOn()
    {
        holding = true;
    }

    public void HoldOff()
    {
        holding = false;
    }

    public void slide()
	{
        sliding = true;
		desiredPosition = desiredPosition - new Vector3 (800, 0, 0);
	}
		
	public void reset()
	{
        desiredPosition = new Vector3(0, 0, 0);
		sidebar.GetComponent<SideBarControl> ().sidebarEnable (true);
        currentTime = 0;
        HoldOff();
        sliding = true;
		gameObject.GetComponent<resultChecker>().reset();
    }

	// Update is called once per frame
	void Update () {
        if (sliding)
        {
            currentPosition = Vector3.Lerp(currentPosition, desiredPosition, Time.deltaTime * 4);
            for (int i = 0; i < panel.transform.childCount; i++)
            {
                panel.transform.GetChild(i).GetComponent<RectTransform>().localPosition = currentPosition + new Vector3((width * i), panel.transform.GetChild(i).GetComponent<RectTransform>().localPosition.y, 0);
            }
        }

		if (Mathf.Abs(currentPosition.x) < 50) {
//			print (currentPosition);
			GameObject disp = GameObject.FindWithTag("Disposable");
			if(disp != null)
			{
				for (var i = disp.transform.childCount - 1; i >= 0; i--)
				{
					Transform objectA = disp.transform.GetChild(i);
					objectA.transform.parent = null;
				}
				Destroy (disp);
			}
		}

        if(holding)
        {
            currentTime += Time.deltaTime;
            if(currentTime > 1f)
                reset();
        }

    }
	
	public void changeColor(string bColor)
	{
        playerBoard.GetComponent<Image> ().color = HexToRGB(bColor);
		GameObject disp = GameObject.FindWithTag("Disposable");
		if(disp != null)
		{
			disp.transform.GetChild(0).GetChild(0).GetComponent<Image> ().color = HexToRGB(bColor);
		}
	}

	public Color HexToRGB (string color) {
		float red = (HexToInt(color[1]) + HexToInt(color[0]) * 16.000f) / 255;
		float green = (HexToInt(color[3]) + HexToInt(color[2]) * 16.000f) / 255;
		float blue = (HexToInt(color[5]) + HexToInt(color[4]) * 16.000f) / 255;
		var finalColor = new Color();
		finalColor.r = red;
		finalColor.g = green;
		finalColor.b = blue;
		finalColor.a = 1;
		return finalColor;
	}

	int HexToInt (char hexChar) {
		string hex = "" + hexChar;
		switch (hex) {
		case "0": return 0;
		case "1": return 1;
		case "2": return 2;
		case "3": return 3;
		case "4": return 4;
		case "5": return 5;
		case "6": return 6;
		case "7": return 7;
		case "8": return 8;
		case "9": return 9;
		case "A": return 10;
		case "B": return 11;
		case "C": return 12;
		case "D": return 13;
		case "E": return 14;
		case "F": return 15;
		}
		return 0;
	}
}
