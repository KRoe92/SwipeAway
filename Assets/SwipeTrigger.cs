using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeTrigger : EventTrigger {

	public override void OnPointerDown(PointerEventData data)
	{
		gameObject.GetComponent<swipe> ().choose ();
	}
}
