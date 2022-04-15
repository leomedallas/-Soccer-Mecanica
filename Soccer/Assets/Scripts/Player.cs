using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    public Animator anim;
    public Transform height;
    public Transform target;
    public Transform origin;
    public Vector3 moveInput;

    public float runSpeed;
    public float walkSpeed;
    public float rotationSpeed;
    public float shootStrength;
    public float gravityScale;
    public bool hasBall;
    public bool playerSliding;
    public bool stopMove;
    public Ball ball;

    public bool PlayerSliding { get => playerSliding; set => playerSliding = value; }

}

public interface IPLayer
{
    void Shoot();
    void Move();
    void Slide();
    void Pass();
    void Idle();
}

