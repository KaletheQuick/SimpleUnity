using UnityEngine;
using System.Collections;

public class Simple_Shoot : MonoBehaviour {
	[Header("Shoots a projectile forward when the key is pressed")]
	[Tooltip("The key shoot with")]
	public KeyCode fireButton;
	[Tooltip("This prefab will be shot")]
	public GameObject projectile;
	[Tooltip("The damage. Set to the projectile when it is shot")]
	public int damage;
	[Tooltip("Velocity of the projectile")]
	public int speed;
	[Tooltip("How quickly does it shoot?")]
	public int roundsPerMinute;

	[Tooltip("Does the projectile start with the shooters velocity?")]
	public bool inheritGunVelocity;

	private float cooldown;

	private ParticleSystem[] myParticles;
	// Use this for initialization
	void Start () {
		myParticles = GetComponents<ParticleSystem> ();
	}

	// Update is called once per frame
	void Update () {
		cooldown -= Time.deltaTime;
		if (Input.GetKey (fireButton)) 
		{
			if (cooldown <= 0) {
				shoot ();
			}
		}
	}

	private void shoot()
	{
		// Instantiate Projectile
		GameObject pewToPewAtYew = Instantiate(projectile, transform.position, transform.rotation) as GameObject;

		// Apply SimpleDamage component. NOTE looking up a component is slow, this script is a simple prototyping tool.
		Simple_damage_onCollision dam = pewToPewAtYew.AddComponent<Simple_damage_onCollision>();
		dam.damage = damage;

		Vector3 newVelocity = this.transform.forward * speed;
		if (inheritGunVelocity) {
			newVelocity += GetComponentInParent<Rigidbody> ().velocity;
		}
		if (pewToPewAtYew.GetComponent<Simple_rayBullet> ()) {
			pewToPewAtYew.GetComponent<Simple_rayBullet> ().shareVelocity (newVelocity);
		}
		// Kick projectile in proper direction.
		else if (pewToPewAtYew.GetComponent<Rigidbody> ()) {

			pewToPewAtYew.GetComponent<Rigidbody> ().velocity = newVelocity;
		} else {
			pewToPewAtYew.AddComponent<Rigidbody> ();
			pewToPewAtYew.GetComponent<Rigidbody> ().velocity = newVelocity;
		}

		// apply fire delay
		cooldown = (float)60 / (float) roundsPerMinute;
	}
}
