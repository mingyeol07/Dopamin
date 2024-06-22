using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

public class InfiniteManager : MonoBehaviour
{
    public static InfiniteManager Instance;

    public bool isGameClear { get; private set; }
    [SerializeField] private GameObject pnl_clear;

    [SerializeField] private Image timer;
    [SerializeField] private float maxTime;
    private float curTime;

    [SerializeField] private GameObject[] hpObjects;
    [SerializeField] private int maxHp;
    private int curHp;

    [SerializeField] private TMP_Text txt_timer;
    private float minute;
    private float secend;

    private void Awake()
    {
        Instance = this;
        isGameClear = false;
    }

    private void Start()
    {
        maxHp = hpObjects.Length;
        curHp = maxHp;
        curTime = maxTime;
    }

    private void Update()
    {
        secend += Time.deltaTime;
        TimeSpan timeSpan = TimeSpan.FromSeconds(secend);
        txt_timer.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);


        curTime -= Time.deltaTime;
        timer.fillAmount = curTime / maxTime;
    }

    public void PlusTimeItem()
    {
        curTime += 20;
        if(curTime > maxTime) { curTime = maxTime; }
    }

    public void HpDown()
    {
        hpObjects[curHp - 1].gameObject.SetActive(false);

        curHp--;
        if (curHp == 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        isGameClear = true;
        pnl_clear.SetActive(true);
    }
}
