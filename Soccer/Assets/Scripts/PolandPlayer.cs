using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolandPlayer : Player, IPLayer
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


    public void Move()
    {
        anim.SetBool("SlowRunning", true);

        if (controller.isGrounded)
        {
            moveInput = new Vector3(Input.GetAxis("Horizontal2"), 0f, Input.GetAxis("Vertical2"));
            moveInput = Vector3.ClampMagnitude(moveInput, 1f);
            moveInput.Normalize();

            if (moveInput == Vector3.zero)
            {
                Idle();
            }

            if (Input.GetButton("Sprint2") && stopMove == false)
            {
                anim.SetBool("FastRunning", true);
                transform.Translate(moveInput * runSpeed, Space.World);
                controller.Move(moveInput * runSpeed * Time.deltaTime);
            }
            else if (Input.GetButtonDown("Slide2"))
            {
                Slide();
            }
            else if (Input.GetButtonDown("Shoot2"))
            {
                Shoot();
            }
            else if (Input.GetButtonDown("Pass2"))
            {
                Pass();
            }
            else
            {
                anim.SetBool("FastRunning", false);
                transform.Translate(moveInput * walkSpeed, Space.World);
                controller.Move(moveInput * walkSpeed * Time.deltaTime);
            }

            if (moveInput != Vector3.zero && stopMove == false)
            {
                Quaternion toRotation = Quaternion.LookRotation(moveInput, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);
            }
        }

        moveInput.y += gravityScale * Time.deltaTime;
        if (stopMove == false)
        {
            controller.Move(moveInput * Time.deltaTime);
        }
    }

    public void Shoot()
    {
        stopMove = true;
        StartCoroutine("StopMove");
        ball.transform.parent = null;
        Lanzar();
        ball.PlayerHasBall = false;
        anim.SetTrigger("Throw");
    }

    public void Slide()
    {
        anim.SetTrigger("Slide");
        playerSliding = true;
        StartCoroutine("Sliding");
    }

    public void Pass()
    {
        stopMove = true;
        StartCoroutine("StopMove");
        ball.transform.parent = null;
        Lanzar2();
        ball.PlayerHasBall = false;
        anim.SetTrigger("Pass");
    }

    IEnumerator Sliding()
    {
        yield return new WaitForSeconds(1f);
        playerSliding = false;
    }

    IEnumerator StopMove()
    {
        yield return new WaitForSeconds(1f);
        stopMove = false;
    }

    void Lanzar()
    {
        Rigidbody ballRB = ball.GetComponent<Rigidbody>();
        Physics.gravity = Vector3.up * gravityScale;
        ballRB.useGravity = true;
        ballRB.velocity = CalcularVelocidadInicial();
        print(ballRB.velocity);

    }
    Vector3 CalcularVelocidadInicial()
    {
        Vector3 desplazamientoP = ball.transform.position - target.position;

        float velocidadY, velocidadX, velocidadZ;
        velocidadY = Mathf.Sqrt(-2 * gravityScale * height.position.y);
        velocidadX = desplazamientoP.x / ((-velocidadY / gravityScale) + (Mathf.Sqrt(2 * (desplazamientoP.y - height.position.y) / gravityScale)));
        velocidadZ = desplazamientoP.z / ((-velocidadY / gravityScale) + (Mathf.Sqrt(2 * (desplazamientoP.y - height.position.y) / gravityScale)));

        return new Vector3(-velocidadX, velocidadY, -velocidadZ);
    }
    void Lanzar2()
    {
        Rigidbody ballRB = ball.GetComponent<Rigidbody>();
        Physics.gravity = Vector3.up * gravityScale;
        ballRB.useGravity = true;
        ballRB.velocity = CalcularVelocidadInicial();
        print(ballRB.velocity);

    }
    Vector3 CalcularVelocidadInicial2()
    {
        Vector3 desplazamientoP = ball.transform.position - target2.position;

        float velocidadY, velocidadX, velocidadZ;
        velocidadY = Mathf.Sqrt(-2 * gravityScale * height2.position.y);
        velocidadX = desplazamientoP.x / ((-velocidadY / gravityScale) + (Mathf.Sqrt(2 * (desplazamientoP.y - height2.position.y) / gravityScale)));
        velocidadZ = desplazamientoP.z / ((-velocidadY / gravityScale) + (Mathf.Sqrt(2 * (desplazamientoP.y - height2.position.y) / gravityScale)));

        return new Vector3(-velocidadX, velocidadY, -velocidadZ);
    }
}