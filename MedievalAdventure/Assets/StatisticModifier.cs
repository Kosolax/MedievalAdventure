/* -------------------------------------------------------------- */
/* -----------All rights reserved to Medieval Adventure---------- */
/* -------------------------------------------------------------- */

public enum StatisticModifierType : int
{
    Flat = 100,
    PercentAdd = 200,
    PercentMult = 300,
}

public class StatisticModifier
{
    public readonly float Value;
    public readonly StatisticModifierType Type;
    public readonly int Order;
    //To tell where the modifier comes from (sword, enemy spell, ally spell etc ...)
    public readonly object Source;

    public StatisticModifier(float value, StatisticModifierType type, int order, object source)
    {
        this.Value = value;
        this.Type = type;
        this.Order = order;
        this.Source = source;
    }

    public StatisticModifier(float value, StatisticModifierType type) : this(value, type, (int)type, null) { }

    public StatisticModifier(float value, StatisticModifierType type, int order) : this(value, type, order, null) { }

    public StatisticModifier(float value, StatisticModifierType type, object source) : this(value, type, (int)type, source) { }
}
