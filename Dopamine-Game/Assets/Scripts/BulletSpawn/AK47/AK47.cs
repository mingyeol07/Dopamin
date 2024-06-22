using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : MonoBehaviour
{
    public GameObject bullet;
    public Transform muzzle;

    private void Awake()
    {
        StartCoroutine(AK47Coroutine());
    }

    private IEnumerator AK47Coroutine()
    {
        while (transform.position != new Vector3(7, 0))
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(7, 0), Time.deltaTime * 7);
            yield return null;
        }

        //yield return new WaitForSeconds(0.25f);

        for (int i=0; i<180; i++)
        {
            transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z + 2);
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        for (int i=0; i<5; i++)
        {
            Vector2 dir = (Vector2)GameObject.FindGameObjectWithTag("Player").transform.position + new Vector2(Random.Range(-4f, 4f), Random.Range(-4f, 4f)) - (Vector2)transform.position;
            GameObject b = Instantiate(bullet, muzzle.position, Quaternion.identity);
            b.transform.up = dir.normalized;
            yield return new WaitForSeconds(0.2f);
        }

        Destroy(gameObject);

        yield break;
    }
}
