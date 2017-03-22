using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public GameObject flashlightObject;
	public UnityEngine.UI.Text display;
	private Light flashlight;

	private bool flashlightInInventory = false;
	private float interactDistance = 2f;

	private int x, y;

	// Use this for initialization
	void Start () {
		x = Screen.width / 2;
		y = Screen.height / 2;
		flashlight = flashlightObject.GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {

		Ray ray = this.GetComponentInChildren<Camera> ().ScreenPointToRay (new Vector3 (x, y));
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit, interactDistance)){
			if(hit.collider.CompareTag("Door")){				
				display.text = "Open Door [E]";
			}

		} else {
			display.text = "";
		}

		if (Input.GetKeyDown (KeyCode.E)) {


		}


		if (Input.GetKeyDown (KeyCode.F)) {
			if (flashlightInInventory) {
				if (flashlight.enabled) {
					flashlight.enabled = false;
				} else {
					flashlight.enabled = true;
				}
			}
		}

		if (Input.GetKeyDown (KeyCode.G)) {
			flashlightInInventory = true;
			flashlightObject.SetActive (true);
		}
	}


}
