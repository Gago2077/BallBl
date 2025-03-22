using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    private uint _currentLevel = 1;
    private int _levelMaxDifficulty;
    private int _levelMinDifficulty;
    private int _currentScore=0;
    private int _desiredScore=0;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public int GetHealth()
    {
        _levelMinDifficulty = (int)_currentLevel * 10;
        _levelMaxDifficulty = (int)_currentLevel * 20;
        return Random.Range(_levelMinDifficulty, _levelMaxDifficulty);
    }

}
