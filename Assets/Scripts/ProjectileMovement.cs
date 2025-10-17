using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(Deactivate), lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);

        }
        Deactivate();
    }
    
    void Deactivate()
    {
        ObjectPooler.Instance.ReturnToPool(gameObject);
    }
}
