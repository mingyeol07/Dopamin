using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    private int lastPlayedPattern;

    [Header("Magnetic")]
    public GameObject magneticBg;
    public AudioClip magneticSound;
    public GameObject magneticLaser;

    private void Awake()
    {
        StartCoroutine(MagneticPattern());
    }

    private void PlayPattern(bool first)
    {
        int index = 0;
        while (index != lastPlayedPattern)
        {
            index = Random.Range(0, 1);
        }

        switch (index)
        {
            case 0:
                StartCoroutine(MagneticPattern());
                break;
        }
    }

    private IEnumerator MagneticPattern()
    {
        yield return new WaitForSeconds(3);

        //Instantiate(magneticBg, Vector3.zero, Quaternion.identity);
        //SoundManager.Instance.PlaySFX(magneticSound);

        Coroutine c = StartCoroutine(MagneticPlayer());   
        yield return new WaitForSeconds(1.25f);
        StopCoroutine(c);

        yield break;
    }

    private IEnumerator MagneticPlayer()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        while (true)
        {
            player.Translate(Vector2.zero -  (Vector2)player.transform.position * Time.deltaTime);
            yield return null;
        }
    }
}
