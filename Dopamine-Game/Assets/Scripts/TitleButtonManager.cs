using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleButtonManager : MonoBehaviour
{
    [SerializeField] private Button btn_gameEixt;
    [SerializeField] private Button btn_selectGameMode;
    [SerializeField] private Button btn_selectGameModeExit;
    [SerializeField] private Button btn_setting;
    [SerializeField] private Button btn_playInfinite;
    [SerializeField] private Button btn_playStory;

    [SerializeField] private Animator canvasAnimator;
    
    private void Awake()
    {
        btn_selectGameMode.onClick.AddListener(() => {SelectGaemMode();});
        btn_setting.onClick.AddListener(() => Settings());
        btn_gameEixt.onClick.AddListener(() => { GameEixt();});
        btn_playInfinite.onClick.AddListener(() => { PlayInfinite();});
        btn_playStory.onClick.AddListener(() => { PlayStoryMode();});
        btn_selectGameModeExit.onClick.AddListener(() => { GameModeBackButton();});
    }

    private void GameModeBackButton()
    {
        canvasAnimator.SetBool("SelectGameMode", false);
    }

    private void PlayStoryMode()
    {
        SceneManager.LoadScene("StoryMode");
    }

    private void PlayInfinite()
    {
        SceneManager.LoadScene("InfiniteMode");
    }

    private void SelectGaemMode()
    {
        canvasAnimator.SetBool("SelectGameMode", true);
    }

    private void Settings()
    {
        canvasAnimator.SetTrigger("Setting");
    }

    private void GameEixt()
    {
        Application.Quit();
    }
}
