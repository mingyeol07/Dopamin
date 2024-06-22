using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanghuruAl : MonoBehaviour
{
    public float speed;

    private void Awake()
    {
        Destroy(gameObject, 10);
    }

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
