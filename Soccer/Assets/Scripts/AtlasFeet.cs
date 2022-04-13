using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtlasFeet : MonoBehaviour
{
    public GameObject atlasPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            other.transform.parent = atlasPlayer.transform;
        }
    }
}
