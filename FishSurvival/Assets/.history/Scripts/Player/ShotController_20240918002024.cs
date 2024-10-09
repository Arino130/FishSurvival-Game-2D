using System.Threading;
using UnityEngine;
using System.Collections;

public class ShotController : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpeed = 20f;
    public float shootInterval = 0.2f;
    public double shotDelayMillis = 1000d;
    public Transform bulletsFolder;
    private float lastShootTime;
    private Rigidbody2D rb;
    public GameObject weapon;

    private void Start()
    {
        lastShootTime = -shootInterval;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Time.time - lastShootTime >= shootInterval)
        {
            if (Input.GetMouseButtonDown(0) && Input.mousePosition.y > 50f)
            {
                Attack();
                lastShootTime = Time.time;
            }
        }
    }

    void Attack()
    {
        GameObject newBullet = Instantiate(bullet, weapon.transform.position, weapon.transform.rotation, bulletsFolder);
        newBullet.GetComponent<BulletRoot>().updateInfo(weapon, bulletSpeed);
    }
}