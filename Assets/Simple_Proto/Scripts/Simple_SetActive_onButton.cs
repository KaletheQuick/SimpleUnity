using UnityEngine;
using System.Collections;

public class Simple_SetActive_onButton : MonoBehaviour {
	[Header("Toggle some items on and off")]
	[Tooltip("The button to toggle these items")]
	public KeyCode button;
	[Tooltip("These items will be turned off and on")]
	public GameObject[] itemsToToggle;

	public bool currentState = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (button)) {
			toggleItems ();
		}
	}

	void toggleItems()
	{
		currentState = !currentState;
		for (int i = 0; i < itemsToToggle.Length; i++) {
			itemsToToggle [i].SetActive (currentState);
		}
	}
}
