using UnityEngine;
using System.Collections;

public class CarMovement : MonoBehaviour {

	public float acceleration = 0.3f;
	public float braking = 0.3f;
	public float steering = 4.0f;

	PlayerInputs _inputs;
	
	// Use this for initialization
	void Start () {
		_inputs = GetComponent<PlayerInputs>();
	}

	// update for physics
	void FixedUpdate() {
		// steering
		rigidbody2D.AddTorque(_inputs.x * steering * -0.2f);
//		float rot = transform.localEulerAngles.z - _inputs.x * steering;
//		transform.localEulerAngles = new Vector3(0.0f, 0.0f, rot);

		// acceleration/braking
//		float velocity = rigidbody2D.velocity.magnitude;
//		float y = _inputs.y;
//		if (y > 0.01f) {
//			velocity += y * acceleration;
//		} else if (y < -0.01f) {
//			velocity += y * braking;
//		}

		// apply car movement
		rigidbody2D.AddForce(transform.right * _inputs.y * acceleration * 50.0f);

//		rigidbody2D.velocity = transform.right * velocity;
//		rigidbody2D.angularVelocity = 0.0f;
	}
}
