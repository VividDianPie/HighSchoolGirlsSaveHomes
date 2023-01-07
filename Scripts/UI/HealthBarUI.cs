using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
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
        healthUIPrefab.transform.GetChild(0).GetComponent<Image>().fillAmount = this.gameObject.GetComponent<MonsterData>().monsterHp / this.gameObject.GetComponent<MonsterData>().monsterMaxHp;
        healthUIPrefab.transform.forward = -Camera.main.transform.forward;
    }
}
