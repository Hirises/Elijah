using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBottomTrigger : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerController.OnBottomTriggerEnter(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        playerController.OnBottomTriggerStay(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerController.OnBottomTriggerExit(collision);
    }
}
