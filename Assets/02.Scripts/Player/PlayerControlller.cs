using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlller : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator anim;

    private GameManager gameManager;

    [SerializeField] private float moveSpeed = 5f;

    private Vector2 moveDir = Vector2.zero;
    public Vector2 MoveDir
    {
        get { return moveDir; }
    }

    private bool isPlay = true;

    private readonly int MoveX = Animator.StringToHash("MoveX");
    private readonly int MoveY = Animator.StringToHash("MoveY");
    private readonly int IsMove = Animator.StringToHash("IsMove");

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        float dirY = Input.GetAxisRaw("Vertical");
        moveDir = new Vector2(dirX, dirY);

        if (!isPlay || (dirX == 0 && dirY == 0))
        {
            anim.SetBool(IsMove, false);
            rigid.velocity = Vector2.zero;
            return;
        }
        else
        {
            anim.SetBool(IsMove, true);
            rigid.velocity = moveDir.normalized * moveSpeed;
        }

        anim.SetFloat(MoveX, dirX);
        anim.SetFloat(MoveY, dirY);
    }

    public void ChangeIsPlay()
    {
        isPlay = !isPlay;
    }

    public void LoadPlayerInfo(Vector2 _pos)
    {
        transform.position = _pos;
    }
}
