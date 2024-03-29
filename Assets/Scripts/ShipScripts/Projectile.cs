﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public float speed = 100;
	public float damage = 100;
	public ParticleSystem impact;
	public AudioSource sound2D, sound3D;
	public int launchedLayer = 0;


	Vector2 dir;
	
	void Start() {
		Destroy (gameObject, 10f);
		rigidbody2D.velocity = transform.up*speed;
		
		AudioSource clone;
		
		if (launchedLayer == 8) {
			clone = Instantiate (sound2D, transform.position, Quaternion.identity) as AudioSource;
		} else {
			clone = Instantiate (sound3D, transform.position, Quaternion.identity) as AudioSource;
		}

		clone.Play ();
		Destroy (clone, 2f);
	}
	
	void OnCollisionEnter2D(Collision2D other) {
		
		ParticleSystem impactClone = (ParticleSystem)Instantiate (impact, other.contacts[other.contacts.Length-1].point,
		                                                          Quaternion.LookRotation(other.contacts[other.contacts.Length-1].normal));
		Destroy (impactClone.gameObject, impactClone.duration);
		Destroy (gameObject,0.001f);

		if(other.gameObject.layer != launchedLayer)
			other.gameObject.SendMessageUpwards("Damage", damage); 
	}
}
