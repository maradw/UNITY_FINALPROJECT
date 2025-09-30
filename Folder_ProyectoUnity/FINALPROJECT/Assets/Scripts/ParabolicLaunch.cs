using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicLaunch : MonoBehaviour
{
	[SerializeField] private Rigidbody ball;

	public float h = 25;
	public float gravity = -18;

	public bool debugPath;

	public void Launch(Transform target)
	{
		Physics.gravity = Vector3.up * gravity;
		ball.useGravity = true;
		ball.linearVelocity = CalculateLaunchData(target).initialVelocity;
	}

	LaunchData CalculateLaunchData(Transform target)
	{
		float displacementY = target.position.y - ball.position.y;
		Vector3 displacementXZ = new Vector3(target.position.x - ball.position.x, 0, target.position.z - ball.position.z);
		float time = Mathf.Sqrt(-2 * h / gravity) + Mathf.Sqrt(2 * (displacementY - h) / gravity);
		Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * h);
		Vector3 velocityXZ = displacementXZ / time;

		return new LaunchData(velocityXZ + velocityY * -Mathf.Sign(gravity), time);
	}
    private void OnTriggerEnter(Collider other)
    {
		if (other.tag == "Ground" ||other.tag == "Player")
		{
			Destroy(this.gameObject);
		}
	}

    struct LaunchData
	{
		public readonly Vector3 initialVelocity;
		public readonly float timeToTarget;

		public LaunchData(Vector3 initialVelocity, float timeToTarget)
		{
			this.initialVelocity = initialVelocity;
			this.timeToTarget = timeToTarget;
		}

	}
}
