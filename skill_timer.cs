using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skill_timer : MonoBehaviour
{
    float contador;
    float contador2;
    public Text skill2_timer;
    public Text skill3_timer;

    bool x;
    bool y;
 
    // Start is called before the first frame update
    void Start()
    {
        contador = 10f;
        contador2 = 8f;

        x = false;
        y = false;
    }

    void thundertimer()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            x = true;
        }

        if (x == true)
        {
            contador -= Time.deltaTime;

            if (contador < 1f)
                x = false;

            if (x == false)
                contador = 10f;

            skill2_timer.text = "Thunder Timer - " + contador.ToString("0");
        }


    }

    void Fire()
    {

        if (Input.GetKeyUp(KeyCode.Q))
        {
            y = true;


        }

        if (y == true)
        {
            contador2 -= Time.deltaTime;

            if (contador2 < 1f)
                y = false;

            if (y == false)
                contador2 = 8f;

            skill3_timer.text = "Fire Timer - " + contador2.ToString("0");


        }
    }

    // Update is called once per frame
    void Update()
    {


        thundertimer();
        Fire();
        

    }
}
