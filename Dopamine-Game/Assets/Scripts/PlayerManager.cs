using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    [SerializeField] private GameObject blueTimerPrefab;
    [SerializeField] private GameObject yellowTimerPrefab;
    [SerializeField] private int maxTime;
    [SerializeField] private float curTime;
    [SerializeField] private Canvas canvas;
    [SerializeField] private float timerSpeed;
    private Image mainTimer;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetYellowTimer();
    }

    private void Update()
    {
        mainTimer.fillAmount = curTime / maxTime;

        if (curTime < maxTime)
        {
            curTime += Time.deltaTime * timerSpeed;
        }
    }

    public void PlayerDamaged()
    {
        StartCoroutine(Damaged());
    }

    private IEnumerator Damaged()
    {
        SetBlueTimer();
        yield return new WaitForSeconds(1f);
        SetYellowTimer();
    }

    private void SetYellowTimer()
    {
        GameObject timer = Instantiate(yellowTimerPrefab, canvas.transform);
        timer.transform.SetAsFirstSibling();
        mainTimer = timer.GetComponent<Image>();
        timerSpeed = 1;
    }

    private void SetBlueTimer()
    {
        GameObject timer = Instantiate(blueTimerPrefab, canvas.transform);
        timer.transform.SetAsFirstSibling();
        mainTimer = timer.GetComponent<Image>();
        timerSpeed = 5;
    }
}
