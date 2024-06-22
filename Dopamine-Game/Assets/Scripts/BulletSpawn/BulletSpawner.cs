using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    private int lastPlayedPattern;

    [Header("Magnetic")]
    [SerializeField] private GameObject magneticBg;
    [SerializeField] private GameObject magneticLaser;

    private void Awake()
    {

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
        Instantiate(magneticBg, Vector3.zero, Quaternion.identity);



        yield break;
    }
}
