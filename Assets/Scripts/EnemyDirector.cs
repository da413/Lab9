using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDirector : MonoBehaviour
{
    private EnemyBuilder builder;

    public EnemyDirector(EnemyBuilder builder)
    {
        this.builder = builder;
    }

    public GameObject BuildFastEnemy(Vector2 position, Sprite sprite)
    {
        builder.CreateNewEnemy();
        builder.SetPosition(position);
        builder.SetSpeed(Random.Range(4f, 6f));
        builder.SetSize(1f);
        builder.SetSprite(sprite);
        builder.AddCollider();
        builder.SetColor(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
        return builder.GetResult();
    }

    public GameObject BuildSlowEnemy(Vector2 position, Sprite sprite)
    {
        builder.CreateNewEnemy();
        builder.SetPosition(position);
        builder.SetSpeed(Random.Range(1f, 2f));
        builder.SetSize(2f);
        builder.SetSprite(sprite);
        builder.AddCollider();
        builder.SetColor(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
        return builder.GetResult();
    }
}
