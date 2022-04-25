using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attacking_animation : MonoBehaviour
{
    private Animator anim;
    private float contador = 9.5f;
    public bool isattacking;
    private float contador2 = 6.5f;
    public bool isattacking2;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isattacking = false;
        isattacking2 = false;
    }   

    // Update is called once per frame
    void Update()
    {
        if (isattacking == true)
        {
            contador -= Time.deltaTime;
            Debug.Log(contador);
        }

        if (isattacking2 == true)
        {
            contador2 -= Time.deltaTime;
            Debug.Log(contador2);
        }


        if (Input.GetKeyDown(KeyCode.G))
        {
            anim.SetBool("IsAttacking", true);
            isattacking = true;
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            anim.SetBool("IsAttacking", true);
            isattacking = true;
        }


        if (contador < 0)
        {
            isattacking = false;
            anim.SetBool("IsAttacking", false);
            contador = 9.5f;
        }

        if (contador2 < 0)
        {
            isattacking = false;
            anim.SetBool("IsAttacking", false);
            contador2 = 6.5f;
            Debug.Log("aaa");
        }




    }
}
