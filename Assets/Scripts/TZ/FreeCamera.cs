using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class FreeCamera : MonoBehaviour
{
	[Header("Movement")]
	[SerializeField] private float speed = 1.5f;
	[SerializeField] private float acceleration = 10f;
	
	[Header("Look")]
	[SerializeField] private float sensitivity = 5f;
	
	[Header("References")]
	[SerializeField] private Camera mainCamera;

	private Rigidbody body;
	private float rotY;
	private Vector3 direction;

	void Awake()
	{
		body = GetComponent<Rigidbody>();
		body.freezeRotation = true;
		body.useGravity = false;
		body.mass = 0.1f;
		body.linearDamping = 10;
	}
	
	void Update()
	{
		Move();
	}
	
	void FixedUpdate()
	{
		body.AddForce(direction.normalized * speed * acceleration);

		if (Mathf.Abs(body.linearVelocity.x) > speed) body.linearVelocity = new Vector3(Mathf.Sign(body.linearVelocity.x) * speed, body.linearVelocity.y, body.linearVelocity.z);
		if (Mathf.Abs(body.linearVelocity.z) > speed) body.linearVelocity = new Vector3(body.linearVelocity.x, body.linearVelocity.y, Mathf.Sign(body.linearVelocity.z) * speed);
		if (Mathf.Abs(body.linearVelocity.y) > speed) body.linearVelocity = new Vector3(body.linearVelocity.x, Mathf.Sign(body.linearVelocity.y) * speed, body.linearVelocity.z);
	}

	void Move()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		float rotX = mainCamera.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
		rotY += Input.GetAxis("Mouse Y") * sensitivity;
		rotY = Mathf.Clamp(rotY, -90, 90);

		if (Input.GetKey(KeyCode.Mouse1))
		{
			mainCamera.transform.localEulerAngles = new Vector3(-rotY, rotX, 0);
		}

		direction = new Vector3(h, 0, v);
		direction = mainCamera.transform.TransformDirection(direction);
	}
}
