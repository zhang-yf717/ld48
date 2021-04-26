using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance {
        get {
            if (!instance) {
                instance = GameObject.FindObjectOfType<UIManager>();
            }
            return instance;
        }
    }

    [SerializeField]
    public GameObject[] UIRoots;
    

    [Header("INFO TIP RELATED")]
    [SerializeField]
    protected GameObject infoTip_ref;
    public GameObject InfoTip => infoTip_ref;
    public float infoTip_ShowTime;

    [Header("HEALTH BAR REF")]
    [SerializeField]
    protected Image health_fillBar;
    public Image healthFillBar => health_fillBar;
    [SerializeField]
    protected Text health_text;
    public Text healthText => health_text;

    [Header("POWERUP LOC")]
    public GameObject[] powerupLocations;


    private Actor Hero;
    private float maxHealth;
    private void Start() {
        if (!Hero) Hero = FindObjectOfType<Hero>();
        // maxHealth = Hero.data.Health;
    }

    private void Update() {
        
        var data = Hero.data;
        var ratio = data.Health / data.MaxHealth;
        UIManager.Instance.healthFillBar.fillAmount = ratio;
        var color = "#B0FC8F"; // green
        if (ratio <= 0.6f && ratio > .3f)
            color = "#F9FC8F"; // yellow
        else if (ratio <= .3f)
            color = "#FC9C8F"; // red


        UIManager.Instance.healthText.text =
            string.Format("<color={0}>{1}</color> / {2}", color, data.Health, maxHealth);
    }
}
