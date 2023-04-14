using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : Movement, IDead
{
    Vector3 direction;
    Vector3 lookRotation;
    public static GameObject currentEnemy;
    public static bool triggerExit;
    private void Start()
    {
        
    }
    private void Awake()
    {
        triggerExit = true;
        currentEnemy = gameObject;
    }
    private void Update()
    {
        movementSpeed = int.Parse(StatManager.Instance.playerSpeedText.text);
    }
    private void FixedUpdate()
    {
        if (GameManager.Instance.canPlayGame)
        {
            movementSpeed = int.Parse(StatManager.Instance.playerSpeedText.text);
            direction = new Vector3(ScreenTouchController.direction.x, 0, ScreenTouchController.direction.y);
            lookRotation = direction;
            Move(direction);
            if (triggerExit)
            {
                transform.LookAt(lookRotation * 360);
            }
        }
        else
        {
            movementSpeed = 0;
            direction = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Dead();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            transform.LookAt(other.gameObject.transform);
            currentEnemy = other.gameObject;
            triggerExit = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            transform.LookAt(other.gameObject.transform);
            currentEnemy = other.gameObject;
            triggerExit = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            triggerExit = true;
        }
    }
    public void Dead()
    {
        movementSpeed = 0;
        GameManager.Instance.Dead();
    }
}

