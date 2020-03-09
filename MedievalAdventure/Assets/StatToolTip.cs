using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class StatToolTip : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statNameText;

    [SerializeField] private TextMeshProUGUI statModifierLabelText;

    [SerializeField] private TextMeshProUGUI statModifierText;

    private StringBuilder stringbuilder = new StringBuilder();

    public void ShowToolTip(Statistic stat, string statName)
    {
        this.statNameText.text = this.GetStatTopText(stat, statName);
        this.statModifierLabelText.text = "Modifiers";
        this.statModifierText.text = this.GetStatModifiersText(stat);
        

        this.gameObject.SetActive(true);
    }

    public void HideToolTip()
    {
        this.gameObject.SetActive(false);
    }

    private string GetStatTopText(Statistic stat, string statName)
    {
        this.stringbuilder.Length = 0;
        this.stringbuilder.Append(statName);
        this.stringbuilder.Append(" : ");
        this.stringbuilder.Append(Math.Round(stat.Value, 2));

        if(stat.Value != stat.BaseValue)
        {
            this.stringbuilder.Append(" (");
            this.stringbuilder.Append(stat.BaseValue);

            if (stat.Value > stat.BaseValue || (stat.Value - stat.BaseValue) == 0)
            {
                this.stringbuilder.Append("+");
            }

            this.stringbuilder.Append(Math.Round(stat.Value - stat.BaseValue, 2));
            this.stringbuilder.Append(")");
        }

        return this.stringbuilder.ToString();
    }

    private string GetStatModifiersText(Statistic stat)
    {
        this.stringbuilder.Length = 0;
        foreach (StatisticModifier mod in stat.StatisticModifier)
        {
            if(this.stringbuilder.Length > 0)
            {
                this.stringbuilder.AppendLine();
            }

            if(mod.Value > 0)
            {
                this.stringbuilder.Append("+");
            }

            if (mod.Type == StatisticModifierType.Flat)
            {
                this.stringbuilder.Append(mod.Value);
                this.stringbuilder.Append(" ");
            }
            else if (mod.Type == StatisticModifierType.PercentAdd)
            {
                this.stringbuilder.Append(mod.Value * 100);
                this.stringbuilder.Append("% ");
            }

            EquippableItem item = mod.Source as EquippableItem;

            if(item != null)
            {
                this.stringbuilder.Append(" ");
                this.stringbuilder.Append(item.ItemName);
            }
            else
            {
                Debug.LogError("Modifier is not an equippable item");
            }
        }

        return this.stringbuilder.ToString();
    }
}
