using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PlayerChange : MonoBehaviour
{
    public CinemachineBrain brain;
    public GameObject[] cam = {null, null , null};
    public GameObject[] player;

    public float t = 0;
    public bool isT = false;
    public int ch = 0;

    void Start()
    {
        cam[0].SetActive(true);
        cam[1].SetActive(false);
        cam[2].SetActive(false);
        player[0].SetActive(true);
        player[1].SetActive(false);
        player[2].SetActive(false);
    }

    void Update()
    {
        Change();
        /*if (isT)
        {
            ChangeTime();
        }*/
    }
    
    void ChangeTime()
    {
        t += 1 * Time.deltaTime;
        if (t >= 0.5f)
        {
            isT = false;
            t = 0;
            brain.m_DefaultBlend.m_Time = 0.15f;
        }
    }

    void Change()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && ch != 0)
        {
            cam[0].SetActive(true);
            cam[1].SetActive(false);
            cam[2].SetActive(false);
            player[0].SetActive(true);
            player[1].SetActive(false);
            player[2].SetActive(false);
            isT = true;
            //brain.m_DefaultBlend.m_Time = 0.5f;
            ch = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && ch != 1)
        {
            cam[0].SetActive(false);
            cam[1].SetActive(true);
            cam[2].SetActive(false);
            player[0].SetActive(false);
            player[1].SetActive(true);
            player[2].SetActive(false);
            isT = true;
            //brain.m_DefaultBlend.m_Time = 0.5f;
            ch = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && ch != 2)
        {
            cam[0].SetActive(false);
            cam[1].SetActive(false);
            cam[2].SetActive(true);
            player[0].SetActive(false);
            player[1].SetActive(false);
            player[2].SetActive(true);
            isT = true;
            //brain.m_DefaultBlend.m_Time = 0.5f;
            ch = 2;
        }
        
    }
}
