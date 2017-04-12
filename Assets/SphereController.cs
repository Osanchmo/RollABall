using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SphereController : MonoBehaviour {
	public float speed;
	private int count;

	public Text text;
	public Text winText;

	void Start()
	{
		count = 0;
		updateCounter();
		winText.text = "";
	}

	// Update is called once per frame
	void FixedUpdate () {
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		GetComponent<Rigidbody>().AddForce(horizontal * speed, 0 , vertical * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "pickup"){
			Destroy(other.gameObject);
			count++;
			updateCounter();
		}
	}

void updateCounter() {
	text.text = "Puntos: " + count;
	int numPicks = GameObject.FindGameObjectsWithTag("pickup").Length;
	if (numPicks == 1){
		winText.text = "Has gando!";
	}
}

}
