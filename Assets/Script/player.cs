using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	public float speed = 1f;
	private Animator animator;
	private float vert;


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		vert = Input.GetAxis ("Vertical");
		if (Input.GetKey (KeyCode.A)) {
			Vector3 position = this.transform.position;
			print (position.x);
			position.x -= 0.1f;
			this.transform.Rotate (0, 90, 0);
			this.transform.position = position;
			animator.SetFloat ("rat_state", vert);
		} else if (Input.GetKey (KeyCode.D)) {
			Vector3 position = this.transform.position;
			position.x += 0.1f;
			this.transform.Rotate (0, 90, 0);
			this.transform.position = position;
			animator.SetFloat ("rat_state", vert);
		} else if (Input.GetKey (KeyCode.W)) {
			Vector3 position = this.transform.position;
			position.z += 0.1f;
			this.transform.Rotate (0, 90, 0);
			this.transform.position = position;
			animator.SetFloat ("rat_state", vert);
		} else if (Input.GetKey (KeyCode.S)) {
			Vector3 position = this.transform.position;
			position.z -= 0.1f;
			this.transform.position = position;
			this.transform.Rotate (0, 90, 0);
			animator.SetFloat ("rat_state", vert);
		} else 
		{
			animator.SetFloat ("rat_state", vert);
		}
		Debug.Log (vert+"gaem");
	}
}
