using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	Animator anim;
	public float moveSpeed = 0.5f;
	public GameObject destroyEffect;

	public int health;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		health = (int)(Random.Range(6, 10));
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat("Speed", moveSpeed);
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Projectile") {
			health -= 2;
		}
		if (health <= 0) {
			Instantiate(destroyEffect, transform.position, transform.rotation);
			Destroy(this.gameObject);
		}
	}
}
