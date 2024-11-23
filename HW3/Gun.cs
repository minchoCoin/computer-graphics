using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    float bulletSpeed = 5f;
    [SerializeField]
    float bulletLifeTime = 5f;

    [SerializeField]
    public Vector3 bulletScale = new Vector3 (0.2f, 0.2f, 0.2f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBullet();
        }
    }
    void SpawnBullet()
    {
        GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        bullet.transform.position =this.transform.position;
        bullet.transform.localScale = bulletScale;
        bullet.AddComponent<Bullet>().setSpeed(bulletSpeed);
        SphereCollider sc = bullet.GetComponent<SphereCollider>();
        sc.isTrigger = true;
        sc.radius = bulletScale.x;

        Destroy(bullet,bulletLifeTime);
    }
}

public class Bullet:MonoBehaviour
{
    private float speed;
    public void setSpeed(float bulletSpeed)
    {
        this.speed = bulletSpeed;
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider collision)
    {
        GameObject hitObject = collision.gameObject;
        Debug.Log("hit object!");

        Destroy(hitObject);
        Destroy(this.gameObject);
    }

}
