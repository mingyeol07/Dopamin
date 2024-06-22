using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticLaser : MonoBehaviour
{
    public GameObject laserIndicator;
    public GameObject laser;
    public float laserActiveTime;

    private void Awake()
    {
        StartCoroutine(MagneticLaserCoroutine());
    }

    private IEnumerator MagneticLaserCoroutine()
    {
        yield return new WaitForSeconds(laserActiveTime);

        laserIndicator.SetActive(false);
        laser.SetActive(true);

        yield break;
    }
}
