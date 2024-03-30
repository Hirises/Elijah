using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainCollider : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerController.OnMainColliderEnter(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        playerController.OnMainColliderExit(collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerController.OnMainTriggerEnter(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerController.OnMainTriggerExit(collision);
    }
}
