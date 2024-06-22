using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshPro scoreText;
    public TextMeshPro endingText;
    public TextMeshPro lowerEndingText;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreText != null)
        {
            scoreText.SetText(score.ToString());
        }

        if (endingText != null)
        {
            if (score <= 20)
            {
                endingText.SetText("너 나가");
                lowerEndingText.SetText("아싸 나가서 봐야지");
            }
            else if (score <= 50)
            {
                endingText.SetText("얼른 자라");
                lowerEndingText.SetText("좀만 더 보다 잘까?");
            }
            else if (score <= 70)
            {
                endingText.SetText("수고했어");
                lowerEndingText.SetText("좀 더 열심히 할 걸..");
            }
            else if (score <= 99)
            {

                endingText.SetText("잘했어");
                lowerEndingText.SetText("휴 다행이다..");
            }
            else
            {
                endingText.SetText("역시 내 자식!");
                lowerEndingText.SetText("엄마가 플스 사줄게");
            }
        }    
    }
}
