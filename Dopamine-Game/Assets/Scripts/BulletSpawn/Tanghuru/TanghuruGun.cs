using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanghuruGun : MonoBehaviour
{
    public GameObject tanghuru;
    public SpriteRenderer gunSR;
    public bool zPlus;
    public float destroyTanghuruTime;

    private void Start()
    {
        StartCoroutine(TanghuruGunCoroutine());
    }

    private IEnumerator TanghuruGunCoroutine()
    {
        while (gunSR.color.a < 1)
        {
            gunSR.color = new Color(1,1,1,gunSR.color.a + Time.deltaTime * 2);
            Vector2 upPos = (Vector2)GameObject.FindGameObjectWithTag("Player").transform.position - (Vector2)transform.position;
            transform.up = upPos.normalized;
            yield return null;
        }

        yield return new WaitForSeconds(0.75f);

        GameObject t = Instantiate(tanghuru, transform.position, Quaternion.identity);
        t.GetComponent<Tanghuru>().Destroy(destroyTanghuruTime);
        t.transform.up = transform.up.normalized;
        StartCoroutine(Shot());

        yield break;
    }

    private IEnumerator Shot()
    {
        for (int i = 0; i < 30; i++)
        {
            transform.localEulerAngles = new Vector3(0, 0, zPlus ? transform.localEulerAngles.z + 1 : transform.localEulerAngles.z - 1);
            yield return new WaitForSeconds(0.005f);
        }

        while (gunSR.color.a > 0)
        {
            gunSR.color = new Color(1, 1, 1, gunSR.color.a - Time.deltaTime * 5);
        }

        Destroy(gameObject);

        yield break;
    }
}
