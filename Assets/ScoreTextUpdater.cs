using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextUpdater : MonoBehaviour
{
    public Text textComponent;
    public static int score = 0;

    void Start()
    {
        textComponent = GetComponent<Text>();
    }

    public void Update()
    {
        textComponent.text = score.ToString();
    }
}
