using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 100f;
    bool x;
    public float deathtime;
    private Animation anim;
    public Text GoblinL;


    public void HealthDeduct(float deducthealth)
    {
        enemyHealth -= deducthealth;
        
    }

    public void Update()
    {
        if (enemyHealth > 0)
        {
            GoblinL.text = "Goblin Life - " + enemyHealth.ToString("0");
        }
    }

}
