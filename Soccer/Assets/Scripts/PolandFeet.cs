using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolandFeet : MonoBehaviour
{
    public GameObject polandPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            other.transform.parent = polandPlayer.transform;
        }
    }
}
