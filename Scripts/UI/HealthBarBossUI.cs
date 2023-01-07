using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBossUI : MonoBehaviour
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
        healthUIPrefab.transform.GetChild(0).GetComponent<Image>().fillAmount = this.gameObject.GetComponent<MonsterData>().BOSSHp / this.gameObject.GetComponent<MonsterData>().BOSSMaxHp;
        healthUIPrefab.transform.forward = -Camera.main.transform.forward;
        if (this.gameObject.GetComponent<MonsterData>().BOSSHp == 0)
        {
            healthUIPrefab.SetActive(false);
        }
    }
}
