using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    [Header("Life")]
    [SerializeField] private GameObject[] lifeObjects;
    private int playerLife;
    
    [Header("Timer")]
    [SerializeField] private GameObject blueTimerPrefab;
    [SerializeField] private GameObject yellowTimerPrefab;
    [SerializeField] private Canvas canvas;
    [SerializeField] private int maxTime;
    [SerializeField] private float curTime;
    [SerializeField] private float timerSpeed;
    private Image mainTimer;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playerLife = lifeObjects.Length;
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
        LifeDown();
        StartCoroutine(Damaged());
    }

    private void LifeDown()
    {
        playerLife--;
        if(playerLife < 0 )
        {

        }
        else
        {
            lifeObjects[playerLife].SetActive(false);
        }
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
