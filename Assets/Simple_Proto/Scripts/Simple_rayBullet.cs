using UnityEngine;
using System.Collections;

public class Simple_rayBullet : MonoBehaviour {

	public float speed;
	public float balisticCoefficent;
	public float gravityMult = 1;

	public GameObject impactEffect;


	public Vector3 velocity;
	// Use this for initialization
	void Start () {
		//velocity = transform.forward * speed;
	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate()
	{
		velocity += (Physics.gravity * gravityMult) * Time.fixedDeltaTime;
		Vector3 frameEndPoint = transform.position; // Get current position
		frameEndPoint += velocity * Time.fixedDeltaTime; // apply forward momentum
		Vector3 direction = frameEndPoint - transform.position;
		RaycastHit hit;
		Physics.Raycast (transform.position, direction, out hit, direction.magnitude);
		if (hit.collider != null) 
		{
			Debug.Log ("Collider- " + hit.collider + ", Named-  " + hit.collider.gameObject.name);
			hit.collider.gameObject.BroadcastMessage ("takeDamage", 1);
			if (hit.collider.gameObject.GetComponent<Simple_Stat_HP> ()) 
			{
				hit.collider.gameObject.GetComponent<Simple_Stat_HP> ().takeDamage (GetComponent<Simple_damage_onCollision> ().damage);

			}
			GameObject impact = Instantiate (impactEffect, hit.point, Quaternion.identity) as GameObject;
			Destroy (this.gameObject);
		}
		transform.Translate(direction,Space.World);
		//drag ();
	}

	void drag()
	{
		velocity = velocity * ((1 - balisticCoefficent) * Time.fixedDeltaTime);
	}

	public void shareVelocity(Vector3 vel)
	{
		velocity += vel;
	}

}
