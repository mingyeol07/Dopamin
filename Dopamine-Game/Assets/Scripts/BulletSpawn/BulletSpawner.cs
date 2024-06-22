using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    private int lastPlayedPattern;

    [Header("Magnetic")]
    public GameObject magneticHorseking;
    public AudioClip magneticSound;
    public GameObject magneticLaser;
    public float magneticLaserCool;
    public float slowMagneticLaserCool;

    [Header("Pedro")]
    public GameObject pedroBg;
    public GameObject pedroRacoon;
    public AudioClip pedroSound;

    [Header("Tanghuru")]
    public GameObject tanghuruGun1;
    public GameObject tanghuruGun2;
    public GameObject tanghuruGun3;
    public AudioClip tanghuruSound;

    [Header("Slick Back")]
    public GameObject slickBack;
    public AudioClip slickBackSound;

    [Header("AK47")]
    public GameObject AK47;
    public AudioClip AK47Sound;
    public GameObject grandma;
    public GameObject tomb;
    public GameObject tomb2;

    private void Start()
    {
        StartCoroutine(PlayPattern(true));
    }

    private IEnumerator PlayPattern(bool first)
    {
        int index = 0;
        if (first) index = Random.Range(0, 5);
        else
        {
            index = Random.Range(0, 5);
            while (index == lastPlayedPattern)
            {
                index = Random.Range(0, 5);
            }
        }

        switch (index)
        {
            case 0:
                StartCoroutine(MagneticPattern());
                break;
            case 1:
                StartCoroutine(PedroPattern());
                break;
            case 2:
                StartCoroutine(TanghuruPattern());
                break;
            case 3:
                StartCoroutine(SlickBackPattern());
                break;
            case 4:
                StartCoroutine(AK47Pattern());
                break;
        }

        lastPlayedPattern = index;

        yield break;
    }

    private IEnumerator MagneticPattern()
    {
        //Instantiate(magneticBg, Vector3.zero, Quaternion.identity);
        SoundManager.Instance.PlaySFX(magneticSound);

        yield return new WaitForSeconds(2);

        for (int i=0; i<8; i++)
        {
            Vector2 spawnPos = (Vector2)GameObject.FindGameObjectWithTag("Player").transform.position;
            GameObject laser = Instantiate(magneticLaser, spawnPos, Quaternion.identity);
            laser.transform.localEulerAngles = new Vector3(0, 0, Random.Range(0f, 360f));
            yield return new WaitForSeconds(magneticLaserCool);
        }

        yield return new WaitForSeconds(0.2f);
        Destroy(Instantiate(magneticHorseking, new Vector2(7, 0), Quaternion.identity), 1.25f);
        Coroutine c = StartCoroutine(MagneticPlayer(new Vector2(7,0)));
        yield return new WaitForSeconds(1.25f);
        StopCoroutine(c);

        for (int i = 0; i < 8; i++)
        {
            Vector2 spawnPos = (Vector2)GameObject.FindGameObjectWithTag("Player").transform.position;
            GameObject laser = Instantiate(magneticLaser, spawnPos, Quaternion.identity);
            laser.transform.localEulerAngles = new Vector3(0, 0, Random.Range(0f, 360f));
            yield return new WaitForSeconds(magneticLaserCool);
        }

        yield return new WaitForSeconds(0.2f);
        GameObject g = Instantiate(magneticHorseking, new Vector2(-7, 0), Quaternion.identity);
        g.transform.localEulerAngles = new Vector3(0, -180, 0);
        Destroy(g, 1.5f);
        Coroutine c2 = StartCoroutine(MagneticPlayer(new Vector2(-7, 0)));
        yield return new WaitForSeconds(1.5f);
        StopCoroutine(c2);

        for (int i = 0; i < 4; i++)
        {
            Vector2 spawnPos = (Vector2)GameObject.FindGameObjectWithTag("Player").transform.position;
            GameObject laser = Instantiate(magneticLaser, spawnPos, Quaternion.identity);
            laser.transform.localEulerAngles = new Vector3(0, 0, Random.Range(0f, 360f));
            yield return new WaitForSeconds(slowMagneticLaserCool);
        }

        yield return new WaitForSeconds(0.2f);
        Destroy(Instantiate(magneticHorseking, new Vector2(7, 0), Quaternion.identity), 0.5f);
        Coroutine c3 = StartCoroutine(MagneticPlayer(new Vector2(7, 0)));
        yield return new WaitForSeconds(0.5f);
        StopCoroutine(c3);

        yield return new WaitForSeconds(2.5f);
        StartCoroutine(PlayPattern(false));

        yield break;
    }
    private IEnumerator MagneticPlayer(Vector2 pos)
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        while (true)
        {
            player.Translate((pos -  (Vector2)player.transform.position).normalized * Time.deltaTime * 3);
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

        yield return new WaitForSeconds(1.5f);

        pedroBg.GetComponent<PedroBg>().Move();

        pedroRacoon.transform.parent = pedroBg.transform;

        yield return new WaitForSeconds(15);
        StartCoroutine(PlayPattern(false));

        yield break;
    }

    private IEnumerator TanghuruPattern()
    {
        SoundManager.Instance.PlaySFX(tanghuruSound);

        yield return new WaitForSeconds(4f);

        Vector2 tg1Pos = new Vector2(-7, Random.Range(-3.5f, 3.5f));
        Instantiate(tanghuruGun1, tg1Pos, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Vector2 tg2Pos = new Vector2(7, Random.Range(-3.5f, 3.5f));
        Instantiate(tanghuruGun2, tg2Pos, Quaternion.identity);

        yield return new WaitForSeconds(1.7f);

        tg1Pos = new Vector2(-7, Random.Range(-3.5f, 3.5f));
        Instantiate(tanghuruGun1, tg1Pos, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        tg2Pos = new Vector2(7, Random.Range(-3.5f, 3.5f));
        Instantiate(tanghuruGun3, tg2Pos, Quaternion.identity);

        yield return new WaitForSeconds(1.9f);

        tg1Pos = new Vector2(-7, Random.Range(-3.5f, 3.5f));
        Instantiate(tanghuruGun1, tg1Pos, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        tg1Pos = new Vector2(7, Random.Range(-3.5f, 3.5f));
        Instantiate(tanghuruGun2, tg2Pos, Quaternion.identity);

        yield return new WaitForSeconds(5.5f);
        StartCoroutine(PlayPattern(false));

        yield break;
    }

    private IEnumerator SlickBackPattern()
    {
        SoundManager.Instance.PlaySFX(slickBackSound);

        yield return new WaitForSeconds(4.5f);

        Instantiate(slickBack, new Vector2(10, Random.Range(-3f, 3f)), Quaternion.identity);
        Instantiate(slickBack, new Vector2(-10, Random.Range(-3f, 3f)), Quaternion.identity);

        yield return new WaitForSeconds(7.5f);
        StartCoroutine(PlayPattern(false));

        yield break;
    }

    private IEnumerator AK47Pattern()
    {
        SoundManager.Instance.PlaySFX(AK47Sound);

        yield return new WaitForSeconds(1);

        Instantiate(AK47, new Vector2(12, 0), Quaternion.identity);

        yield return new WaitForSeconds(2f);

        Instantiate(grandma, new Vector2(-15, 0), Quaternion.identity);

        yield return new WaitForSeconds(4.15f);

        Tomb t1 = Instantiate(tomb, new Vector2(-6, -7), Quaternion.identity).GetComponent<Tomb>();
        yield return new WaitForSeconds(0.3f);
        Tomb t2 = Instantiate(tomb2, new Vector2(6, -7), Quaternion.identity).GetComponent<Tomb>();

        yield return new WaitForSeconds(1f);

        t1.isStop = false;
        t2.isStop = false;

        yield return new WaitForSeconds(4.5f);
        StartCoroutine(PlayPattern(false));

        yield break;
    }
}
