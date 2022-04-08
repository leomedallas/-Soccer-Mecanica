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

    public float speed;
    public float shootStrength;
    public bool hasBall;
}

public interface IPLayer
{
    void Shoot();
    void Move();
    void Slide();
    void Pass();

}

