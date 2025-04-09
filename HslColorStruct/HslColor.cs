namespace HslColorStruct;

/// <summary>
/// Represents a color in the HSL color model.
/// </summary>
public readonly struct HslColor : IEquatable<HslColor>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HslColor"/> struct with the specified <paramref name="hue"/>, <paramref name="saturation"/> and <paramref name="lightness"/>.
    /// </summary>
    /// <param name="hue">The hue component (0-360 degrees).</param>
    /// <param name="saturation">The saturation component (0-100%).</param>
    /// <param name="lightness">The lightness component (0-100%).</param>
    /// <exception cref="ArgumentException">Thrown when any of the components is outside its valid range.</exception>
    public HslColor(int hue, int saturation, int lightness)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the hue component (0-360 degrees).
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when value is outside the valid range (0-360).</exception>
    public int Hue
    {
        get => throw new NotImplementedException();
        init => throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the saturation component (0-100%).
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when value is outside the valid range (0-100).</exception>
    public int Saturation
    {
        get => throw new NotImplementedException();
        init => throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the lightness component (0-100%).
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when value is outside the valid range (0-100).</exception>
    public int Lightness
    {
        get => throw new NotImplementedException();
        init => throw new NotImplementedException();
    }

    /// <summary>
    /// Creates a new instance of the <see cref="HslColor"/> struct with specified <paramref name="hue"/>, <paramref name="saturation"/> and <paramref name="lightness"/>.
    /// </summary>
    /// <param name="hue">The hue component (0-360 degrees).</param>
    /// <param name="saturation">The saturation component (0-100%).</param>
    /// <param name="lightness">The lightness component (0-100%).</param>
    /// <returns>A <see cref="HslColor"/> that is initialized with specified components.</returns>
    /// <exception cref="ArgumentException">Thrown when any of the components is outside its valid range.</exception>
    public static HslColor Create(int hue, int saturation, int lightness)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Converts the string representation of a color to its <see cref="HslColor"/> equivalent.
    /// </summary>
    /// <param name="hslString">A string containing a color to convert in format "H,S,L".</param>
    /// <returns>An <see cref="HslColor"/> equivalent to the color contained in <paramref name="hslString"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="hslString"/> is invalid.</exception>
    public static HslColor Parse(string hslString)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Converts the string representation of a color to its <see cref="HslColor"/> equivalent. A return value indicates whether the operation succeeded.
    /// </summary>
    /// <param name="hslString">A string containing a color to convert in format "H,S,L".</param>
    /// <param name="hslColor">A <see cref="HslColor"/> equivalent to the color contained in <paramref name="hslString"/>.</param>
    /// <returns>true if <paramref name="hslString"/> was converted successfully; otherwise, false.</returns>
    public static bool TryParse(string hslString, out HslColor hslColor)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Determines whether the specified <see cref="HslColor"/> is equal to the current <see cref="HslColor"/>.
    /// </summary>
    /// <param name="other">The <see cref="HslColor"/> to compare with the current <see cref="HslColor"/>.</param>
    /// <returns>true if the specified <see cref="HslColor"/> is equal to the current <see cref="HslColor"/>; otherwise, false.</returns>
    public bool Equals(HslColor other)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current <see cref="HslColor"/>.
    /// </summary>
    /// <param name="obj">The object to compare with the current <see cref="HslColor"/>.</param>
    /// <returns>true if the specified object is equal to the current <see cref="HslColor"/>; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a hash code of the current <see cref="HslColor"/>.
    /// </summary>
    /// <returns>A hash code of the current <see cref="HslColor"/>.</returns>
    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns a string that represents the current <see cref="HslColor"/>.
    /// </summary>
    /// <returns>A string that represents the current <see cref="HslColor"/>.</returns>
    public override string ToString()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Compares <paramref name="left"/> and <paramref name="right"/> objects. Returns true if the left <see cref="HslColor"/> is equal to the right <see cref="HslColor"/>; otherwise, false.
    /// </summary>
    /// <param name="left">A left <see cref="HslColor"/>.</param>
    /// <param name="right">A right <see cref="HslColor"/>.</param>
    /// <returns>true if the left <see cref="HslColor"/> is equal to the right <see cref="HslColor"/>; otherwise, false.</returns>
    public static bool operator ==(HslColor left, HslColor right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Compares <paramref name="left"/> and <paramref name="right"/> objects. Returns true if the left <see cref="HslColor"/> is not equal to the right <see cref="HslColor"/>; otherwise, false.
    /// </summary>
    /// <param name="left">A left <see cref="HslColor"/>.</param>
    /// <param name="right">A right <see cref="HslColor"/>.</param>
    /// <returns>true if the left <see cref="HslColor"/> is not equal to the right <see cref="HslColor"/>; otherwise, false.</returns>
    public static bool operator !=(HslColor left, HslColor right)
    {
        throw new NotImplementedException();
    }

    private static void ThrowExceptionIfValueIsNotValid(int value, string parameterName, int minValue, int maxValue)
    {
        throw new NotImplementedException();
    }
}
