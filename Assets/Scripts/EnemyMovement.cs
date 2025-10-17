using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public delegate void OnEnemyDeath();
    public static event OnEnemyDeath onEnemyDeath;
    public float moveSpeed = 2f;
    public float moveRange = 2f;
    private Vector2 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        this.tag = "Enemy";
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Mathf.Sin(Time.time * moveSpeed) * moveRange;
        transform.position = new Vector3(startPos.x + offset, startPos.y, -1);
    }

    void OnDestroy()
    {
        onEnemyDeath?.Invoke();
    }
}
