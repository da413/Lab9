using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class ScoreData
{
    public int score;

    public ScoreData()
    {
        score = ScoreKeeper.score;
    }
}
public class ScoreKeeper : MonoBehaviour
{

    public static int score = 0;
    public TMP_Text scoreText;
    //string saveID;
    //public string SaveID => saveID;


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

       // scoreText.text = $"Score: {score}";
    }
    
    void Update()
    {
       scoreText.text = $"Score: {score}";
    }
    /*
    public string SaveData()
    {
        return null;
    }
    public void LoadData(string data) 
    {
        Debug.Log("ahhh");
    }
    */

}
