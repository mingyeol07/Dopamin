using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanghuru : MonoBehaviour
{
    public GameObject tanghuruAl;
    public float speed;

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    public void Destroy(float time)
    {
        Destroy(gameObject, time);
    }

    private void OnDestroy()
    {
        for (int i=0; i<5; i++)
        {
            Transform t = Instantiate(tanghuruAl, transform.position, Quaternion.identity).transform;
            t.localEulerAngles = new Vector3(0, 0, i * 72);
        }
    }
}
