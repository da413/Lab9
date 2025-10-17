using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private int score;
    public TMP_Text scoreText;

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
        scoreText.text = $"Score: {score}";
    }
}
