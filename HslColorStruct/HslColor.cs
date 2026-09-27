namespace HslColorStruct;

public readonly struct HslColor : IEquatable<HslColor>
{
    private readonly int hue;
    private readonly int saturation;
    private readonly int lightness;

    public HslColor(int hue, int saturation, int lightness)
    {
        this.Hue = hue;
        this.Saturation = saturation;
        this.Lightness = lightness;
    }

    public int Hue
    {
        get => this.hue;
        init
        {
            ThrowExceptionIfValueIsNotValid(value, nameof(value), 0, 360);
            this.hue = value;
        }
    }

    public int Saturation
    {
        get => this.saturation;
        init
        {
            ThrowExceptionIfValueIsNotValid(value, nameof(value), 0, 100);
            this.saturation = value;
        }
    }

    public int Lightness
    {
        get => this.lightness;
        init
        {
            ThrowExceptionIfValueIsNotValid(value, nameof(value), 0, 100);
            this.lightness = value;
        }
    }

    public static HslColor Create(int hue, int saturation, int lightness)
    {
        return new HslColor(hue, saturation, lightness);
    }

    public static HslColor Parse(string hslString)
    {
        if (TryParse(hslString, out HslColor result))
        {
            return result;
        }

        throw new ArgumentException("HslString format is invalid");
    }

    public static bool TryParse(string hslString, out HslColor hslColor)
    {
        hslColor = default;

        if (string.IsNullOrWhiteSpace(hslString))
        {
            return false;
        }

        var splitList = hslString.Split(",").ToList();
        var parseList = new List<int>();

        if (splitList.Count != 3)
        {
            return false;
        }

        foreach (var item in splitList)
        {
            if (!int.TryParse(item, out int value))
            {
                return false;
            }

            parseList.Add(value);
        }

        try
        {
            hslColor = Create(parseList[0], parseList[1], parseList[2]);
            return true;
        }
        catch (ArgumentException)
        {
            return false;
        }
    }

    public bool Equals(HslColor other)
    {
       return this.Hue == other.Hue && this.Saturation == other.Saturation && this.Lightness == other.Lightness;
    }

    public override bool Equals(object? obj)
    {
        return obj is HslColor other && this.Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.Hue, this.Saturation, this.Lightness);
    }

    public override string ToString()
    {
        return $"{this.Hue},{this.Saturation},{this.Lightness}";
    }

    public static bool operator ==(HslColor left, HslColor right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(HslColor left, HslColor right)
    {
        return !left.Equals(right);
    }

    private static void ThrowExceptionIfValueIsNotValid(int value, string parameterName, int minValue, int maxValue)
    {
        if (value < minValue || value > maxValue)
        {
            throw new ArgumentException($"Value must be between {minValue} and {maxValue}", parameterName);
        }
    }
}
