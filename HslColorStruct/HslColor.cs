using System.Globalization;

namespace HslColorStruct;

/// <summary>
/// Represents a color in the HSL color model.
/// </summary>
public readonly struct HslColor : IEquatable<HslColor>
{
    private readonly double hue;
    private readonly double saturation;
    private readonly double lightness;

    /// <summary>
    /// Initializes a new instance of the <see cref="HslColor"/> struct with the specified <paramref name="hue"/>, <paramref name="saturation"/> and <paramref name="lightness"/>.
    /// </summary>
    /// <param name="hue">The hue component (0-360 degrees).</param>
    /// <param name="saturation">The saturation component (0-100%).</param>
    /// <param name="lightness">The lightness component (0-100%).</param>
    public HslColor(double hue, double saturation, double lightness)
    {
        this.hue = hue;
        this.saturation = saturation;
        this.lightness = lightness;
    }

    /// <summary>
    /// Gets the hue component (0-360 degrees).
    /// </summary>
    public double Hue => this.hue;

    /// <summary>
    /// Gets the saturation component (0-100%).
    /// </summary>
    public double Saturation => this.saturation;

    /// <summary>
    /// Gets the lightness component (0-100%).
    /// </summary>
    public double Lightness => this.lightness;

    /// <summary>
    /// Creates a new instance of the <see cref="HslColor"/> struct with specified <paramref name="hue"/>, <paramref name="saturation"/> and <paramref name="lightness"/>.
    /// </summary>
    /// <param name="hue">The hue component (0-360 degrees).</param>
    /// <param name="saturation">The saturation component (0-100%).</param>
    /// <param name="lightness">The lightness component (0-100%).</param>
    /// <returns>A <see cref="HslColor"/> that is initialized with specified components.</returns>
    public static HslColor Create(double hue, double saturation, double lightness)
    {
        ThrowExceptionIfValueIsNotValid(hue, nameof(hue), 0, 360);
        ThrowExceptionIfValueIsNotValid(saturation, nameof(saturation), 0, 100);
        ThrowExceptionIfValueIsNotValid(lightness, nameof(lightness), 0, 100);

        return new HslColor(hue, saturation, lightness);
    }

    /// <summary>
    /// Converts the string representation of a color to its <see cref="HslColor"/> equivalent.
    /// </summary>
    /// <param name="hslString">A string containing a color to convert in format "H,S,L".</param>
    /// <returns>An <see cref="HslColor"/> equivalent to the color contained in <paramref name="hslString"/>.</returns>
    public static HslColor Parse(string hslString)
    {
        if (string.IsNullOrWhiteSpace(hslString))
        {
            throw new ArgumentException("Invalid HSL string format", nameof(hslString));
        }

        string[] components = hslString.Split(',');
        if (components.Length != 3)
        {
            throw new ArgumentException("Invalid HSL string format", nameof(hslString));
        }

        if (!double.TryParse(components[0], NumberStyles.Any, CultureInfo.InvariantCulture, out double hue) ||
            !double.TryParse(components[1], NumberStyles.Any, CultureInfo.InvariantCulture, out double saturation) ||
            !double.TryParse(components[2], NumberStyles.Any, CultureInfo.InvariantCulture, out double lightness))
        {
            throw new ArgumentException("Invalid HSL string format", nameof(hslString));
        }

        return Create(hue, saturation, lightness);
    }

    /// <summary>
    /// Converts the string representation of a color to its <see cref="HslColor"/> equivalent. A return value indicates whether the operation succeeded.
    /// </summary>
    /// <param name="hslString">A string containing a color to convert in format "H,S,L".</param>
    /// <param name="hslColor">A <see cref="HslColor"/> equivalent to the color contained in <paramref name="hslString"/>.</param>
    /// <returns>true if <paramref name="hslString"/> was converted successfully; otherwise, false.</returns>
    public static bool TryParse(string hslString, out HslColor hslColor)
    {
        hslColor = default;

        if (string.IsNullOrWhiteSpace(hslString))
        {
            return false;
        }

        string[] components = hslString.Split(',');
        if (components.Length != 3)
        {
            return false;
        }

        if (!double.TryParse(components[0], NumberStyles.Any, CultureInfo.InvariantCulture, out double hue) ||
            !double.TryParse(components[1], NumberStyles.Any, CultureInfo.InvariantCulture, out double saturation) ||
            !double.TryParse(components[2], NumberStyles.Any, CultureInfo.InvariantCulture, out double lightness))
        {
            return false;
        }

        try
        {
            hslColor = Create(hue, saturation, lightness);
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Determines whether the specified <see cref="HslColor"/> is equal to the current <see cref="HslColor"/>.
    /// </summary>
    /// <param name="other">The <see cref="HslColor"/> to compare with the current <see cref="HslColor"/>.</param>
    /// <returns>true if the specified <see cref="HslColor"/> is equal to the current <see cref="HslColor"/>; otherwise, false.</returns>
    public bool Equals(HslColor other)
    {
        return Math.Abs(this.hue - other.hue) < double.Epsilon &&
               Math.Abs(this.saturation - other.saturation) < double.Epsilon &&
               Math.Abs(this.lightness - other.lightness) < double.Epsilon;
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current <see cref="HslColor"/>.
    /// </summary>
    /// <param name="obj">The object to compare with the current <see cref="HslColor"/>.</param>
    /// <returns>true if the specified object is equal to the current <see cref="HslColor"/>; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        return obj is HslColor other && this.Equals(other);
    }

    /// <summary>
    /// Gets a hash code of the current <see cref="HslColor"/>.
    /// </summary>
    /// <returns>A hash code of the current <see cref="HslColor"/>.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(this.hue, this.saturation, this.lightness);
    }

    /// <summary>
    /// Returns a string that represents the current <see cref="HslColor"/>.
    /// </summary>
    /// <returns>A string that represents the current <see cref="HslColor"/>.</returns>
    public override string ToString()
    {
        return $"{this.hue:F2},{this.saturation:F2},{this.lightness:F2}";
    }

    /// <summary>
    /// Compares <paramref name="left"/> and <paramref name="right"/> objects. Returns true if the left <see cref="HslColor"/> is equal to the right <see cref="HslColor"/>; otherwise, false.
    /// </summary>
    /// <param name="left">A left <see cref="HslColor"/>.</param>
    /// <param name="right">A right <see cref="HslColor"/>.</param>
    /// <returns>true if the left <see cref="HslColor"/> is equal to the right <see cref="HslColor"/>; otherwise, false.</returns>
    public static bool operator ==(HslColor left, HslColor right) => left.Equals(right);

    /// <summary>
    /// Compares <paramref name="left"/> and <paramref name="right"/> objects. Returns true if the left <see cref="HslColor"/> is not equal to the right <see cref="HslColor"/>; otherwise, false.
    /// </summary>
    /// <param name="left">A left <see cref="HslColor"/>.</param>
    /// <param name="right">A right <see cref="HslColor"/>.</param>
    /// <returns>true if the left <see cref="HslColor"/> is not equal to the right <see cref="HslColor"/>; otherwise, false.</returns>
    public static bool operator !=(HslColor left, HslColor right) => !left.Equals(right);

    private static void ThrowExceptionIfValueIsNotValid(double value, string parameterName, double minValue, double maxValue)
    {
        if (value < minValue || value > maxValue)
        {
            throw new ArgumentException($"Value must be between {minValue} and {maxValue}", parameterName);
        }
    }
}
