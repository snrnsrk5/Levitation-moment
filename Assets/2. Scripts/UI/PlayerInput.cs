using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    public Image fire;
    public Image burst;

    [SerializeField] private GunCtrl gunCtrl;
    [SerializeField] private FullBurst fullBurst;

    void Update()
    {
        gunCtrl = FindObjectOfType<GunCtrl>();
        fullBurst = FindObjectOfType<FullBurst>();
        UIUpdate();
    }

    void UIUpdate()
    {
        fire.fillAmount = gunCtrl.reload / gunCtrl.randomReloadTime;
        burst.fillAmount = fullBurst.reload / fullBurst.randomReloadTime;

        // if (gunCtrl.reload >= gunCtrl.reloadTime)
        // {
        //     fire.fillAmount = 1;
        // }

        // if (fullBurst.reload < fullBurst.reloadTime)
        // {
        //     burst.fillAmount = 1;
        // }
    }
}
