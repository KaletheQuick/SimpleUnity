using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Simple_layout_liniar : MonoBehaviour {

	[Tooltip("Layout all children every frame?")]
	public bool layoutConstantly;
	[Tooltip("How much each kid is moved")]
	public Vector3 offsets;
	[Tooltip("The items to layout. Generated automatically")]
	public GameObject[] kids;

	// Use this for initialization
	void Start () {
		findKids ();
	}

	// Update is called once per frame
	void Update () {
		if (layoutConstantly) 
		{
			Layout ();
		}
	}

	public void Layout()
	{
		if (kids.Length != transform.childCount) {
			findKids ();
		}
		layoutTheKids ();
	}

	void findKids()
	{
		kids = new GameObject[transform.childCount];
		for (int i = 0; i < kids.Length; i++) {
			kids [i] = transform.GetChild (i).gameObject;
		}
	}

	void layoutTheKids()
	{
		for (int i = 0; i < kids.Length; i++) {
			kids [i].transform.localPosition = Vector3.zero + (offsets * i);
		}
	}
}
