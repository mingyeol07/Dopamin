using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grandma : MonoBehaviour
{
    public GameObject Ak;
    public Transform mouse;

    private void Awake()
    {
        StartCoroutine(GrandmaCoroutine());
    }

    private IEnumerator GrandmaCoroutine()
    {
        while (transform.position != new Vector3(-5, 0, 0))
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-5,0,0), Time.deltaTime * 8);
            yield return null;
        }

        yield return new WaitForSeconds(1);

        for (int i=0; i<47; i++)
        {
            GameObject a = Instantiate(Ak, mouse.position, Quaternion.identity);
            Vector2 dir = (Vector2)GameObject.FindGameObjectWithTag("Player").transform.position + new Vector2(Random.Range(-5f, 5f), Random.Range(-1f, 5f)) - (Vector2)transform.position;
            a.GetComponent<Rigidbody2D>().AddForce(dir.normalized * Random.Range(7,15f), ForceMode2D.Impulse);
            Destroy(a, 5);
            yield return null;
        }

        yield return new WaitForSeconds(0.25f);

        Destroy(gameObject);

        yield break;
    }
}
