using UnityEngine;
using System.Collections;

public class AICarMovement : MonoBehaviour {

	public float acceleration = 0.3f;
	public float braking = 0.3f;
	public float steering = 4.0f;

	Vector3 target;

	public void OnNextTrigger(TrackLapTrigger next) {

		// choose a target to drive towards
		target = Vector3.Lerp(next.transform.position - next.transform.up, 
		                      next.transform.position + next.transform.up, 
		                      Random.value);
	}

	void SteerTowardsTarget ()
	{
		Vector2 towardNextTrigger = target - transform.position;
		float targetRot = Vector2.Angle (Vector2.right, towardNextTrigger);
		if (towardNextTrigger.y < 0.0f) {
			targetRot = -targetRot;
		}
		float rot = Mathf.MoveTowardsAngle (transform.localEulerAngles.z, targetRot, steering);
		transform.eulerAngles = new Vector3 (0.0f, 0.0f, rot);
	}

	// update for physics
	void FixedUpdate() {

		SteerTowardsTarget();

		// always accelerate
		float velocity = rigidbody2D.velocity.magnitude;
		velocity += acceleration;

		// apply car movement
		rigidbody2D.velocity = transform.right * velocity;
		rigidbody2D.angularVelocity = 0.0f;
	}
}
