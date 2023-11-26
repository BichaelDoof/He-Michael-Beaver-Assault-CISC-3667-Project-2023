using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior : MonoBehaviour
{
    [SerializeField] float LRmovement;
    [SerializeField] float TBmovement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] const int SPEED = 15;
    [SerializeField] const float PROJECTILESPEED = 0.01f;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool shootPressed = false;
    //[SerializeField] Animator animator;
    [SerializeField] GameObject projectile;

    const int IDLE = 0;
    const int SHOOT = 1;
    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        //if (animator == null)
        //    animator = GetComponent<Animator>();
        //animator.SetInteger("motion", IDLE);
    }

    // Update is called once per frame
    void Update()
    {
         LRmovement = Input.GetAxis("Horizontal");
         TBmovement = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Shoot"))
            shootPressed = true;
    }

    //called potentially many times per frame
    //use for physics & movement
    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(SPEED * TBmovement, rigid.velocity.y);
        rigid.velocity = new Vector2(SPEED * LRmovement, rigid.velocity.x);
        if (LRmovement < 0 && isFacingRight || LRmovement > 0 && !isFacingRight)
            Flip();
        if (shootPressed)
        {
            //animator.SetInteger("motion", SHOOT);
            Shoot();
        }
        else
        { 
            shootPressed = false;
        }

        
    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    private void Shoot()
    {
        GameObject projectileFire = Instantiate(projectile, transform.position, Quaternion.identity);
        shootPressed = false;
        //animator.SetInteger("motion", IDLE);
    }
}
