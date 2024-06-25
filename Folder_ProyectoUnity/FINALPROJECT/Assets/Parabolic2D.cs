using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parabolic2D : MonoBehaviour
{
	[SerializeField] private Rigidbody ball;

	public float h = 25;
	public float gravity = -18;

	public bool debugPath;

	/*void Update()
	{

	}
	public void SetTarget(Transform newTarget)
	{
		target = newTarget;
	}
	public void DeleteTarget()
	{
		target = null;
	}*/
	public void Launch(Transform target)
	{
		Physics.gravity = Vector2.up * gravity;
		ball.useGravity = true;
		ball.velocity = CalculateLaunchData(target).initialVelocity;
	}

	LaunchData CalculateLaunchData(Transform target)
	{
		float displacementY = target.position.y - ball.position.y;
		Vector3 displacementXZ = new Vector3(0, target.position.y - ball.position.y, target.position.z - ball.position.z);
		float time = Mathf.Sqrt(-2 * h / gravity) + Mathf.Sqrt(2 * (displacementY - h) / gravity);
		Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * h);
		Vector3 velocityXZ = displacementXZ / time;

		return new LaunchData(velocityXZ + velocityY * -Mathf.Sign(gravity), time);
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
