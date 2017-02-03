using UnityEngine;
using System.Collections;

public class Simple_damage_onCollision : MonoBehaviour {
	[Header("It hurts to touch")]
	[Tooltip("The damage done per touch")]
	public int damage;
	[Tooltip("Does the item stay around after hitting someone?")]
	public bool destroyAfterHit = true;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision coll)
	{
		coll.gameObject.BroadcastMessage("takeDamage", damage);
		if(destroyAfterHit)
		{
			Destroy(this.gameObject);
		}
	}
}
