using System.Collections.Generic;

namespace HslColorStruct;

/// <summary>
/// Represents a color in the HSL color model.
/// </summary>
public readonly struct HslColor : IEquatable<HslColor>
{
    private readonly int hue;
    private readonly int saturation;
    private readonly int lightness;

    public HslColor(int hue, int saturation, int lightness)
    {
        Hue = hue;
        Saturation = saturation;
        Lightness = lightness;
    }

    public int Hue
    {

        get => hue;
        init
        {
            ThrowExceptionIfValueIsNotValid(value, nameof(value), 0, 360);
            hue = value;
        }
    }

    public int Saturation
    {
        get => saturation;
        init
        {
            ThrowExceptionIfValueIsNotValid(value, nameof(value), 0, 100);
            saturation = value;
        }
    }

    public int Lightness
    {
        get => lightness;
        init
        {
            ThrowExceptionIfValueIsNotValid(value, nameof(value), 0, 100);
            lightness = value;
        }
    }

    public static HslColor Create(int hue, int saturation, int lightness)
    {
        return new HslColor(hue, saturation, lightness);
    }

    public static HslColor Parse(string hslString)
    {
        if(TryParse(hslString, out HslColor result))
        {
            return result;
        }
        throw new ArgumentException("HslString format is invalid");
    }


    public static bool TryParse(string hslString, out HslColor hslColor)
    {
        hslColor = default;

        if (string.IsNullOrWhiteSpace(hslString)) { return false; }

        var splitList = hslString.Split(",").ToList();
        List<int> parseList = new List<int>();

        if (splitList.Count != 3) { return false; }

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
      return Hue == other.Hue && Saturation == other.Saturation && Lightness == other.Lightness;
    }


    public override bool Equals(object? obj)
    {
        return obj is HslColor other && Equals(other);
    }


    public override int GetHashCode()
    {
        return HashCode.Combine(Hue, Saturation, Lightness);
    }


    public override string ToString()
    {
        return $"{Hue},{Saturation},{Lightness}";
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
