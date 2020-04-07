using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrounCheck : MonoBehaviour
{
    GameObject player;
    private void Start()
    {
        player = gameObject.transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            player.GetComponent<PlayerMovement>().canJump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            player.GetComponent<PlayerMovement>().canJump = false;
        }
    }
}
