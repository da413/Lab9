using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuilder : MonoBehaviour
{
    public GameObject enemy;

    public void CreateNewEnemy()
    {
        enemy = new GameObject("Enemy");
        enemy.AddComponent<EnemyMovement>();
        enemy.AddComponent<SpriteRenderer>();
    }

    public void SetPosition(Vector2 position)
    {
        enemy.transform.position = position;
    }

    public void SetSpeed(float speed)
    {
        enemy.GetComponent<EnemyMovement>().moveSpeed = speed;
    }

    public void SetMoveRange(float range)
    {
        enemy.GetComponent<EnemyMovement>().moveRange = range;
    }

    public void SetSize(float scale)
    {
        enemy.transform.localScale = Vector3.one * scale;
    }

    public void SetSprite(Sprite sprite)
    {
        SpriteRenderer renderer = enemy.GetComponent<SpriteRenderer>();
        if (renderer != null)
        {
            renderer.sprite = sprite;
            renderer.sortingLayerName = "Enemy";
        }
    }
    
    public void AddCollider()
    {
        enemy.AddComponent<BoxCollider2D>();
        enemy.GetComponent<BoxCollider2D>().isTrigger = false;
        enemy.GetComponent<BoxCollider2D>().usedByComposite = false;
    }

    public void SetColor(Color color)
    {
        enemy.GetComponent<SpriteRenderer>().color = color;
    }
    
    public GameObject GetResult()
    {
        return enemy;
    }
}
