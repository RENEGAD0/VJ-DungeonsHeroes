using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptHearth : MonoBehaviour {
	public float rotationSpeed;

	public GameObject collectAudio;

	public GameObject collectEffect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			Collect ();
		}
	}

	public void Collect()
	{
		Instantiate(collectAudio, transform.position, Quaternion.identity);
		Instantiate(collectEffect, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}
}
