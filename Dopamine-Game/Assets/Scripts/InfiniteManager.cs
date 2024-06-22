using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using System.Collections;

public class InfiniteManager : MonoBehaviour
{
    public static InfiniteManager Instance;

    public bool isGameClear { get; private set; }
    [SerializeField] private GameObject pnl_clear;

    [SerializeField] private Image timer;
    [SerializeField] private Button btn_menu;
    [SerializeField] private float maxTime;
    private float curTime;

    [SerializeField] private GameObject[] hpObjects;
    [SerializeField] private int maxHp;
    private int curHp;

    [SerializeField] private TMP_Text txt_timer;
    private float secend;

    [SerializeField] private GameObject item;

    private void Awake()
    {
        Instance = this;
        isGameClear = false;
        btn_menu.onClick.AddListener(() => SceneManager.LoadScene("Title"));
    }

    private void Start()
    {
        StartCoroutine(RandomItemSpawn());
        maxHp = hpObjects.Length;
        curHp = maxHp;
        curTime = maxTime;
    }

    private void Update()
    {
        if (!isGameClear) secend += Time.deltaTime;
        TimeSpan timeSpan = TimeSpan.FromSeconds(secend);
        txt_timer.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);


        curTime -= Time.deltaTime;
        if(curTime <= 0)
        {
            GameOver();
        }
        timer.fillAmount = curTime / maxTime;
    }

    public void PlusTimeItem()
    {
        curTime += 20;
        if(curTime > maxTime) { curTime = maxTime; }
    }

    public void HpDown()
    {
        if(curHp > 0)hpObjects[curHp - 1].gameObject.SetActive(false);

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
        txt_timer.transform.position = new Vector3(0, 0, 0);
        txt_timer.transform.localScale = new Vector3(2, 2, 2);
    }

    private IEnumerator RandomItemSpawn()
    {
        while (true)
        {
            float x = UnityEngine.Random.Range(-8f, 8);
            float y = UnityEngine.Random.Range(-4f, 4);

            GameObject go = Instantiate(item, new Vector2(x,y), Quaternion.identity);
            Destroy(go, 6f);

            yield return new WaitForSeconds(10f);
        }
    }
}
