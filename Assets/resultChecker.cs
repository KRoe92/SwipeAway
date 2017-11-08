using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resultChecker : MonoBehaviour {

    public bool inGame;
    int winningChoice = 0;
    Vector3 startingPos;
    Vector3 fanFare;
    public GameObject winner;
	public Transform choices;
	float endCount = 0;

	// Use this for initialization
	void Start () {

        inGame = true;
		fanFare = choices.GetChild(winningChoice).GetComponent<RectTransform>().localScale * 2;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if(inGame)
            trackGame();
        else
        {
			Vector3 currentPos = Vector3.Lerp(choices.GetChild(winningChoice).GetComponent<RectTransform>().localPosition, new Vector3(0, 0, 0), Time.deltaTime * 1.5f);
			choices.GetChild(winningChoice).GetComponent<RectTransform>().localPosition = currentPos;
            if (Mathf.Abs(currentPos.x - 5f) < 10f && Mathf.Abs(currentPos.y) < 5f)
                winner.active = true;
	//		choices.GetChild(winningChoice).GetComponent<RectTransform>().localScale = Vector3.Lerp(choices.GetChild(winningChoice).GetComponent<RectTransform>().localScale, fanFare, Time.deltaTime);
        }

		if (winner.active) {
			endCount += Time.deltaTime;
		}

		if (endCount > 5) {
			gameObject.GetComponent<navigate>().reset ();
		}
	}

	public void reset()
	{
		inGame = true;
		for (int i = 0; i < choices.childCount; i++)
		{
			choices.GetChild (i).GetComponent<swipe> ().swiped = false;
		}
		choices.GetChild (winningChoice).GetComponent<RectTransform> ().localScale = new Vector3 (1,1,1);
		winner.active = false;
		endCount = 0;
	}

    void trackGame()
    {
        int choiceCount = 0;
		for (int i = 0; i < choices.childCount; i++)
        {
			if (!choices.GetChild(i).GetComponent<swipe>().swiped)
                choiceCount++;
        }
        if (choiceCount == 1)
        {
			for (int i = 0; i < choices.childCount; i++)
            {
				if (!choices.GetChild(i).GetComponent<swipe>().swiped)
                {
                    winningChoice = i;
                    inGame = false;
                }
            }
        }
    }
}
