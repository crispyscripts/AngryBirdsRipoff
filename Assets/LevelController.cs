using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public static int _score = 0;
    public static int _level = 1;
    private Enemy[] _enemies;
    Text _levelText;
    Text _scoreText;

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
        UpdateLevelText();
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreText();
        UpdateLevelText();

        foreach (var enemy in _enemies)
        {
            if (enemy != null) return;
        }

        _level++;
        string nextLevelName = "Level" + _level;
        SceneManager.LoadScene(nextLevelName);
    }

    void UpdateLevelText()
    {
        var textComponent = GetComponent<Level>();

        if (textComponent != null)
        {
            textComponent.UpdateText(_level.ToString());
        }
    }

    void UpdateScoreText()
    {
        var textComponent = GetComponent<Score>();

        if (textComponent != null)
        {
            textComponent.UpdateText(_score.ToString());
        }
    }
}
