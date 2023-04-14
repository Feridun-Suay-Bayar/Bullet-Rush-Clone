using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject player;
    Vector3 distance;
    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    private void OnEnable()
    {
        try
        {
            transform.position = player.transform.position;
            distance = -transform.position + CharacterMovement.currentEnemy.transform.position;
            distance.y = 0.5f;
            distance = distance.normalized;
        }
        catch { }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(distance * 30 * Time.deltaTime);
        Invoke("Destroy", 2f);
    }
    public void Destroy()
    {
        if (gameObject.active)
        {
            gameObject.SetActive(false);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            other.GetComponent<EnemyMovement>().Dead();
        }
    }
}
