using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private bool playerHasBall;

    public bool PlayerHasBall { get => playerHasBall; set => playerHasBall = value; }

}
