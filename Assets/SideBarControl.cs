using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBarControl : MonoBehaviour {
	
	
	Vector3 currentPosition;
	Vector3 desiredPosition;
	bool sidebarEnabled = true;
	
	public void sidebarEnable(bool on)
	{
		sidebarEnabled = on;
		
		if(on)
			desiredPosition = new Vector3 (0,transform.position.y,0); 
		else
			desiredPosition = new Vector3 (-250,transform.position.y,0); 
	}
	
	public void sidebarToggle()
	{
		if(sidebarEnabled)
			sidebarEnable(false);
		else
			sidebarEnable(true);
	}
	
	void Start () {
		currentPosition = new Vector3 (0,transform.position.y,0);
        desiredPosition = currentPosition;

    }
	
	void Update () 
	{
		currentPosition = Vector3.Lerp(currentPosition, desiredPosition, Time.deltaTime * 2);
		transform.GetComponent<RectTransform>().position = currentPosition;
	}
}
