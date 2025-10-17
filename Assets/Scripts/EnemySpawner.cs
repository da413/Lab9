using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public Sprite fastEnemySprite;
    public Sprite slowEnemySprite;
    public int numEnemies = 5;
    // Start is called before the first frame update
    void Start()
    {
        EnemyBuilder builder = new EnemyBuilder();
        EnemyDirector director = new EnemyDirector(builder);

        for (int i = 0; i < numEnemies; i++)
        {
            Vector3 position = new Vector3(0, Random.Range(-1f, 4f), -1);

            if (i % 2 == 0)
            {
                director.BuildFastEnemy(position, fastEnemySprite);
            }
            else
            {
                director.BuildSlowEnemy(position, slowEnemySprite);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
