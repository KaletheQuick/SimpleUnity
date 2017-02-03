using UnityEngine;
using System.Collections;

public class Simple_layout_random : MonoBehaviour {

	[Tooltip("The area wherein the items will be distributed.")]
	public Vector3 distributionBounds = Vector3.one;
	[Tooltip("The items that will be laid out")]
	public GameObject[] thingsToLayout;
	[Tooltip("Total number to layout")]
	public int numberToLayout;
	[Tooltip("Will the items be scaled?")]
	public bool randomScale;
	[Tooltip("The variance on each axis")]
	public Vector3 scaleAmounts;

	[Tooltip("Will the items be rotated?")]
	bool randomRotation;
	[Tooltip("The rotation added on each axis")]
	public Vector3 rotationAmounts;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireCube (this.transform.position, distributionBounds);
	}

	public void LayoutObjects()
	{
		purgeTheChildren ();
		Debug.Log ("Laying out objects.");
		for (int i = 0; i < numberToLayout; i++) {
			placeObject (thingsToLayout[Random.Range(0, thingsToLayout.Length)]);
		}

	}

	void placeObject(GameObject obj)
	{
		GameObject newThing = Instantiate (
			obj, 
			this.transform.position + new Vector3 (Random.value * distributionBounds.x - (distributionBounds.x / 2), Random.value * distributionBounds.y - (distributionBounds.y / 2), Random.value * distributionBounds.z - (distributionBounds.z / 2)), 
			Quaternion.Euler (Random.value * rotationAmounts.x, Random.value * rotationAmounts.y, Random.value * rotationAmounts.z),
			this.transform) as GameObject;
		if (randomScale) {
			newThing.transform.localScale = new Vector3 (1 + (Random.value * scaleAmounts.x) - (scaleAmounts.x / 2), 1 + (Random.value * scaleAmounts.y) - (scaleAmounts.y / 2), 1 + (Random.value * scaleAmounts.z) - (scaleAmounts.z / 2));
		}
	}

	void purgeTheChildren()
	{
		if (transform.childCount != 0) 
		{
			for (int i = transform.childCount; i > 0; i--) {
				DestroyImmediate (transform.GetChild (0).gameObject);
			}	
		}
	}
}
