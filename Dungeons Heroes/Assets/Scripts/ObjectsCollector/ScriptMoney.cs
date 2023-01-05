using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMoney : MonoBehaviour {
	public float rotationSpeed;

	private float money;

	public GameObject collectAudio;

	public GameObject collectEffect;
	[SerializeField] private AnimationsPlayer playerController;

	// Use this for initialization
	void Start () {
		playerController = GameObject.Find("Player").GetComponent<AnimationsPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			Collect();
		}
	}

	public void Collect()
	{
		playerController.updateMoney();
		Instantiate(collectAudio, transform.position, Quaternion.identity);
		Instantiate(collectEffect, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}
}
