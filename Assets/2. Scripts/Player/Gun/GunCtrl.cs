using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCtrl : MonoBehaviour
{
    public Recoil Recoil;
    public GunSoundManager gunSoundManager;
    public float randomReloadTime;
    public float reloadTime;
    public float reload = 0;

    

    int i = 0;
    private bool isGun = false;

    public GameObject Bullet;
    public GunData[] gunDatas;

    void Awake()
    {
        randomReloadTime = reloadTime + Random.RandomRange(-(reload * 0.1f), (reload * 0.1f));
        reload = randomReloadTime;
    }
    void Update()
    {
        GunTime();
        GunFire();
    }

    void GunFire()
    {
        if (Input.GetMouseButton(0) && isGun == false)
        {
            randomReloadTime = reloadTime + Random.RandomRange(-(reload * 0.1f), (reload * 0.1f));
            isGun = true;
            Recoil.Run();

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

            gunSoundManager.SoundPlay();

            i++;

            reload = 0;
        }
    }

    void GunTime()
    {
        if (isGun)
        {
            reload += 1 * Time.deltaTime;

            if (reload >= randomReloadTime)
            {
                reload = randomReloadTime;
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
}