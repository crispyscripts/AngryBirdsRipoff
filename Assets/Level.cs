using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public Text textComponent;

    // Start is called before the first frame update
    void Start()
    {
        //textComponent = GetComponent<Text>();
    }

    public void UpdateText(string text)
    {
        textComponent.text = text;
    }
}
