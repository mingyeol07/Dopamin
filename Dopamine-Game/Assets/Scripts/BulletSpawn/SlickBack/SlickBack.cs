using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlickBack : MonoBehaviour
{
    public float speed;
    public Vector2 moveDir;
    public SpriteRenderer sr;

    private void Awake()
    {
        StartCoroutine(MoveCoroutine());
        Destroy(gameObject, 6.5f);
    }

    private void Update()
    {
        transform.Translate(moveDir.normalized *  speed * Time.deltaTime);
    }

    private IEnumerator MoveCoroutine()
    {
        while (true)
        {
            moveDir = (Vector2)GameObject.FindGameObjectWithTag("Player").transform.position + new Vector2(Random.Range(-7f, 7f), Random.Range(-1f, 1f)) - (Vector2)transform.position;
            sr.flipX = GameObject.FindGameObjectWithTag("Player").transform.position.x - transform.position.x > 0 ? true : false;
            float waitTime = Random.Range(1, 2f);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
