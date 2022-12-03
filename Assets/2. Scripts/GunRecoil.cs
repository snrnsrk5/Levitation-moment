using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem.XR;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class GunRecoil : MonoBehaviour
{
    public GameObject cinemachine;

    public PlayerRoot Player;

    public float reTime;
    private float re = 0;

    public float randomReloadTime;
    public float reloadTime;
    private float reload = 0;
    public float recoil = 1;

    public float pitch;

    int mp;
    int i = 0;
    private bool isRun = false;
    private bool isGun = false;



    public GameObject Bullet;
    public GunData[] gunDatas;

    void Awake()
    {
        randomReloadTime = reloadTime + Random.RandomRange(-(reload * 0.1f), (reload * 0.1f));
    }
    void Update()
    {
        RunTime();
        GunTime();

        if (Input.GetMouseButton(0) && isGun == false)
        {
            isGun = true;
            isRun = true;

            for (int i = 0; i < gunDatas.Length; i++)
            {
                float rol = 1;
                for (int bar = 0; bar < gunDatas[i].barrel; bar++)
                {
                    float rng = Random.RandomRange(0.1f, 1f);
                    Instantiate(Bullet, gunDatas[i].pos.transform.position, gunDatas[i].pos.transform.rotation
                        * Quaternion.Euler(rng * 0.5f, bar * rng, rng * 0.5f));

                    rol *= -1;
                }

            }

            gunDatas[i].particleSystem.Play();

            pitch = Random.RandomRange(0.8f, 1.2f);
            gunDatas[i].gunSound.pitch = pitch;
            gunDatas[i].gunSound.Play();
           
            re = 0;
            reload = 0;

            mp = Random.Range(0, 2);
            St();


            /*if (i == gunDatas.Length) i = 0;

            float rol = 1;
            for (int bar = 0; bar < gunDatas[i].barrel; bar++)
            {
                float rng = Random.RandomRange(0.1f, 1f);
                Instantiate(Bullet, gunDatas[i].pos.transform.position, gunDatas[i].pos.transform.rotation
                    * Quaternion.Euler(rng * 0.5f, bar * rng, rng * 0.5f));

                rol *= -1;
            }
            gunDatas[i].particleSystem.Play();

            pitch = Random.RandomRange(0.8f, 1.2f);
            gunDatas[i].gunSound.pitch = pitch;
            gunDatas[i].gunSound.Play();
            i++;

            re = 0;
            reload = 0;

            mp = Random.Range(0, 2);

            St();*/
        }

        if (Input.GetMouseButton(1))
        {
            Zoom();
        }
        else
        {
            cinemachine.SetActive(false);
        }
    }

    void RunTime()
    {
        if (isRun)
        {
            re += 1 * Time.deltaTime;

            if (re > reTime)
            {
                isRun = false;
                Fi();
            }
        }

    }
    void GunTime()
    {
        if (isGun)
        {
            reload += 1 * Time.deltaTime;

            if (reload > randomReloadTime)
            {
                randomReloadTime = reloadTime + Random.RandomRange(-(reload * 0.1f), (reload * 0.1f));
                isGun = false;
            }
        }
    }

    void St()
    {
        if (mp == 0)
        {
            Player.transform.DORotate(new Vector3(Player.xRotate -= Random.RandomRange(recoil * 1f, recoil * 1.5f),
            Player.yRotate += Random.RandomRange(recoil * 0.5f, recoil * 0.75f), 0), 0.025f);
        }
        if (mp == 1)
        {
            Player.transform.DORotate(new Vector3(Player.xRotate -= Random.RandomRange(recoil * 1f, recoil * 1.5f),
            Player.yRotate -= Random.RandomRange(recoil * 0.5f, recoil * 0.75f), 0), 0.025f);
        }
    }

    void Fi()
    {
        if (mp == 0)
        {
            Player.transform.DORotate(new Vector3(Player.xRotate += Random.RandomRange(recoil * 0.5f, recoil * 0.75f),
            Player.yRotate -= Random.RandomRange(recoil * 0.25f, recoil * 0.375f), 0), 0.05f);
        }
        if (mp == 1)
        {
            Player.transform.DORotate(new Vector3(Player.xRotate += Random.RandomRange(recoil * 0.5f, recoil * 0.75f),
            Player.yRotate += Random.RandomRange(recoil * 0.25f, recoil * 0.375f), 0), 0.05f);
        }
    }

    void Zoom()
    {
        cinemachine.SetActive(true);
    }
}

[System.Serializable]
public class GunData
{
    public int barrel;
    public GameObject pos;
    public ParticleSystem particleSystem;
    public AudioSource gunSound;
}