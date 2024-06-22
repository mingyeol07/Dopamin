using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.UI;

public class InfinitePlayer : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rigid;
    private Animator animator;

    private bool unbeatable;
    private bool isDash;
    [SerializeField] private Image dashIcon;
    private TrailRenderer trailRenderer;

    private void Awake()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!InfiniteManager.Instance.isGameClear)
        {
            if(!isDash) Move();
            Dash();
        }
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

    private void Dash()
    {
        if (dashIcon.fillAmount < 1) dashIcon.fillAmount += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && dashIcon.fillAmount >= 1)
        {
            dashIcon.fillAmount = 0;
            StartCoroutine(Dashing());
        }
    }

    private IEnumerator Dashing()
    {
        unbeatable = true;
        isDash = true;
        trailRenderer.enabled = true;
        rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y).normalized * 10;
        yield return new WaitForSeconds(0.3f);
        trailRenderer.enabled = false;
        unbeatable = false;
        isDash = false;
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

