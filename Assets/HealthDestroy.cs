using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDestroy : MonoBehaviour {

	public float health = 50f;

	// Use this for initialization
	public void TakeDamage (float amount) {
		health -= amount;
		if(health <= 0f)
		{
			Die();
		}
	}
	
	// Update is called once per frame
	void Die () {
		Destroy(gameObject);
	}
}
