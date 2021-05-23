using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{
    public static int money;

    public static int life;

    [SerializeField]
    private Text textMoney;
    
    [SerializeField]
    private Text textLive;

    [SerializeField]
    private int startMoney;

    [SerializeField]
    private int startLife;

    void Start()
    {
        money = startMoney;
        life = startLife;
    }
    
    void Update()
    {
        textMoney.text = money.ToString() + "$";
        textLive.text = life.ToString();
        if (life <= 0)
        {
            Time.timeScale = 0;
        }
    }
}
