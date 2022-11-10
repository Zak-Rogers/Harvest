using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    CharacterController controller;
    [SerializeField] float walkSpeed = 5.0f;
    float currentSpeed = 5.0f;
    [SerializeField] float runSpeed = 7.5f;

    [SerializeField] Mesh ghostMesh;
    [SerializeField] Mesh lifeMesh;

    float turnVelocity;
    float rotationSmoothTime = 0.1f;
    [SerializeField] Transform cameraTransform;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    void Update()
    {
        Movement();

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            currentSpeed = runSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            currentSpeed = walkSpeed;
        }

    }

    private void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(x, 0, z).normalized;

        if (direction != Vector3.zero)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, rotationSmoothTime);
            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            transform.rotation = Quaternion.Euler(0, angle, 0);
            controller.SimpleMove(moveDirection.normalized * currentSpeed);

        }


    }

}
