using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private GameObject weapon;

    [SerializeField]
    private Transform shootTransform;

    [SerializeField]
    private float shootInterval = 0.05f;
    private float lastShootTime = 0f;
    // private Vector3 pos;
    // private float maxXPosition = 2.5f;
    // private float maxYPosition = 4.2f;

    void Shoot()
    {
        if (Time.time - lastShootTime > shootInterval)
        {
            Instantiate(weapon, shootTransform.position, Quaternion.identity);
            lastShootTime = Time.time;
        }
    }
    
    void Update()
    {
        /* Keyboard */
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 moveTo = new Vector3(horizontalInput, verticalInput, 0f);
        transform.position += moveTo * moveSpeed * Time.deltaTime;

        /* Mouse */
        // Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
        // pos = transform.position;
        // pos.x = Mathf.Clamp(pos.x, -maxXPosition, maxXPosition);
        // pos.y = Mathf.Clamp(pos.y, -maxYPosition, maxYPosition);
        // transform.position = pos;

        /* Shoot Weapon */
        Shoot();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            GameManager.instance.IncreaseScore();
        }
    }

}
