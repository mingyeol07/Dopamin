using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public bool isGameClear { get; private set; }

    [Header("GameClear")]
    [SerializeField] private GameObject pnl_clear;

    [SerializeField] private GameObject[] hpObjects;
    [SerializeField] private int maxHp;
    private int curHp;


    [Header("Timer")]
    [SerializeField] private GameObject blueTimerPrefab;
    [SerializeField] private GameObject yellowTimerPrefab;
    [SerializeField] private Canvas canvas;
    [SerializeField] private int maxTime;
    [SerializeField] private float curTime;
    [SerializeField] private float timerSpeed;
    [SerializeField] private TMP_Text focusTime;
    [SerializeField] private TMP_Text dopamineTime;
    [SerializeField] private bool isTimeOver;
    private TMP_Text isTime;

    private Image gaugeImage;

    private void Awake()
    {
        Instance = this;
        maxHp = hpObjects.Length;
        curHp = maxHp;
    }

    private void Start()
    {
       
        SetYellowTimer();
    }

    private void Update()
    {
      //  isTime.text = curTime.ToString("n2");

        //lgaugeImage.fillAmount = curTime / maxTime;

        if (curTime < maxTime)
        {
            curTime += Time.deltaTime * timerSpeed;
        }
        else if (curTime >= maxTime && !isTimeOver)
        {
            isTimeOver = true;
            GameClear();
        }
    }

    public void TimeUp()
    {
        curTime += 20;
    }

    public void HpDown() {
        hpObjects[curHp].SetActive(false);

        curHp--;
        if (curHp == 0)
        {
            GameOver();
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

    private void GameClear()
    {
        pnl_clear.SetActive(true);
        isGameClear = true;

        canvas.transform.position = new Vector2(-2, 0);
        canvas.transform.localScale = new Vector2(2, 2);
    }

    private void GameOver()
    {

    }

    private void SetYellowTimer()
    {
        GameObject timer = Instantiate(yellowTimerPrefab, canvas.transform);
        timer.transform.SetAsFirstSibling();
        gaugeImage = timer.GetComponent<Image>();
        timerSpeed = 1;
    }

    private void SetBlueTimer()
    {
        GameObject timer = Instantiate(blueTimerPrefab, canvas.transform);
        timer.transform.SetAsFirstSibling();
        gaugeImage = timer.GetComponent<Image>();
        timerSpeed = 15;
    }
}
