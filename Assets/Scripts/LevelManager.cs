using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    private int _currentLevel = 100;
    private float _levelMaxDifficulty;
    private float _levelMinDifficulty;
    private int _currentScore=0;
    private int _desiredScore=0;
    [SerializeField] private float _difficultyMultiplier = 1.1f;
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
        _levelMinDifficulty = _currentLevel  * _difficultyMultiplier;
        _levelMaxDifficulty = _currentLevel * 2 * _difficultyMultiplier;
        return Random.Range((int)_levelMinDifficulty, (int)_levelMaxDifficulty);
    }

}
