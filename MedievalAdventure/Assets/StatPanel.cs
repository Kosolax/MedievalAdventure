using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatPanel : MonoBehaviour
{
    [SerializeField] StatisticDisplay[] statisticDisplays;
    private Statistic[] stats;

    private void OnValidate()
    {
        this.statisticDisplays = this.GetComponentsInChildren<StatisticDisplay>();
    }

    public void SetStats(params Statistic[] charStats)
    {
        this.stats = charStats;
        if (this.stats.Length > this.statisticDisplays.Length) {
            return;
        }

        for (int i = 0; i < this.statisticDisplays.Length; i++)
        {
            this.statisticDisplays[i].gameObject.SetActive(i < this.stats.Length);


            if (i < this.stats.Length)
            {
                this.statisticDisplays[i].Stat = this.stats[i];
            }
        }
    }

    public void UpdateStatValues()
    {
        for (int i = 0; i < this.stats.Length; i++)
        {
            this.statisticDisplays[i].UpdateStatValue();
        }
    }
}
