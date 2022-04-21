using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private bool playerHasBall;
    [SerializeField]  AudioSource goal;
    public Rigidbody rbody;

    public bool PlayerHasBall { get => playerHasBall; set => playerHasBall = value; }

    private void Update()
    {
        if (Input.GetButtonDown("Shoot"))
        {
            rbody.AddForce(0, 0, 300);
            transform.parent = null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PolandGoal"))
        {
            goal.Play();
            Destroy(this.gameObject);
            Score.pointsA++;
        }
        else if (other.CompareTag("AtlasGoal"))
        {
            goal.Play();
            Destroy(this.gameObject);
            Score.pointsP++;
        }
    }
}
