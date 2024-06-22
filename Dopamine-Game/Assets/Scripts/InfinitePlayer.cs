using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class InfinitePlayer : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rigid;
    private Animator animator;

    private bool unbeatable;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!InfiniteManager.Instance.isGameClear) Move();
        else rigid.velocity = Vector2.zero;
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
        if (collision.gameObject.CompareTag("Bullet") && !unbeatable)
        {
            Damaged();
            DownFocus();
        }

        if (collision.gameObject.CompareTag("TimeUpItem"))
        {
            InfiniteManager.Instance.PlusTimeItem();
            animator.SetTrigger("GetItem");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && !unbeatable)
        {
            Damaged();
            DownFocus();
        }
    }

    private void DownFocus()
    {
        InfiniteManager.Instance.HpDown();
    }

    private void Damaged()
    {
        animator.SetTrigger("Damaged");
        Camera.main.GetComponent<CameraShake>().StartShake(0.3f);
        StartCoroutine(Unbeatable());
    }

    IEnumerator Unbeatable()
    {
        unbeatable = true;
        yield return new WaitForSeconds(1f);
        unbeatable = false;
    }
}

