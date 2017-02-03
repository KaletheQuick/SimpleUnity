using UnityEngine;
using System.Collections;

public class Simple_Stat_HP : MonoBehaviour {
	[Header("A basic hit point effect.")]
	[Tooltip("The maximum value of the HP")]
	public int maximumHP;
	[Tooltip("The current value of the HP")]
	public int currentHP;
	[Tooltip("A prefab that spawns on death")]
	public GameObject deathEffect;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
	}

	public void takeDamage(int damage)
	{
		// Of course, apply the damage
		currentHP -= damage;

		// If this lowers us to 0 or below, cause death.
		if (currentHP <= 0) 
		{	
			die ();
		}
	}

	public void takeHeals(int heal)
	{
		// Of course, apply the healing.
		currentHP += heal;
		//If the healing is too much, set the intiger to it's maximum
		if (currentHP > maximumHP) 
		{
			currentHP = maximumHP;
		}
	}

	private void die()
	{
		if (deathEffect != null) 
		{
			// We create a new effect and keep a refrence to it in case we want to add or change anything after it is made.
			GameObject go = Instantiate(deathEffect, transform.position, Quaternion.identity) as GameObject;
		}
		// Disable the GameObject instead of destroying it. 
		this.gameObject.SetActive (false);
	}
}
