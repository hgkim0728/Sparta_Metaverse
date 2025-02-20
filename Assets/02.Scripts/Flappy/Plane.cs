using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rigid;

    FlappyManager manager;

    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    float deathCooldown = 0f;

    bool isFlap = false;

    private readonly int FlapIsDie = Animator.StringToHash("FlapIsDie");

    void Start()
    {
        manager = FlappyManager.FlappyInstance;

        anim = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                // 게임 재시작
                //if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                //{
                //    manager.RestartGame();
                //}
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead) return;

        Vector3 velocity = rigid.velocity;
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        rigid.velocity = velocity;

        float angle = Mathf.Clamp((rigid.velocity.y * 10), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        isDead = true;
        deathCooldown = 1f;

        anim.SetInteger(FlapIsDie, 1);
        manager.GameOver();
    }
}
