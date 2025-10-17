using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private int score;

    void Awake()
    {
        score = 0;
    }

    void OnEnable()
    {
        EnemyMovement.onEnemyDeath += AddtoScore;
    }

    void OnDisable()
    {
        EnemyMovement.onEnemyDeath -= AddtoScore;
    }

    void AddtoScore()
    {
        score++;
        Debug.Log(score);
    }
}
