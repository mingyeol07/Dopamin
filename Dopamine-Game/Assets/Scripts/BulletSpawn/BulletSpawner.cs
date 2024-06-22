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
    public float magneticLaserCool;
    public float slowMagneticLaserCool;

    [Header("Pedro")]
    public GameObject pedroBg;
    public GameObject pedroRacoon;
    public AudioClip pedroSound;

    private void Start()
    {
        StartCoroutine(PedroPattern());
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
        //Instantiate(magneticBg, Vector3.zero, Quaternion.identity);
        SoundManager.Instance.PlaySFX(magneticSound);

        yield return new WaitForSeconds(2);

        for (int i=0; i<8; i++)
        {
            Vector2 spawnPos = (Vector2)GameObject.FindGameObjectWithTag("Player").transform.position + new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
            GameObject laser = Instantiate(magneticLaser, spawnPos, Quaternion.identity);
            laser.transform.localEulerAngles = new Vector3(0, 0, Random.Range(0f, 360f));
            yield return new WaitForSeconds(magneticLaserCool);
        }

        yield return new WaitForSeconds(0.2f);
        Coroutine c = StartCoroutine(MagneticPlayer());
        yield return new WaitForSeconds(1.25f);
        StopCoroutine(c);

        for (int i = 0; i < 8; i++)
        {
            Vector2 spawnPos = (Vector2)GameObject.FindGameObjectWithTag("Player").transform.position + new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
            GameObject laser = Instantiate(magneticLaser, spawnPos, Quaternion.identity);
            laser.transform.localEulerAngles = new Vector3(0, 0, Random.Range(0f, 360f));
            yield return new WaitForSeconds(magneticLaserCool);
        }

        yield return new WaitForSeconds(0.2f);
        Coroutine c2 = StartCoroutine(MagneticPlayer());
        yield return new WaitForSeconds(1.5f);
        StopCoroutine(c2);

        for (int i = 0; i < 4; i++)
        {
            Vector2 spawnPos = (Vector2)GameObject.FindGameObjectWithTag("Player").transform.position + new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
            GameObject laser = Instantiate(magneticLaser, spawnPos, Quaternion.identity);
            laser.transform.localEulerAngles = new Vector3(0, 0, Random.Range(0f, 360f));
            yield return new WaitForSeconds(slowMagneticLaserCool);
        }

        yield return new WaitForSeconds(0.2f);
        Coroutine c3 = StartCoroutine(MagneticPlayer());
        yield return new WaitForSeconds(0.5f);
        StopCoroutine(c3);

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

    private IEnumerator PedroPattern()
    {
        GameObject pedroBg = Instantiate(this.pedroBg, Vector3.zero, Quaternion.identity);
        GameObject pedroRacoon = Instantiate(this.pedroRacoon, new Vector2(0, -7), Quaternion.identity);

        Destroy(pedroBg, pedroSound.length);
        Destroy(pedroRacoon, pedroSound.length);

        SoundManager.Instance.PlaySFX(pedroSound);

        while (pedroBg.transform.localScale.x > 6)
        {
            pedroBg.transform.localScale = new Vector2(pedroBg.transform.localScale.x - Time.deltaTime * 4, pedroBg.transform.localScale.y - Time.deltaTime * 4);
            yield return null;
        }

        yield break;
    }
}
