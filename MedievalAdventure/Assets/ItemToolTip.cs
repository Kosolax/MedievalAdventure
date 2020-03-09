/* -------------------------------------------------------------- */
/* -----------All rights reserved to Medieval Adventure---------- */
/* -------------------------------------------------------------- */

using System.Text;
using TMPro;
using UnityEngine;

public class ItemToolTip : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemNameText;

    [SerializeField] private TextMeshProUGUI itemSlotText;

    [SerializeField] private TextMeshProUGUI itemStatsText;

    private StringBuilder stringbuilder = new StringBuilder();

    public void ShowToolTip(EquippableItem item)
    {
        this.itemNameText.text = item.ItemName;
        this.itemSlotText.text = item.EquipmentType.ToString();
        this.stringbuilder.Length = 0;

        this.AddStat(item.ActionPointBonus, "Point d'action", false);
        this.AddStat(item.CriticalRateBonus, "Coup critique", false);
        this.AddStat(item.HealthPointBonus, "Point de vie", false);
        this.AddStat(item.MagicalDamageBonus, "Dégats magique", false);
        this.AddStat(item.MagicalPenetrationBonus, "Pénétration magique", false);
        this.AddStat(item.MagicalResistanceBonus, "Résistance magique", false);
        this.AddStat(item.PhysicalDamageBonus, "Dégats physique", false);
        this.AddStat(item.PhysicalPenetrationBonus, "Pénétration physique", false);
        this.AddStat(item.PhysicalResistanceBonus, "Résistance physique", false);
        this.AddStat(item.SpeedBonus, "Vitesse", false);

        this.AddStat(item.ActionPointPercentBonus, "Point d'action", true);
        this.AddStat(item.CriticalRatePercentBonus, "Coup critique", true);
        this.AddStat(item.HealthPointPercentBonus, "Point de vie", true);
        this.AddStat(item.MagicalDamagePercentBonus, "Dégats magique", true);
        this.AddStat(item.MagicalPenetrationPercentBonus, "Pénétration magique", true);
        this.AddStat(item.MagicalResistancePercentBonus, "Résistance magique", true);
        this.AddStat(item.PhysicalDamagePercentBonus, "Dégats physique", true);
        this.AddStat(item.PhysicalPenetrationPercentBonus, "Pénétration physique", true);
        this.AddStat(item.PhysicalResistancePercentBonus, "Résistance physique", true);
        this.AddStat(item.SpeedPercentBonus, "Vitesse", true);

        this.itemStatsText.text = this.stringbuilder.ToString();

        this.gameObject.SetActive(true);
    }

    public void HideToolTip()
    {
        this.gameObject.SetActive(false);
    }

    private void AddStat(float value, string statName, bool isPercentage)
    {
        if (value != 0)
        {
            if (this.stringbuilder.Length > 0)
            {
                this.stringbuilder.AppendLine();
            }

            if (value > 0)
            {
                this.stringbuilder.Append("+");
            }

            if (isPercentage)
            {
                this.stringbuilder.Append(value * 100);
                this.stringbuilder.Append("% ");
            } else
            {
                this.stringbuilder.Append(value);
                this.stringbuilder.Append(" ");
            }

            this.stringbuilder.Append(statName);
        }
    }
}
