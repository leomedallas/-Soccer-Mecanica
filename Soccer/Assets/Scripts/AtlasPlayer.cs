using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtlasPlayer : Player, IPLayer
{
    private void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

        gravityScale = -20.0f;
        runSpeed = 5.0f;
        walkSpeed = 2.0f;
        rotationSpeed = 720.0f;
    }

    private void Update()
    {
        Move();
    }

    public void Idle()
    {
        anim.SetBool("SlowRunning", false);

        if (moveInput != Vector3.zero)
        {
            Move();
        }
    }

    public void Shoot()
    {

    }

    public void Move()
    {
        anim.SetBool("SlowRunning", true);

        if (controller.isGrounded)
        {
            moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            moveInput = Vector3.ClampMagnitude(moveInput, 1f);
            moveInput.Normalize();

            if (moveInput == Vector3.zero)
            {
                Idle();
            }

            if (Input.GetButton("Sprint"))
            {
                anim.SetBool("FastRunning", true);
                transform.Translate(moveInput * runSpeed, Space.World);
                controller.Move(moveInput * runSpeed * Time.deltaTime);
            }
            else
            {
                anim.SetBool("FastRunning", false);
                transform.Translate(moveInput * walkSpeed, Space.World);
                controller.Move(moveInput * walkSpeed * Time.deltaTime);
            }

            if(moveInput != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(moveInput, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);
            }
        }

        moveInput.y += gravityScale * Time.deltaTime;
        controller.Move(moveInput * Time.deltaTime);
    }

    public void Slide()
    {

    }

    public void Pass()
    {

    }
}



