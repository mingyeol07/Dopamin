using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tomb : MonoBehaviour
{
    public bool isStop;
    public bool isRight;
    public GameObject tombPiece;

    private void Update()
    {
        if (isStop)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y, 0), Time.deltaTime * 25);
        }
        else
        {
            if (isRight)
            {
                transform.Translate(Vector2.right * Time.deltaTime * 8);
            }
            else
            {
                transform.Translate(Vector2.left * Time.deltaTime * 8);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Tomb>() != null)
        {
            for (int i = 0; i < 5; i++)
            {
                Transform t = Instantiate(tombPiece, transform.position, Quaternion.identity).transform;
                t.localEulerAngles = new Vector3(0, 0, i * 72);
            }
            Destroy(gameObject);
        }
    }
}
