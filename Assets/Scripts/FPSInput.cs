using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]

public class FPSInput : MonoBehaviour {

    private CharacterController _characterController;

    public float speed = 6.0f;
    public float gravity = -9.8f;

	// Use this for initialization
	void Start () {
        _characterController = GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update () {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaY = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX * Time.deltaTime, 0, deltaY * Time.deltaTime);

        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;


        movement = transform.TransformDirection(movement);
        _characterController.Move(movement);
	}
}
