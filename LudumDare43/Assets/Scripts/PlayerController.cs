using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float moveSpeed = 5f;
	[SerializeField]
	private float lookSensativity = 3f;

	private Camera cam;
	private PlayerMovement movement;

	private void Start()
	{
		movement = GetComponent<PlayerMovement>();
		cam = GetComponentInChildren<Camera>();
	}

	private void Update()
	{
		MovePlayer();

		CheckForPickup();
	}

	private void CheckForPickup()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				if (hit.transform.tag == "Pickupable")
				{
					print("you hit:" + hit.transform.name);
				}
				
			}

		}
	}

	private void MovePlayer()
	{
		// Calculate movement as a 3D vector
		float xMov = Input.GetAxisRaw("Horizontal");
		float yMov = Input.GetAxisRaw("Vertical");
		Vector3 movHorizontal = transform.right * xMov;
		Vector3 movVertical = transform.forward * yMov;
		Vector3 velocity = (movHorizontal + movVertical).normalized * moveSpeed;

		// Apply movement
		movement.Move(velocity);

		// Calculate palyer rotation as a 3D vector - only turning - we want the camera to rotate not the player
		float yRot = Input.GetAxisRaw("Mouse X");
		Vector3 rotation = new Vector3(0f, yRot, 0f) * lookSensativity;

		// Apply rotation
		movement.Rotate(rotation);

		// Calculate camera rotation as a 3D vector - for panning
		float xRot = Input.GetAxisRaw("Mouse Y");
		Vector3 cameraRotation = new Vector3(xRot, 0f, 0f) * lookSensativity;

		// Apply rotation to camera
		movement.RotateCamera(cameraRotation);
	}

}
