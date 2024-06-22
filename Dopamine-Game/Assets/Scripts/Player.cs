using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform cam;
    private Rigidbody2D rigid;
    private Animator animator;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 moveVec = new Vector2(h, v).normalized;

        rigid.velocity = moveVec * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Damaged();
            DownFocus();
        }
    }

    private void DownFocus()
    {
        PlayerManager.Instance.PlayerDamaged();
    }

    private void Damaged()
    {
        animator.SetTrigger("Damaged");
        cam.GetComponent<CameraShake>().StartShake(0.3f);
    }
}
