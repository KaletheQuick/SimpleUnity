using UnityEngine;
using System.Collections;

public class Simple_TransformByKey : MonoBehaviour {

	public KeyCode actuationKey;

	public Vector3 transformMovements;
	public Vector3 transformRotations;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (actuationKey)) 
		{
			this.transform.position += transformMovements * Time.deltaTime;
			this.transform.Rotate(transformRotations * Time.deltaTime);
		}
	}
}
