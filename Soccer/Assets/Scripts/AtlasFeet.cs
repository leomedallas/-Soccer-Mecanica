using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtlasFeet : MonoBehaviour
{
    public GameObject atlasPlayer;
    public Ball ball;
    public Player player;
    public Player otherPlayer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if (ball.PlayerHasBall && player.playerSliding == false)
            {

            }
            else if (player.playerSliding|| ball.PlayerHasBall == false)
            {
                other.transform.parent = atlasPlayer.transform;
                player.hasBall = true;
                otherPlayer.hasBall = false;
            }
        }
    }
}
