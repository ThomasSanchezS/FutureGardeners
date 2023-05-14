using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    private CharacterController characterController;
    public new Transform camera;
    public float speed = 4f;
    public float gravity = -9.18f;
    public Animator animate;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animate = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal2");
        float vertical = Input.GetAxis("Vertical2");
        Vector3 movement = Vector3.zero;
        float movementSpeed = 0f;

        if (horizontal != 0 || vertical != 0)
        {

            Vector3 forward = camera.forward;
            forward.y = 0;
            forward.Normalize();

            Vector3 right = camera.right;
            right.y = 0;
            right.Normalize();

            Vector3 direction = forward * vertical + right * horizontal;
            movementSpeed = Mathf.Clamp01(direction.magnitude);
            direction.Normalize();

            movement = direction * speed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.2f);
            animate.SetBool("isWalking", true);
        }
        else
        {
            animate.SetBool("isWalking", false);
        }
        if (transform.position.y != 0)
        {
            Vector3 posY = transform.position;
            posY.y = 0;
            transform.position = posY;
        }

        movement.y += gravity * Time.deltaTime;
        characterController.Move(movement);

    }
}
