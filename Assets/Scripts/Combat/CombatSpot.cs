using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CombatSpot : MonoBehaviour
{
    [SerializeField] private GameObject spot;
    [SerializeField] private Image unitImage;
    [SerializeField] private Image HpBar;
    [SerializeField] private Image SpeedBar;
    [SerializeField] private Text _name;

    

    public void SetUnitStats(Unit unit)
    {
        spot.SetActive(true);
        unitImage.enabled = true;
        unitImage.sprite = unit.Sprite;
        SetHpBar(unit.MaxHp,unit.MaxHp);
        SetSpeedBar(unit.MaxSpeed,unit.MaxSpeed);
        _name.text = unit.Name;

    }
    public void SetHpBar(int hp,int maxhp)
    {
        float normalizeHP = Mathf.InverseLerp(0, maxhp, hp);
        HpBar.transform.localScale = new Vector3(normalizeHP, 1f);
    }
    public void SetSpeedBar(int speed, int maxSpeed)
    {
        float normalizeSpeed = Mathf.InverseLerp(0, maxSpeed, speed);
        SpeedBar.transform.localScale = new Vector3(normalizeSpeed, 1f);
    }
}
