using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem.XR;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class GunCtrl : MonoBehaviour
{
    public Recoil Recoil;


    public float randomReloadTime;
    public float reloadTime;
    private float reload = 0;

    public float pitch;

    int i = 0;
    private bool isGun = false;



    public GameObject Bullet;
    public GunData[] gunDatas;

    void Awake()
    {
        randomReloadTime = reloadTime + Random.RandomRange(-(reload * 0.1f), (reload * 0.1f));
    }
    void Update()
    {
        GunTime();
        GunFire();
    }

    // 한번에 쏘는거
    void GunFire()
    {
        if (Input.GetMouseButton(0) && isGun == false)
        {
            isGun = true;

            Recoil.Run();

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

            Recoil.re = 0;
            reload = 0;


        }
    }

    // 한발씩 쏘는거
    void SimGunFire()
    {
        if (Input.GetMouseButton(0) && isGun == false)
        {
            if (i == gunDatas.Length) i = 0;

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

            reload = 0;
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

}

[System.Serializable]
public class GunData
{
    public int barrel;
    public GameObject pos;
    public ParticleSystem particleSystem;
    public AudioSource gunSound;
}