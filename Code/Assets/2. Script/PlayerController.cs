using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D myRigidbody;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private List<Collider2D> allCollider = new List<Collider2D>();
    [ReadOnly]
    [SerializeField]
    private bool is_ground = false;
    private enum movekeyset
    {
        right,
        left
    }
    private List<movekeyset> current_move = new List<movekeyset>();
    private bool is_sit = false;
    private float jump_delay_count;

    // Update is called once per frame
    void Update()
    {
        GetKey();
        Move();
        MaxSpeed();
        CheckJump();
        Jump();
        Intract();
        Sit();
        Snake();
    }

    #region <Move>
    private void GetKey()
    {
        if (Input.GetKeyDown(Value.Key_LeftMove))
        {
            current_move.Add(movekeyset.left);
        }
        if (Input.GetKeyDown(Value.Key_RightMove))
        {
            current_move.Add(movekeyset.right);
        }

        if (Input.GetKeyUp(Value.Key_LeftMove))
        {
            current_move.Remove(movekeyset.left);
        }
        if (Input.GetKeyUp(Value.Key_RightMove))
        {
            current_move.Remove(movekeyset.right);
        }
    }

    private void Move()
    {
        if (current_move.Count == 0)
        {
            //todo 나중에 바닥면의 재질을 받아서 정지 처리
            myRigidbody.velocity = new Vector3(0, myRigidbody.velocity.y, 0);
        }
        else
        {
            if (current_move[current_move.Count - 1] == movekeyset.left)
            {
                myRigidbody.AddForce(new Vector3(-1 * Value.Player_MoveSpeed, 0), ForceMode2D.Impulse);
                spriteRenderer.flipX = true;
            }else if (current_move[current_move.Count - 1] == movekeyset.right)
            {
                myRigidbody.AddForce(new Vector3(Value.Player_MoveSpeed, 0), ForceMode2D.Impulse);
                spriteRenderer.flipX = false;
            }
        }
    }

    private void MaxSpeed()
    {
        if(myRigidbody.velocity.x > Value.Player_MoveSpeed)
        {
            myRigidbody.velocity = new Vector3(Value.Player_MoveSpeed, myRigidbody.velocity.y);
        }

        if (myRigidbody.velocity.x < Value.Player_MoveSpeed * -1)
        {
            myRigidbody.velocity = new Vector3(Value.Player_MoveSpeed * -1, myRigidbody.velocity.y);
        }
    }

    private void CheckJump()
    {
        jump_delay_count += Time.deltaTime;

        if (Input.GetKeyDown(Value.Key_Jump))
        {
            jump_delay_count = 0;
        }
    }

    private void resetOnGround(Collider2D collision)
    {
        if (!is_ground && collision.gameObject.TryGetComponent<Property>(out Property p))
        {
            if (p.is_static)
            {
                is_ground = true;
            }
        }
    }

    private void Jump()
    {
        if (jump_delay_count < Value.Player_JumpDelayTime && is_ground)
        {
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, Value.Player_JumpHight);
            is_ground = false;
        }
    }

    private void Sit()
    {
        if (Input.GetKeyDown(Value.Key_Sit))
        {

        }
        else if (Input.GetKeyUp(Value.Key_Sit))
        {

        }
    }

    private void Snake()
    {
        if (Input.GetKeyDown(Value.Key_Snake))
        {
            Util.ChangeLayerforChild(gameObject, Value.Layer.Layer_PlayerSnake, 4);
        }
        if (Input.GetKeyUp(Value.Key_Snake))
        {
            Util.ChangeLayerforChild(gameObject, Value.Layer.Layer_PlayerNomal, 4);
        }
    }
    #endregion

    #region <Collider>
    public void OnMainColliderEnter(Collision2D collision)
    {
        
    }

    public void OnMainColliderExit(Collision2D collision)
    {
        
    }

    public void OnMainTriggerEnter(Collider2D collision)
    {
        allCollider.Add(collision);
    }

    public void OnMainTriggerExit(Collider2D collision)
    {
        allCollider.Remove(collision);
    }

    public void OnBottomTriggerEnter(Collider2D collision)
    {
        resetOnGround(collision);
    }

    public void OnBottomTriggerStay(Collider2D collision)
    {
        resetOnGround(collision);
    }

    public void OnBottomTriggerExit(Collider2D collision)
    {
        is_ground = false;
    }
    #endregion

    #region <Action>
    private void Intract()
    {
        if (Input.GetKeyDown(Value.Key_Intract))
        {
            foreach(Collider2D collider in allCollider)
            {
                if (collider.TryGetComponent<Property>(out Property property))
                {
                    if (property.is_interactable)
                    {
                        property.interactable.run_Interaction();
                    }
                }
            }
            
        }
    }
    #endregion
}
