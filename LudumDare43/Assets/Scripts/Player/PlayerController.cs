using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float heath = 100;
	public bool warming = false;
	public Image healthbar;


	[SerializeField]
	public float moveSpeed = 5f;
	[SerializeField]
	public float lookSensativity = 3f;

	private Camera cam;
	private PlayerMovement movement;
	private AudioController music;

	private void Start()
	{
		movement = GetComponent<PlayerMovement>();
		cam = GetComponentInChildren<Camera>();
		GameObject.FindWithTag("TourchModel").GetComponent<MeshRenderer>().enabled = false;
		music = GameObject.FindObjectOfType<AudioController>();
	}

	private void Update()
	{
		MovePlayer();
		CheckForPickup();
		Chill();
		UpdateHealthBar();
	}

	public void WarmUp()
	{
		heath += 1 * Time.deltaTime * 4;
		heath = Mathf.Clamp(heath, 0f, 100f);
	}

	private void Chill()
	{
		if (!warming)
		{
			heath -= 1 * Time.deltaTime * 8;
		}

		if (heath < 0)
		{
			Die();
		}
	}

	private void Die()
	{
		Debug.Log("you died!");
		music.ExitHouse();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
	}

	private void UpdateHealthBar()
	{
		healthbar.fillAmount = heath / 100;
	}

	private void CheckForPickup()
	{

		// Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
		// Debug.DrawRay(ray.origin, ray.direction * 10, Color.black);

		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2));
			RaycastHit hit;

		
			if ((Physics.Raycast(ray, out hit)) && (hit.distance < 3f))
			{
				if (hit.transform.tag == "Pickupable")
				{
					print("you hit:" + hit.transform.name);
					hit.transform.GetComponent<Pickupable>().Pickup(hit.transform.name);					
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
