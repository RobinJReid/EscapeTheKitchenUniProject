using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    //adapted from UNITY 3D SCHOOL ., 2021. Simple Shooting | 3D | Bullets | Unity Game Engine. [online video]. Nov 21. Available from: https://www.youtube.com/watch?v=EwiUomzehKU [Accessed 22 April 2024].
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    bool canShootBullet = true;
    public gameStateManager gameStateManager;

    private void Start()
    {
        GameObject gameStateObject = GameObject.Find("gameStateManager");
        gameStateManager = gameStateObject.GetComponent<gameStateManager>();
    }

    void Update()
    {
        if (!gameStateManager.isTeleporting)
        {
            if (canShootBullet)
            {
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
                canShootBullet = false;
                StartCoroutine(canShoot());
            }
        }
    }
        IEnumerator canShoot()
    {
        yield return new WaitForSecondsRealtime(5);
        canShootBullet = true;
        Debug.Log("Waited for 2 seconds in real time!");
    }
}
