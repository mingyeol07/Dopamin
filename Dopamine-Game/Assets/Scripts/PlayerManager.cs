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

    [SerializeField] private GameObject[] redBoxes;
    [SerializeField] private GameObject[] greenBoxes;
    [SerializeField] private int redBoxInt;
    [SerializeField] private int greenBoxInt;


    [Header("Timer")]
    [SerializeField] private GameObject blueTimerPrefab;
    [SerializeField] private GameObject yellowTimerPrefab;
    [SerializeField] private Canvas canvas;
    [SerializeField] private int maxTime;
    [SerializeField] private float curTime;
    [SerializeField] private float timerSpeed;
    [SerializeField] private TMP_Text focusTime;
    [SerializeField] private TMP_Text dopamineTime;
    private float blueTime;
    private float yellowTime;
    private bool isDamaged;
    private bool isTimeOver;

    private Image gaugeImage;

    private void Awake()
    {
        Instance = this;
        redBoxInt = 0;
        greenBoxInt = 0;
    }

    private void Start()
    {
        SetYellowTimer();
    }

    private void Update()
    {
        gaugeImage.fillAmount = curTime / maxTime;

        if (curTime < maxTime)
        {
            curTime += Time.deltaTime * timerSpeed;
            if (isDamaged)
            {
                blueTime += Time.deltaTime * timerSpeed; // curTime 대신 Time.deltaTime * timerSpeed 사용
            }
            else
            {
                yellowTime += Time.deltaTime * timerSpeed; // curTime 대신 Time.deltaTime * timerSpeed 사용
            }
        }
        else if (curTime >= maxTime && !isTimeOver)
        {

            GameClear();
        }
    }

    public void SetRedBox() {
        redBoxes[redBoxInt].SetActive(true);

        redBoxInt++;
        if (redBoxInt == redBoxes.Length)
        {
            ClearRedBox();
            redBoxInt = 0;
        }
    }

    public void SetGreenBox()
    {
        greenBoxes[greenBoxInt].SetActive(true);

        greenBoxInt++;
        if (greenBoxInt == greenBoxes.Length )
        {
            greenBoxInt = 0;
        }
    }
    
    private void ClearRedBox()
    {
        curTime += 5;
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
        focusTime.text = ((yellowTime / maxTime) * 100).ToString("F2") ; // 소수점 둘째 자리까지 표시
        dopamineTime.text = ((blueTime / maxTime) * 100).ToString("F2");
        canvas.transform.position = new Vector2(-2, 0);
        canvas.transform.localScale = new Vector2(2, 2);
    }

    private void SetYellowTimer()
    {
        isDamaged = false;

        GameObject timer = Instantiate(yellowTimerPrefab, canvas.transform);
        timer.transform.SetAsFirstSibling();
        gaugeImage = timer.GetComponent<Image>();
        timerSpeed = 1;
    }

    private void SetBlueTimer()
    {
        isDamaged = true;

        GameObject timer = Instantiate(blueTimerPrefab, canvas.transform);
        timer.transform.SetAsFirstSibling();
        gaugeImage = timer.GetComponent<Image>();
        timerSpeed = 15;
    }
}
