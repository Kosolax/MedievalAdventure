/* -------------------------------------------------------------- */
/* -----------All rights reserved to Medieval Adventure---------- */
/* -------------------------------------------------------------- */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

[Serializable]
public class Statistic
{
    public readonly ReadOnlyCollection<StatisticModifier> StatisticModifier;

    public float BaseValue;

    //let player see the modifier
    protected readonly List<StatisticModifier> statisticModifier;

    protected float _value;

    protected bool isDirty = true;

    protected float lastBaseValue = float.MinValue;

    public Statistic()
    {
        this.statisticModifier = new List<StatisticModifier>();
        this.StatisticModifier = this.statisticModifier.AsReadOnly();
    }

    public Statistic(float baseValue)
    {
        this.BaseValue = baseValue;
        this.statisticModifier = new List<StatisticModifier>();
        //You can't change StatisticModifier but when you change statisticModifier it change StatisticModifier
        this.StatisticModifier = this.statisticModifier.AsReadOnly();
    }

    public virtual float Value
    {
        get
        {
            if (this.isDirty || this.BaseValue != this.lastBaseValue)
            {
                this.lastBaseValue = this.BaseValue;
                this._value = this.CalculateFinalValue();
                this.isDirty = false;
            }

            return this._value;
        }
    }

    public virtual void AddModifier(StatisticModifier statisticModifier)
    {
        this.isDirty = true;
        this.statisticModifier.Add(statisticModifier);
        this.statisticModifier.Sort(this.CompareModifierOrder);
    }

    public virtual bool RemoveAllModifiersFromSource(object source)
    {
        bool didRemove = false;

        //Reverse delete for optimization
        for (int i = this.statisticModifier.Count - 1; i >= 0; i--)
        {
            if (this.statisticModifier[i].Source == source)
            {
                this.isDirty = true;
                didRemove = true;
                this.statisticModifier.RemoveAt(i);
            }
        }

        return didRemove;
    }

    public virtual bool RemoveModifier(StatisticModifier statisticModifier)
    {
        if (this.statisticModifier.Remove(statisticModifier))
        {
            this.isDirty = true;
        }

        return this.isDirty;
    }

    // Calculate the stat after all modifier
    protected virtual float CalculateFinalValue()
    {
        float finalValue = this.BaseValue;
        float sumPercentAdd = 0;

        for (int i = 0; i < this.statisticModifier.Count; i++)
        {
            StatisticModifier statisticModifier = this.statisticModifier[i];

            if (statisticModifier.Type == StatisticModifierType.Flat)
            {
                finalValue += this.statisticModifier[i].Value;
            }
            else if (statisticModifier.Type == StatisticModifierType.PercentAdd)
            {
                sumPercentAdd += statisticModifier.Value;

                if (i + 1 >= this.statisticModifier.Count || this.statisticModifier[i + 1].Type != StatisticModifierType.PercentAdd)
                {
                    finalValue *= 1 + sumPercentAdd;
                    sumPercentAdd = 0;
                }
            }
            else if (statisticModifier.Type == StatisticModifierType.PercentMult)
            {
                finalValue *= 1 + statisticModifier.Value;
            }
        }

        return (float)Math.Round(finalValue, 4);
    }

    // Tell the sort function how to sort
    protected virtual int CompareModifierOrder(StatisticModifier a, StatisticModifier b)
    {
        if (a.Order < b.Order)
        {
            return -1;
        }
        else if (a.Order > b.Order)
        {
            return 1;
        }

        return 0;
    }
}