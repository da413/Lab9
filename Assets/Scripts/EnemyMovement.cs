using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public delegate void OnEnemyDeath();
    public static event OnEnemyDeath onEnemyDeath;
    public float moveSpeed = 2f;
    public float moveRange = 2f;
    private Vector3 startPos;
    private float previousOffsetX;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position + new Vector3(0, 0, -1);
        previousOffsetX = Mathf.Sin(Time.time * moveSpeed) * moveRange;

        this.tag = "Enemy";
    }

    // Update is called once per frame
    void Update()
    {
        float currentOffsetX = Mathf.Sin(Time.time * moveSpeed) * moveRange;

        float delta = currentOffsetX - previousOffsetX;
        
        transform.position += new Vector3(delta, 0, 0);

        previousOffsetX = currentOffsetX;

        /*
        Vector3 offset = new Vector3(Mathf.Sin(Time.time * moveSpeed) * moveRange, 0 , 0);
        transform.position += startPos + new Vector3();
        transform.position = new Vector3(startPos.x + offset, startPos.y, startPos.z);
        */
    }

    void OnDestroy()
    {
        onEnemyDeath?.Invoke();
    }
}
