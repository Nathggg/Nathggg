using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float moveSpeed = 4f;

    public Rigidbody2D rb;
    public Animator animator;

    public float rollRate = 2f;
    public float nextRollTime = 0f;

    public bool isRolling = false;
    public float rollSpeed = 3f;

    public RectTransform AttackPoint;

    Vector2 movement;

    void Update()
    {
        if (Time.time >= nextRollTime)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                roll();
                nextRollTime = Time.time + 1f / rollRate;
                isRolling = true;
            }
            else
            {
                isRolling = false;
            }
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if(Input.GetAxisRaw("Vertical") > 0)
        {
            AttackPoint.position = this.transform.position + new Vector3(0f, 0.5f, 0f);
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            AttackPoint.position = this.transform.position+ new Vector3(0f, -0.5f, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            AttackPoint.position = this.transform.position + new Vector3(1f, 0f, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            AttackPoint.position = this.transform.position + new Vector3(-1f, 0f, 0f);
        }
    }

    void FixedUpdate()
    {
        if(isRolling == true)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * rollSpeed * Time.fixedDeltaTime);
        }
        else
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    public void roll()
    {
        animator.SetTrigger("Roll");
    }

}
