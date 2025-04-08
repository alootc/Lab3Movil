using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public SpriteRenderer img_nave;
    public NaveData.NaveDTO nave_dto;

    [Header("Attributes")]
    public int health_current;
    public float speed;

    //Giroscopio
    private bool gyro_enabled;
    private Gyroscope gyro;

    private Rigidbody2D rb;
    
    private float delta_time = 0; 
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gyro_enabled = SystemInfo.supportsGyroscope; 
        if (gyro_enabled)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
        }
        else
        {
            Debug.Log(" NO hay giroscopio ");
        }

        nave_dto = GameManager.Instance.nave_dto;

        img_nave.sprite = nave_dto.imagen;
        health_current = nave_dto.health_max;
    }

    private void Update()
    {
        //if (!gyro_enabled) return;

        if(health_current > 0)
        {
            delta_time += Time.deltaTime;
            if (delta_time >= 1f)
            {
                GameManager.Instance.SetScore();
                delta_time = 0;
            }
        }
    }

    private void FixedUpdate()
    {
        if(gyro_enabled)
        {
            Vector3 tilt = gyro.rotationRateUnbiased;
            float move_x = tilt.x * nave_dto.move_speed;
            float move_y = tilt.y * nave_dto.move_speed;

            Vector2 movement = new Vector2(move_x, move_y) * speed;
            rb.velocity = movement; 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            health_current -= 10;
            if(health_current <= 0)
            {
                Destroy(this.gameObject);
                GameManager.Instance.GameOver();
            }
        }

    }
}
