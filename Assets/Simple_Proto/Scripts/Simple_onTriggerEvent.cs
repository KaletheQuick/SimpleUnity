using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Simple_onTriggerEvent : MonoBehaviour {

	public string tagToReactTo = "Type in a tag that is defined in the drop down menu at the top of the inspector";

	public UnityEvent EnterEvents;
	public UnityEvent StayEvents;
	public UnityEvent ExitEvents;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter(Collider coll)
	{
		if(coll.CompareTag(tagToReactTo))
		{
			EnterEvents.Invoke ();
		}
	}

	public void OnTriggerStay(Collider coll)
	{
		if(coll.CompareTag(tagToReactTo))
		{
			StayEvents.Invoke ();
		}
	}

	public void OnTriggerExit(Collider coll)
	{
		if(coll.CompareTag(tagToReactTo))
		{
			ExitEvents.Invoke ();
		}
	}
}
