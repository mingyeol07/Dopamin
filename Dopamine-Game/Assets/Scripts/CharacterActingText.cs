using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterActingText : MonoBehaviour
{
    public string[] actingText;
    public int actingNumber = 0;
    TextMeshPro TMP;

    void Start()
    {
        TMP = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        TMP.SetText(actingText[actingNumber]);
    }
}
