using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float speed = 5f;

	private PlayerMovement movement;

	private void Start()
	{
		movement = GetComponent<PlayerMovement>();
	}

	private void Update()
	{
		// Calculate movement as a 3D vector
		float xMov = Input.GetAxisRaw("Horizontal");
		float yMov = Input.GetAxisRaw("Vertical");

		Vector3 movHorizontal = transform.right * xMov;
		Vector3 movVertical = transform.forward * yMov;

		// Final movement vetor
		Vector3 velocity = (movHorizontal + movVertical).normalized * speed;

		// Apply movement
		movement.Move(velocity);

	}

}
