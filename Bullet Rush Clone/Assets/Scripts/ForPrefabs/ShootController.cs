 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public static bool canShoot;
    private float frameOfRate;
    GameObject temp;
    public SphereCollider colliderRange;
    private void Start()
    {
        StartCoroutine(Shoot());
    }
    private void Awake()
    {
        canShoot= false;
    }
    private void Update()
    {
        if (!canShoot)
        {
            StopCoroutine(Shoot());
            CharacterMovement.triggerExit = true;
        }
        if (temp != null && !temp.active)
        {
            canShoot = false;
        }
        frameOfRate = float.Parse(StatManager.Instance.frameOfRateText.text);
        colliderRange.radius = int.Parse(StatManager.Instance.rangeText.text);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            canShoot = true;
            temp = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            canShoot= false;
        }
    }
    IEnumerator Shoot()
    {
        while (true)
        {
            if (canShoot)
            {
                var obj = ObjectPooling.Instance.GetPooledObject(0);
            }
           
            yield return new WaitForSeconds(frameOfRate);
        }
    }
}
