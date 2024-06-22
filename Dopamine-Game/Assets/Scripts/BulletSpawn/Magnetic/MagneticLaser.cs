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

        while (laser.transform.localScale.x < 0.75f)
        {
            laser.transform.localScale = new Vector3(laser.transform.localScale.x + Time.deltaTime * 3.5f, 50, 1);
            yield return null;
        }
        while (laser.transform.localScale.x > 0)
        {
            laser.transform.localScale = new Vector3(laser.transform.localScale.x - Time.deltaTime * 4.5f, 50, 1);
            yield return null;
        }

        Destroy(gameObject);

        yield break;
    }
}
