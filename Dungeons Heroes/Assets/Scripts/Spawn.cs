using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public Transform player;

    public Animator animator;

    public GameObject spider;
    public GameObject lich;
    public GameObject fox;
    public GameObject slime;
    public GameObject boss;

    List<GameObject> enemies = new List<GameObject>();

    public bool sala1 = false;
    public bool sala2 = false;
    public bool sala3 = false;
    public bool sala4 = false;
    public bool sala5 = false;
    public bool sala6 = false;
    public bool sala7 = false;
    public bool sala8 = false;
    public bool sala9 = false;
    public bool sala10 = false;
    public bool sala11 = false;
    public bool sala12 = false;
    public bool sala13 = false;
    public bool sala14 = false;
    public bool sala15 = false;
    public bool sala16 = false;

    [SerializeField] private CanvasManager canvas;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void createEnemies(float pos_x, float pos_z)
    {
        if (sala2)
        {
            GameObject enemy = Instantiate(slime, new Vector3(pos_x - 2.0f, 2.0f, pos_z - 1.0f), Quaternion.identity);
            enemies.Add(enemy);

            GameObject enemy1 = Instantiate(slime, new Vector3(pos_x - 2.0f, 2.0f, pos_z - 4.0f), Quaternion.identity);
            enemies.Add(enemy1);
        }
        else if (sala3)
        {
            GameObject enemy2 = Instantiate(lich, new Vector3(pos_x + 2.0f, 2.0f, pos_z - 4.0f), Quaternion.identity);
            enemies.Add(enemy2);

            GameObject enemy3 = Instantiate(fox, new Vector3(pos_x - 2.0f, 2.0f, pos_z - 4.0f), Quaternion.identity);
            enemies.Add(enemy3);

        }
        else if (sala4)
        {
            GameObject enemy4 = Instantiate(spider, new Vector3(pos_x + 2.0f, 2.0f, pos_z + 1.0f), Quaternion.identity);
            enemies.Add(enemy4);
        }
        else if (sala5)
        {
            GameObject enemy5 = Instantiate(lich, new Vector3(pos_x + 2.0f, 2.0f, pos_z - 4.0f), Quaternion.identity);
            enemies.Add(enemy5);

            GameObject enemy6 = Instantiate(slime, new Vector3(pos_x - 2.0f, 2.0f, pos_z - 1.0f), Quaternion.identity);
            enemies.Add(enemy6);
        }
        else if (sala6)
        {
            GameObject enemy7 = Instantiate(spider, new Vector3(pos_x + 2.0f, 2.0f, pos_z ), Quaternion.identity);
            enemies.Add(enemy7);

            GameObject enemy8 = Instantiate(fox, new Vector3(pos_x - 2.0f, 2.0f, pos_z - 4.0f), Quaternion.identity);
            enemies.Add(enemy8);
        }
        else if (sala8)
        {
            GameObject enemy9 = Instantiate(fox, new Vector3(pos_x - 2.0f, 2.0f, pos_z - 4.0f), Quaternion.identity);
            enemies.Add(enemy9);

            GameObject enemy10 = Instantiate(slime, new Vector3(pos_x - 2.0f, 2.0f, pos_z - 1.0f), Quaternion.identity);
            enemies.Add(enemy10);
        }
        else if (sala9)
        {
            GameObject enemy11 = Instantiate(fox, new Vector3(pos_x - 2.0f, 2.0f, pos_z - 4.0f), Quaternion.identity);
            enemies.Add(enemy11);

            GameObject enemy12 = Instantiate(fox, new Vector3(pos_x + 2.0f, 2.0f, pos_z - 4.0f), Quaternion.identity);
            enemies.Add(enemy12);
        }
        else if (sala10)
        {
            GameObject enemy13 = Instantiate(spider, new Vector3(pos_x + 2.0f, 2.0f, pos_z - 4.0f), Quaternion.identity);
            enemies.Add(enemy13);

            GameObject enemy14 = Instantiate(spider, new Vector3(pos_x - 2.0f, 3.0f, pos_z -4.0f), Quaternion.identity);
            enemies.Add(enemy14);
        }
        else if (sala11)
        {
            GameObject enemy15 = Instantiate(lich, new Vector3(pos_x + 2.0f, 2.0f, pos_z - 4.0f), Quaternion.identity);
            enemies.Add(enemy15);

            GameObject enemy16 = Instantiate(slime, new Vector3(pos_x - 2.0f, 3.0f, pos_z - 1.0f), Quaternion.identity);
            enemies.Add(enemy16);

        }
        else if (sala12)
        {
            GameObject enemy17 = Instantiate(lich, new Vector3(pos_x + 2.0f, 3.0f, pos_z - 4.0f), Quaternion.identity);
            enemies.Add(enemy17);

            GameObject enemy18 = Instantiate(fox, new Vector3(pos_x - 2.0f, 3.0f, pos_z - 4.0f), Quaternion.identity);
            enemies.Add(enemy18);
        }
        else if (sala13)
        {
            GameObject enemy19 = Instantiate(fox, new Vector3(pos_x - 2.0f, 3.0f, pos_z - 4.0f), Quaternion.identity);
            enemies.Add(enemy19);

            GameObject enemy20 = Instantiate(fox, new Vector3(pos_x - 2.0f, 3.0f, pos_z), Quaternion.identity);
            enemies.Add(enemy20);

        }

        else if (sala14)
        {
            GameObject enemy21 = Instantiate(lich, new Vector3(pos_x + 2.0f, 3.0f, pos_z - 4.0f), Quaternion.identity);
            enemies.Add(enemy21);

            GameObject enemy22 = Instantiate(lich, new Vector3(pos_x + 2.0f, 3.0f, pos_z + 4.0f), Quaternion.identity);
            enemies.Add(enemy22);
        }

        else if (sala16)
        {
            canvas.BossFight();
            boss.SetActive(true);
        }
        /*

        GameObject enemy = Instantiate(lich, new Vector3(pos_x + 2.0f, 3.0f, pos_z - 4.0f), Quaternion.identity);
        enemies.Add(enemy);

        GameObject enemy1 = Instantiate(spider, new Vector3(pos_x + 2.0f, 3.0f, pos_z + 1.0f), Quaternion.identity);
        enemies.Add(enemy1);

        GameObject enemy2 = Instantiate(fox, new Vector3(pos_x - 2.0f, 3.0f, pos_z - 4.0f), Quaternion.identity);
        enemies.Add(enemy2);

        GameObject enemy3 = Instantiate(slime, new Vector3(pos_x - 2.0f, 3.0f, pos_z - 1.0f), Quaternion.identity);
        enemies.Add(enemy3);
        */
    }

    void deleteEnemies()
    {

        if (enemies.Count > 0)
        {
            foreach (GameObject en in enemies)
            {
                Destroy(en);
            }
        }

    }

    IEnumerator waitToDeleteCreate(float pos_x, float pos_z, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        deleteEnemies();
        createEnemies(pos_x, pos_z);
    }

    void checkCameraFromPlayerLocation(float x, float y, float z)
    {
        //Agrupaci�n de zonas 1
        if (z > 173)
        {
            if (x > 54.5)
            {
                if (z < 208.5f && z > 191.5f)
                {
                    if (!sala3) { 
                        StartCoroutine(waitToDeleteCreate(68.0f, 199.50f, 1.0f));
                        Debug.Log("Entro a Zone3");
                        sala4 = false;
                        sala2 = false;
                        sala3 = true;
                    }
                }
                else if (z < 191.5f && z > 174)
                {
                    if (!sala6)
                    {
                        StartCoroutine(waitToDeleteCreate(68.0f, 182.0f, 1.0f));
                        Debug.Log("Entro a Zone4");
                        sala3 = false;
                        sala4 = true;
                    }
                }
            }
            if (x < 54.5 && x > 33.5)
            {
                if (z < 207.5f && z > 191.5f)
                {
                    if (!sala2)
                    {
                        // deleteEnemies();
                        //createEnemies(44.0f,199.50f);
                        StartCoroutine(waitToDeleteCreate(44.0f, 199.50f, 1.0f));
                        Debug.Log("Entro a Zone2");
                        sala3 = false;
                        sala6 = false;
                        sala5 = false;
                        sala1 = false;
                        sala2 = true;
                     
                    }
                }
                else if (z > 207.5f)
                {
                    if (!sala1)
                    {
                        deleteEnemies();
                        Debug.Log("Entro a Zone1");
                        sala2 = false;
                        sala1 = true;
                    }
                }
                else if (z < 190.5f && z > 174)
                {
                    if (!sala6)
                    {
                        StartCoroutine(waitToDeleteCreate(44.0f, 182.0f, 1.0f));
                        Debug.Log("Entro a Zone6");
                        sala2 = false;
                        sala7 = false;
                        sala6 = true;
                    }
                }
            }
            else if (x < 33.5)
            {
                if (!sala5)
                {
                    StartCoroutine(waitToDeleteCreate(20.0f, 199.5f, 1.0f));
                    Debug.Log("Entro a Zone5");
                    sala2 = false;
                    sala5 = true;
                }


            }
        }
        //Agrupaci�n de zonas 3
        else if (z < 142)
        {
            if (z < 125.5 && z > 109)
            {
                if (x > 54.5)
                {
                    if (!sala14)
                    {
                        StartCoroutine(waitToDeleteCreate(68.0f, 117.0f, 1.0f));
                        Debug.Log("Entro a Zona14");
                        sala13 = false;
                        sala14 = true;
                    }
                }
                else if (x < 33.5)
                {
                    if (!sala15)
                    {
                        deleteEnemies();
                        Debug.Log("Entro a Zona15");
                        sala13 = false;
                        sala15 = true;
                    }
                }
                else
                {
                    if (!sala13)
                    {
                        StartCoroutine(waitToDeleteCreate(44.0f, 117.0f, 1.0f));
                        Debug.Log("Entro a Zona13");
                        sala12 = false;
                        sala14 = false;
                        sala15 = false;
                        sala16 = false;
                        sala13 = true;
                    }
                }
            }
            else if (z > 125.5)
            {
                if (!sala12)
                {
                    StartCoroutine(waitToDeleteCreate(44.0f, 137.0f, 1.0f));
                    Debug.Log("Entro a Zona12");
                    sala13 = false;
                    sala7 = false;
                    sala12 = true;
                }
            }
            else
            {
                if (!sala16)
                {
                    StartCoroutine(waitToDeleteCreate(26.0f, 153.0f, 1.0f));
                    Debug.Log("Entro a Zona16");
                    sala13 = false;
                    sala16 = true;
                }
            }

        }
        //Agrupaci�n de zonas 2
        else
        {
            if (x > 50)
            {
                if (z > 158.6f)
                {
                    if (!sala8)
                    {
                        StartCoroutine(waitToDeleteCreate(64.0f, 170.5f, 1.0f));
                        Debug.Log("Entro a Zona8");
                        sala7 = false;
                        sala8 = true;;
                      
                    }
                }
                else
                {
                    if (!sala10)
                    {
                        StartCoroutine(waitToDeleteCreate(64.0f, 153.0f, 1.0f));    
                        Debug.Log("Entro a Zona10");
                        sala7 = false;
                        sala10 = true; ;
                    }
                }
            }
            else if (x < 38)
            {
                if (z > 158.6f)
                {
                    if(!sala9)
                    {
                        StartCoroutine(waitToDeleteCreate(26.0f, 170.5f, 1.0f));
                        Debug.Log("Entro a Zona9");
                        sala7 = false;
                        sala9 = true; 
                    }
                }
                else
                {
                    if (!sala11)
                    {
                        StartCoroutine(waitToDeleteCreate(26.0f, 153.0f, 1.0f));
                        Debug.Log("Entro a Zona11");
                        sala7 = false;
                        sala11 = true;
                    }
                }

            }
            else
            {
                if (!sala7)
                {
                    deleteEnemies();
                    Debug.Log("Entro a Zona7");
                    sala6 = false;
                    sala8 = false;
                    sala9 = false;
                    sala10 = false;
                    sala11 = false;
                    sala12 = false;
                    sala7 = true;
                   
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkCameraFromPlayerLocation(player.position.x, player.position.y, player.position.z);
    }
}
