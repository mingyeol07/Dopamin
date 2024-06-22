using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public bool isGameClear { get; private set; }

    [Header("GameClear")]
    [SerializeField] private GameObject pnl_clear;
    [SerializeField] private Button btn_clear;

    [Header("Timer")]
    [SerializeField] private GameObject blueTimerPrefab;
    [SerializeField] private GameObject yellowTimerPrefab;
    [SerializeField] private Canvas canvas;
    [SerializeField] private int maxTime;
    [SerializeField] private float curTime;
    [SerializeField] private float timerSpeed;

    [SerializeField] private TMP_Text txt_focusTime;
    [SerializeField] private TMP_Text txt_dopamineTime;
    private float focusTime;
    private float dopamineTime;
    private bool isTimeOver;
    private Image gaugeImage;
    private bool isFocusing;

    private void Awake()
    {
        Instance = this;

        DontDestroyOnLoad(gameObject);
        btn_clear.onClick.AddListener(() => PlayCutScene());
    }

    private void Start()
    {
        SetYellowTimer();
    }

    private void PlayCutScene()
    {
        SceneManager.LoadScene("Ending");
        int score = (int)((focusTime / maxTime) * 100);
        Debug.Log(score);
        Score.score = score;
    }

    private void Update()
    {
        if(!isGameClear)
        {
            if (isFocusing) focusTime += Time.deltaTime * timerSpeed;
            else dopamineTime += Time.deltaTime * timerSpeed;
        }

        gaugeImage.fillAmount = curTime / maxTime;

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

        canvas.transform.position = new Vector2(-4, 1);
        canvas.transform.localScale = new Vector2(2, 2);

        txt_focusTime.text = "집중한 시간 : " + focusTime.ToString("N2");
        txt_dopamineTime.text = "도파민에 절여진 시간 : " + dopamineTime.ToString("N2") ;
    }

    private void SetYellowTimer()
    {
        isFocusing = true;
        GameObject timer = Instantiate(yellowTimerPrefab, canvas.transform);
        timer.transform.SetAsFirstSibling();
        gaugeImage = timer.GetComponent<Image>();
        timerSpeed = 1;
    }

    private void SetBlueTimer()
    {
        isFocusing = false;
        GameObject timer = Instantiate(blueTimerPrefab, canvas.transform);
        timer.transform.SetAsFirstSibling();
        gaugeImage = timer.GetComponent<Image>();
        timerSpeed = 1;
    }
}
