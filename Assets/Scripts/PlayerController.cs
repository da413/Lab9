using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour, IJsonSaveable
{
    public float speed = 5f;
    public string SaveID => throw new System.NotImplementedException();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0);
        
        transform.Translate(movement.normalized * speed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            ShootProjectile();
        }
    }

    private void ShootProjectile()
    {
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPos = transform.position;
        Vector2 shootingDirection = (mouseWorldPos - playerPos).normalized;
        float angle = (float)(Mathf.Atan2(-shootingDirection.x, shootingDirection.y) * Mathf.Rad2Deg);
        Quaternion rotation = Quaternion.Euler(0f, 0f, angle);

        GameObject projectile = ObjectPooler.Instance.SpawnFromPool("Projectile", transform.position, rotation);
    }

  public string SaveData()
  {
    throw new System.NotImplementedException();
  }

  public void LoadData(string data)
  {
    throw new System.NotImplementedException();
  }
}
