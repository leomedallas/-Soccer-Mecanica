using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolandFeet : MonoBehaviour
{
    public GameObject polandPlayer;
    public Ball ball;
    public Player player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if (ball.PlayerHasBall && player.playerSliding == false)
            {

            }
            else if (player.playerSliding || ball.PlayerHasBall == false)
            {
                other.transform.parent = polandPlayer.transform;
                ball.PlayerHasBall = true;
            }
        }
    }
}
