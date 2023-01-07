using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarHeroUI : MonoBehaviour
{
    public GameObject healthUIPrefab;
    public Transform barPoint;
    Image healthSlider;
    Transform UIbar;
    Transform cam;
    private void Start()
    {

    }

    private void Update()
    {
        healthUIPrefab.transform.GetChild(0).GetComponent<Image>().fillAmount = HeroData.Instance.heroHp  / HeroData.Instance.heroMaxHp;
        healthUIPrefab.transform.forward = Camera.main.transform.forward;
        if (HeroData.Instance.heroHp<500)
        {
            HeroData.Instance.heroHp = 500;
        }
    }
}
