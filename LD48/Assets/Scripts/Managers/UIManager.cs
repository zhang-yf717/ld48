using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    private static UIManager instance;
    public static UIManager Instance {
        get {
            instance = FindObjectOfType<UIManager>();
            return instance;
        }
    }
    [SerializeField]
    private GameObject infoTip;
    public GameObject InfoTip {
        get {
            return infoTip;
        }
    }

    public float infoTipShowTime = 1;

    [SerializeField]
    private Image healthFillImage;
    [SerializeField]
    private Text healthLabel;
    public void SetHealthlabel(float current, float maxHealth) {
        var color = "#71EB73";
        var ratio = current / maxHealth;

        healthFillImage.fillAmount = ratio;
        if (ratio <= .7f && ratio > .3f) {
            color = "yellow";
        } else if (ratio <= .3f) {
            color = "red";
        }
        healthLabel.text = "<color=" + color + ">" + ((int)current).ToString() +
            "</color> / " +
            maxHealth.ToString();
    }

    [SerializeField]
    private Text slimeCountLable;
    public void SetSlimeCount(int cur) {
        slimeCountLable.text = "Slimes Remaining: " + cur.ToString();
    }

}
