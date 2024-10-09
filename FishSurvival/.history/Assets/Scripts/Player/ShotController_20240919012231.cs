using System.Threading;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShotController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gunBarrel;
    public GameObject plazm;
    public GameObject statisticsPlayerUI;
    public GameObject inventoryWeaponUI;
    public float durationBackOffset = 0.02f;
    public float durationShowPlazm = 0.05f;
    public float bulletSpeed = 20f;
    public float shootInterval = 0.2f;
    public double shotDelayMillis = 1000d;
    public Transform bulletsFolder;
    private float lastShootTime;
    private Rigidbody2D rb;
    public GameObject weapon;
    private Vector3 originalScale;
    private StatisticsPlayer statisticsPlayer;
    private InventoryWeapon inventoryWeapon;
    private void Start()
    {
        lastShootTime = -shootInterval;
        rb = GetComponent<Rigidbody2D>();
        originalScale = gunBarrel.transform.localScale;
        statisticsPlayer = statisticsPlayerUI.GetComponent<StatisticsPlayer>();
        inventoryWeapon = inventoryWeaponUI.GetComponent<InventoryWeapon>();
    }
    void Update()
    {
        if (inventoryWeapon != null && inventoryWeapon.weaponSelected.bullet != null)
        {
            bullet = inventoryWeapon.weaponSelected.bullet;
        }
        if (Time.time - lastShootTime >= shootInterval)
        {
            if (Input.GetMouseButtonDown(0) && Input.mousePosition.y > 50f)
            {
                Attack();
                lastShootTime = Time.time;
            }

            if (Input.GetMouseButton(0) && Input.mousePosition.y > 50f)
            {
                Attack();
                lastShootTime = Time.time;
            }
        }
        onPressKey();
    }
    void onPressKey()
    {
        if (Input.GetKey(KeyCode.A))
        {
            inventoryWeapon.previousWeapon();
        }
        if (Input.GetKey(KeyCode.D))
        {
            inventoryWeapon.nextWeapon();
        }
    }

    void Attack()
    {
        if (inventoryWeapon.weaponSelected.lossAmount <= statisticsPlayer.totalCoin)
        {
            statisticsPlayer.UsingCoin(inventoryWeapon.weaponSelected.lossAmount);
            GameObject newBullet = Instantiate(bullet, weapon.transform.position, weapon.transform.rotation, bulletsFolder);
            newBullet.GetComponent<BulletRoot>().updateInfo(weapon, bulletSpeed);
            gunBarrel.transform.localScale = originalScale;
            plazm.SetActive(true);
            StartCoroutine(ShowPlazm());
            SkewAndRestore();
        }
    }

    private void SkewAndRestore()
    {
        Vector3 skewOffset = new Vector3(0f, 0.2f, 0f);
        Vector3 targetScale = new Vector3(originalScale.x, originalScale.y - skewOffset.y, originalScale.z);
        gunBarrel.transform.localScale = targetScale;
        StartCoroutine(ScaleTo(originalScale, durationBackOffset));
    }

    private IEnumerator ScaleTo(Vector3 target, float duration)
    {
        yield return new WaitForSeconds(duration);
        gunBarrel.transform.localScale = target;

    }
    private IEnumerator ShowPlazm()
    {
        plazm.SetActive(true);
        yield return new WaitForSeconds(durationShowPlazm);
        plazm.SetActive(false);
    }
}