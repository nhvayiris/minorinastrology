public class Stat
{
    private float maxValue;
    private float value;

    public float Value => value;
    public float MaxValue => maxValue;

    public Stat(float value)
    {
        this.value = value;
        maxValue = value;
    }

    public static Stat operator +(Stat stat, float value)
    {
        if (stat.Value > stat.maxValue)
            stat.value = stat.maxValue;
        stat.value += value;
        return stat;
    }

    public static Stat operator -(Stat stat, float value)
    {
        if (stat.value < 0)
            stat.value = 0;
        stat.value -= value;
        return stat;
    }

    public void AddToMax(float addValue)
    {
        maxValue += addValue;
        value += addValue;
    }

    public void SetMax(float maxValue)
    {
        this.maxValue = maxValue;
    }

    public static implicit operator Stat(float f)
    {
        return new Stat(f);
    }

    public static implicit operator float(Stat stat)
    {
        return stat.value;
    }

    public void SetValue(float value)
    {
        this.value = value;
    }
}