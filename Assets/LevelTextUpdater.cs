using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTextUpdater : MonoBehaviour
{
    public Text textComponent;
    public static int _level = 1;

    void Start()
    {
        textComponent = GetComponent<Text>();
    }

    public void Update()
    {
        textComponent.text = _level.ToString();
    }
}
