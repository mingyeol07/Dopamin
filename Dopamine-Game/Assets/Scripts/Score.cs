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
                endingText.SetText("�� ����");
                lowerEndingText.SetText("�ƽ� ������ ������");
            }
            else if (score <= 50)
            {
                endingText.SetText("�� �ڶ�");
                lowerEndingText.SetText("���� �� ���� �߱�?");
            }
            else if (score <= 70)
            {
                endingText.SetText("�����߾�");
                lowerEndingText.SetText("�� �� ������ �� ��..");
            }
            else if (score <= 99)
            {

                endingText.SetText("���߾�");
                lowerEndingText.SetText("�� �����̴�..");
            }
            else
            {
                endingText.SetText("���� �� �ڽ�!");
                lowerEndingText.SetText("������ �ý� ���ٰ�");
            }
        }    
    }
}
