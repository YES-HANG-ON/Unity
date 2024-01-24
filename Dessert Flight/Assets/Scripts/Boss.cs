using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f;

    [SerializeField]
    private float hp = 25;

    [SerializeField]
    private GameObject Coin;

    private float level = 20;
    private float minY = -7;

    // Update is called once per frame
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
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            GameManager.instance.SetGameOver();
        }
        else if (other.gameObject.tag == "Weapon")
        {
            Destroy(other.gameObject);
            hp--;
            if (hp <= 0)
            {
                Destroy(gameObject);
                for (int i = 0; i < level; i++)
                {
                    Instantiate(Coin, transform.position, Quaternion.identity);
                }
            }
        }
    }
}
