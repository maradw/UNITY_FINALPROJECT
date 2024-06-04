using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicLaunch : MonoBehaviour
{
	[SerializeField] private Rigidbody ball;
	[SerializeField] private Transform target;
	[SerializeField] private Transform _gun;

	public float h = 25;
	public float gravity = -18;

	public bool debugPath;

	void Update()
	{

	}
	public void SetTarget(Transform newTarget)
	{
		target = newTarget;
	}
	public void DeleteTarget()
	{
		target = null;
	}
	public void Launch()
	{
		Physics.gravity = Vector3.up * gravity;
		ball.useGravity = true;
		ball.velocity = CalculateLaunchData().initialVelocity;
	}

	LaunchData CalculateLaunchData()
	{
		float displacementY = target.position.y - _gun.position.y;
		Vector3 displacementXZ = new Vector3(target.position.x - _gun.position.x, 0, target.position.z - _gun.position.z);
		float time = Mathf.Sqrt(-2 * h / gravity) + Mathf.Sqrt(2 * (displacementY - h) / gravity);
		Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * h);
		Vector3 velocityXZ = displacementXZ / time;

		return new LaunchData(velocityXZ + velocityY * -Mathf.Sign(gravity), time);
	}

	void DrawPath()
	{
		LaunchData launchData = CalculateLaunchData();
		Vector3 previousDrawPoint = _gun.position;

		int resolution = 30;
		for (int i = 1; i <= resolution; i++)
		{
			float simulationTime = i / (float)resolution * launchData.timeToTarget;
			Vector3 displacement = launchData.initialVelocity * simulationTime + Vector3.up * gravity * simulationTime * simulationTime / 2f;
			Vector3 drawPoint = _gun.position + displacement;
			Debug.DrawLine(previousDrawPoint, drawPoint, Color.green);
			previousDrawPoint = drawPoint;
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
