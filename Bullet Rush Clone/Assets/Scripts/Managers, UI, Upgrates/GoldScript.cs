using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldScript : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = ""+StatManager.Instance.goldText.text;
    }
}
