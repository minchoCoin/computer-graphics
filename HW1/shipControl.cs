using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipControl : MonoBehaviour
{
    public Transform ship; 
    public float moveSpeed = 1.0f;
    
    public float bulletSpeed = 10f;  // Speed of the bullet
    public Vector3 bulletScale = new Vector3(0.2f, 0.2f, 0.2f);  // Scale of the bullet
    public float bulletLifetime = 5f;  // How long the bullet exists before being destroyed
    // Start is called before the first frame update
    void Start()
    {
        if (ship == null)
        {
            ship = this.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // Move up
            movement += Vector3.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            // Move down
            movement += Vector3.down;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Move left
            movement += Vector3.left;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Move right
            movement += Vector3.right;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBullet();
        }
        if (movement != Vector3.zero)
        {
            transform.Translate(movement.normalized * moveSpeed * Time.deltaTime, Space.Self);
        }
    }
    void SpawnBullet()
    {
        // Create a sphere as the bullet at the current position and rotation
        GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        // Set the bullet's position to the current position of the spawner object
        bullet.transform.position = ship.transform.position;

        // Set the bullet's scale
        bullet.transform.localScale = bulletScale;

        bullet.transform.rotation = ship.rotation;
        
        
        // Add the Bullet component to handle movement
        bullet.AddComponent<Bullet>().SetSpeed(bulletSpeed);
        

        // Optionally add a Rigidbody for physics interaction (if needed)
        // Rigidbody rb = bullet.AddComponent<Rigidbody>();
        // rb.useGravity = false;

        // Destroy the bullet after a set time to avoid clutter in the scene
        Destroy(bullet, bulletLifetime);
    }
}
public class Bullet : MonoBehaviour
{
    private float speed;

    // Set the speed of the bullet
    public void SetSpeed(float bulletSpeed)
    {
        speed = bulletSpeed;
    }

    void Update()
    {
        // Move the bullet forward over time
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}