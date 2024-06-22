using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingSceneButton : MonoBehaviour
{
    [SerializeField] private bool isReturnMenu;
    private void OnMouseDown()
    {
        if (isReturnMenu) SceneManager.LoadScene("Title");
        else SceneManager.LoadScene("StoryMode");
    }
}
