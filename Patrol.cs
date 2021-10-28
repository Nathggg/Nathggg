using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    
    public Transform wayPoint01, wayPoint02;
    private Transform wayPointTarget;
    [SerializeField] private float moveSpeed;

    [SerializeField] private float attackRange;
    private SpriteRenderer sp;

    private Transform target;

    private Animator animator;
    public Projectile projectile;
    public Transform firePoint;

    private void Start()
    {
        wayPointTarget = wayPoint01;
        sp = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, target.position) >= attackRange)//outside range
        {
            animator.SetBool("isAttack", false);
            patrol();
        } else
        {
            animator.SetBool("isAttack", true);
        }
    }

    private void patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPointTarget.position, moveSpeed * Time.deltaTime);

        if(Vector2.Distance(transform.position, wayPoint01.position) <= 0.01f)
        {
            wayPointTarget = wayPoint02;

            //sp.flipX = true;
            Vector3 localTemp = transform.localScale;
            localTemp.x *= 1;
            transform.localScale = localTemp;
        }

        if(Vector2.Distance(transform.position, wayPoint02.position) <= 0.01f)
        {
            wayPointTarget = wayPoint01;

            //sp.flipX = false;
             Vector3 localTemp = transform.localScale;
            localTemp.x *= 1;
            transform.localScale = localTemp;
        }
    }

    public void Shot()
    {
        Instantiate(projectile, firePoint.position , Quaternion.identity);
    }
}
