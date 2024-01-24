using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dessert : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3f;

    private float minY = -7;

    [SerializeField]
    private float hp = 1f;

    [SerializeField]
    private int level = 1;

    [SerializeField]
    private GameObject Coin;

    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            hp -= 1;
            Destroy(other.gameObject);
            if (hp <= 0)
            {
                Destroy(gameObject);
                for (int i = 0; i < level; i++)
                {
                    Instantiate(Coin, transform.position, Quaternion.identity);
                }
            }
        }
        else if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            GameManager.instance.SetGameOver();
        }
    }
}

