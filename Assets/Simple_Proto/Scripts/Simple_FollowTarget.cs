using UnityEngine;
using System.Collections;

public class Simple_FollowTarget : MonoBehaviour {
	[Header("This GameObject will move to match it's target.")]
	[Tooltip("The transform that will be followed")]
	public Transform target;

	[Tooltip("This will smooth out the follow movement.")]
	public bool smoothulation;
	[Tooltip("The lower this is the slower and smoother the movement will be.")]
	[Range(0,1)]
	public float smoothRate = 0.25f;

	// Use this for initialization
	void Start () {
		if (target == null) 
		{
			// To prevent error, if there is no target, it targets itself.
			target = this.transform;
		}
	}

	// Update is called once per frame
	void Update () {
		if (smoothulation == false) {
			this.transform.position = target.position;
			this.transform.rotation = target.rotation;	
		} else {
			this.transform.position = Vector3.Lerp(this.transform.position, target.position, smoothRate);
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, target.rotation, smoothRate);			
		}
	}

	public void newTarget(Transform newTarge)
	{
		target = newTarge;
	}
}
