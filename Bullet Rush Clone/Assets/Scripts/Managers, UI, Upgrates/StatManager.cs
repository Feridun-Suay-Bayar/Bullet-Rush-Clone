using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    private static StatManager instance;
    public static StatManager Instance
    {
        get
        {
            if (instance == null)
            {

            }
            return instance;
        }
    }

    public TextMeshProUGUI goldText;

    public TextMeshProUGUI frameOfRateText;
    public Button frameOfRate;
    public TextMeshProUGUI frameOfRateButtonText;

    public TextMeshProUGUI rangeText;
    public Button range;
    public TextMeshProUGUI rangeButtonText;

    public TextMeshProUGUI playerSpeedText;
    public Button playerSpeed;
    public TextMeshProUGUI playerSpeedButtonText;

    int goldPREF;
    float frameOfRatePREF;
    int frameCostPREF;
    float rangePREF;
    int rangeCostPREF;
    int speedPREF;
    int speedCostPREF;
    private void Awake()
    {
        instance = this;

        goldText.text = "" + GoldPref(goldPREF);
        frameOfRateText.text = "" + FrameOfRatePref(frameOfRatePREF);
        frameOfRateButtonText.text = ""+FrameCostPREF(frameCostPREF);
        rangeText.text = ""+RangePref(rangePREF);
        rangeButtonText.text = ""+RangeCostPREF(rangeCostPREF);
        playerSpeedText.text = ""+ SpeedPref(speedPREF);
        playerSpeedButtonText.text = ""+SpeedCostPREF(speedCostPREF);

        if (int.Parse(frameOfRateButtonText.text) == 2250)
        {
            frameOfRateButtonText.text = "FULL";
            frameOfRate.interactable = false;
        }
        if (int.Parse(rangeButtonText.text) == 2250)
        {
            rangeButtonText.text = "FULL";
            range.interactable = false;
        }
        if (int.Parse(playerSpeedButtonText.text) == 2250)
        {
            playerSpeedButtonText.text = "FULL";
            playerSpeed.interactable = false;
        }
    }
    public void UpgrateFrameOfRate()
    {
        if (int.Parse(goldText.text) >= int.Parse(frameOfRateButtonText.text) && int.Parse(goldText.text) >= 0 && int.Parse(frameOfRateButtonText.text)!=2250)
        {
            float var = float.Parse(frameOfRateText.text);
            var -= 0.05f;
            frameOfRateText.text = "" + var;
            goldText.text = "" + ((int.Parse(goldText.text) - int.Parse(frameOfRateButtonText.text)));
            frameOfRateButtonText.text = "" + (int.Parse(frameOfRateButtonText.text) + 250);

            PlayerPrefs.SetInt("gold", int.Parse(goldText.text));
            PlayerPrefs.SetFloat("rate", float.Parse(frameOfRateText.text));
            PlayerPrefs.SetInt("framecost", int.Parse(frameOfRateButtonText.text));
        }
        if (int.Parse(frameOfRateButtonText.text) == 2250)
        {
            frameOfRateButtonText.text = "FULL";
            frameOfRate.interactable = false;
        }
    }
    public void UpgrateRange()
    {
        if (int.Parse(goldText.text) >= int.Parse(rangeButtonText.text) && int.Parse(goldText.text) >= 0 && int.Parse(rangeButtonText.text) != 2250)
        {
            int var = int.Parse(rangeText.text);
            var++;
            rangeText.text = "" + var;
            goldText.text = "" + (int.Parse(goldText.text) - int.Parse(rangeButtonText.text));
            rangeButtonText.text = "" + (int.Parse(rangeButtonText.text) + 250);

            PlayerPrefs.SetInt("gold", int.Parse(goldText.text));
            PlayerPrefs.SetFloat("range", float.Parse(rangeText.text));
            PlayerPrefs.SetInt("rangecost", int.Parse(rangeButtonText.text));
        }
        if (int.Parse(rangeButtonText.text) == 2250)
        {
            rangeButtonText.text = "FULL";
            range.interactable = false;
        }
    }
    public void UpgrateSpeed()
    {
        if (int.Parse(goldText.text) >= int.Parse(playerSpeedButtonText.text) && int.Parse(goldText.text) >= 0 && int.Parse(playerSpeedButtonText.text) != 2250)
        {
            int var = int.Parse(playerSpeedText.text);
            var +=10;
            playerSpeedText.text = "" + var;
            goldText.text = "" + (int.Parse(goldText.text) - int.Parse(playerSpeedButtonText.text));
            playerSpeedButtonText.text = "" + (int.Parse(playerSpeedButtonText.text) + 250);

            PlayerPrefs.SetInt("gold", int.Parse(goldText.text));
            PlayerPrefs.SetInt("speed", int.Parse(playerSpeedText.text));
            PlayerPrefs.SetInt("speedcost", int.Parse(playerSpeedButtonText.text));
        }
        if (int.Parse(playerSpeedButtonText.text) == 2250)
        {
            playerSpeedButtonText.text = "FULL";
            playerSpeed.interactable = false;
        }
    }

    int GoldPref(int _goldPREF)
    {
        if (!PlayerPrefs.HasKey("gold"))
        {
            PlayerPrefs.SetInt("gold", 10000);
        }
        goldPREF = PlayerPrefs.GetInt("gold");
        return goldPREF;
    }
    float FrameOfRatePref(float _frameOfRatePREF)
    {
        if (!PlayerPrefs.HasKey("rate"))
        {
            PlayerPrefs.SetFloat("rate", 0.5f);
        }
        frameOfRatePREF = PlayerPrefs.GetFloat("rate");
        return frameOfRatePREF;
    }
    int FrameCostPREF(int _frameCostPREF)
    {
        if (!PlayerPrefs.HasKey("framecost"))
        {
            PlayerPrefs.SetInt("framecost", 1000);
        }
        frameCostPREF = PlayerPrefs.GetInt("framecost");
        return frameCostPREF;
    }
    float RangePref(float _rangePREF)
    {
        if (!PlayerPrefs.HasKey("range"))
        {
            PlayerPrefs.SetFloat("range", 5);
        }
        rangePREF = PlayerPrefs.GetFloat("range");
        return rangePREF;
    }
    int RangeCostPREF(int _rangeCostPREF)
    {
        if (!PlayerPrefs.HasKey("rangecost"))
        {
            PlayerPrefs.SetInt("rangecost", 1000);
        }
        rangeCostPREF = PlayerPrefs.GetInt("rangecost");
        return rangeCostPREF;
    }
    int SpeedPref(int _speedPREF)
    {
        if (!PlayerPrefs.HasKey("speed"))
        {
            PlayerPrefs.SetInt("speed", 250);
        }
        speedPREF = PlayerPrefs.GetInt("speed");
        return speedPREF;
    }
    int SpeedCostPREF(int _speedCostPREF)
    {
        if (!PlayerPrefs.HasKey("speedcost"))
        {
            PlayerPrefs.SetInt("speedcost", 1000);
        }
        speedCostPREF = PlayerPrefs.GetInt("speedcost");
        return speedCostPREF;
    }
    

    void Update()
    {

    }
}
