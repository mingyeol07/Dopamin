using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedroRacoon : MonoBehaviour
{
    public Transform racoon;
    public Transform racoonImage;
    public float radius;
    public float deg;
    public float speed;
    public bool isSmall;
    public float sizeSpeed;

    private void Awake()
    {
        StartCoroutine(PedroRacoonCoroutine());
    }

    private IEnumerator PedroRacoonCoroutine()
    {
        while (transform.position != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, Time.deltaTime * 2.5f);
            yield return null;
        }

        yield return new WaitForSeconds(1.4f);
        StartCoroutine(PedroRacoonSizeCoroutine());

        while (true)
        {
            deg -= Time.deltaTime * speed;
            if (deg < 360)
            {
                var rad = Mathf.Deg2Rad * (deg);
                var x = radius * Mathf.Sin(rad);
                var y = radius * Mathf.Cos(rad);
                racoon.transform.position = transform.position + new Vector3(x, y);
                racoon.transform.rotation = Quaternion.Euler(0, 0, deg * -1);
            }

            yield return null;
        }
    }

    private IEnumerator PedroRacoonSizeCoroutine()
    {
        while (true)
        {
            if (isSmall)
            {
                racoonImage.localScale = new Vector2(racoonImage.localScale.x - Time.deltaTime * sizeSpeed, racoonImage.localScale.y - Time.deltaTime * sizeSpeed);
                if (racoonImage.localScale.x <= 0.65) isSmall = false;
            }
            else
            {
                racoonImage.localScale = new Vector2(racoonImage.localScale.x + Time.deltaTime * sizeSpeed, racoonImage.localScale.y + Time.deltaTime * sizeSpeed);
                if (racoonImage.localScale.x >= 0.85) isSmall = true;
            }
            yield return null;
        }
    }
}
