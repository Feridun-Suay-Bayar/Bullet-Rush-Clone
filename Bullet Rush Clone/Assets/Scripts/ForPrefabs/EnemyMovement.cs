using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Movement, IDead
{
    Vector3 direction;
    GameObject player;
    public bool target;

    private void Start()
    {
       player = GameObject.Find("Player").gameObject;
    }
    private void FixedUpdate()
    {
        direction = player.transform.position - transform.position;
        direction = direction.normalized;
        Move(direction);
        transform.LookAt(player.transform);
    }
    public void Dead()
    {
        StatManager.Instance.goldText.text = "" + (int.Parse(StatManager.Instance.goldText.text)+25);
        PlayerPrefs.SetInt("gold", int.Parse(StatManager.Instance.goldText.text));
        gameObject.SetActive(false);
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        ShootController.canShoot = true;
    //    }
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        ShootController.canShoot = false;
    //    }
    //}
}
