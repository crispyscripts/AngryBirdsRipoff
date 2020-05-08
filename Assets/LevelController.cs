using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    private Enemy[] _enemies;

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var enemy in _enemies)
        {
            if (enemy != null) return;
        }

        var nextLevel = LevelTextUpdater._level + 1;

        if (nextLevel > SceneManager.sceneCountInBuildSettings)
        {
            nextLevel = 1;
        }

        string nextLevelName = "Level" + nextLevel.ToString();
        LoadLevel(nextLevelName);
        LevelTextUpdater._level = nextLevel;
    }

    public static void ResetScore()
    {
        //ScoreTextUpdater.score = initialScore;
    }

    void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
