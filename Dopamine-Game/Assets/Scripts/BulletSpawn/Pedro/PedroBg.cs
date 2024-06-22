using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedroBg : MonoBehaviour
{
    public float speed;
    public Vector2 targetPos;
    public Coroutine coroutine;

    private void Update()
    {
        transform.Translate((targetPos - (Vector2)transform.position).normalized * speed * Time.deltaTime);
    }

    public void Move()
    {
        coroutine = StartCoroutine(MoveCoroutine());
    }

    public IEnumerator MoveCoroutine()
    {
        while (true)
        {
            targetPos = (Vector2)transform.position - new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));

            while (Mathf.Abs(targetPos.x) > 4.5f || Mathf.Abs(targetPos.y) > 1)
            {
                targetPos = (Vector2)transform.position - new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
            }

            yield return new WaitForSeconds(Random.Range(1,2f));
        }
    }

    private void OnDestroy()
    {
        StopCoroutine(coroutine);
    }
}
