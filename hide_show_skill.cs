using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class hide_show_skill : MonoBehaviour
{
    public GameObject skill_1;
    public GameObject skill_2;
    public GameObject skill_3;
    public GameObject Inventory;
    public Vector3 goblin_pos;
    public Vector3 skill_pos;
    public float contador;
    public float contador2;
    public GameObject objectToBeSpawned;
    public GameObject multiple_skill;
    bool x;
    bool y;
    bool _Inv;


    void Start()
    {
      
        contador = 10;
        contador2 = 8;
        skill_2.SetActive(false);
        skill_3.SetActive(false);
        Inventory.SetActive(false);
        y = false;
        _Inv = false;

    }

    // Start is called before the first frame update
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            skill_1.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.I) && (_Inv == false))
        {
            Inventory.SetActive(true);
            _Inv = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && (_Inv == true) )
        {
            Inventory.SetActive(false);
            _Inv = false;
        }


        if (Input.GetKeyUp(KeyCode.Q) && (y == false))
        {
            skill_1.SetActive(false);
            skill_pos = GameObject.Find("aaa").transform.position;
            skill_3.transform.position = new Vector3(skill_pos.x, skill_pos.y , skill_pos.z);
            skill_3.SetActive(true);
            y = true;

        }


        if (Input.GetKeyUp(KeyCode.Q))
        {
            skill_1.SetActive(false);
        }


        if (Input.GetKeyDown(KeyCode.G) && (x == false))
        {   
            goblin_pos = GameObject.Find("GOBLIN").transform.position;
            skill_2.transform.position = new Vector3(goblin_pos.x + 0.2f,goblin_pos.y + 3.5f,goblin_pos.z + 1.2f);
            skill_2.SetActive(true);
            x = true;
        }

        if  (x == true)
        {
            contador -= Time.deltaTime;

            if (contador < 0)
            {
                skill_2.SetActive(false);
                x = false;
                contador = 10;
            }
        }



        if (y == true)
        {

            contador2 -= Time.deltaTime;


            if (contador2 < 0)
            {
                y = false;
                contador2 = 8;
                skill_3.SetActive(false);

            }
        }


        if (Input.GetKeyUp(KeyCode.Z))
        {
            Instantiate(multiple_skill);
            Instantiate(objectToBeSpawned);
   
        }

        if (Input.GetKeyUp(KeyCode.F1))
        {
            SceneManager.LoadScene("GoblinScene");
        }



    }



}
 