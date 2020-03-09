using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StatisticDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image Icone;
    [SerializeField] private string nameStat;
    [SerializeField] private TextMeshProUGUI ValueText;
    [SerializeField] private StatToolTip statToolTip;


    private Statistic stat;
    public Statistic Stat
    {
        get => this.stat;
        set
        {
            this.stat = value;
            this.UpdateStatValue();
        }
    }

    public void UpdateStatValue()
    {
        this.ValueText.text = Math.Round(this.stat.Value, 2).ToString();
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        this.statToolTip.HideToolTip();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.statToolTip.ShowToolTip(this.Stat, this.nameStat);
    }
}
