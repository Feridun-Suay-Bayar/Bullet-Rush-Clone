using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {

            }
            return instance;
        }
    }
    public bool canPlayGame;
    private void Awake()
    {
        instance = this;
        canPlayGame = false;
    }

    public  void Dead()
    {
        UIManager.Instance.GameOver();
        StartCoroutine(BeginDead());
    }
    IEnumerator BeginDead()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
