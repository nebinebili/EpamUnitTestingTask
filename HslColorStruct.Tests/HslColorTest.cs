namespace HslColorStruct.Tests;

[TestFixture]
public class HslColorTests
{
    private HslColor _hslColor;

    [SetUp]
    public void Setup()
    {
        _hslColor = new HslColor(120,50,70);
    }

    [Test]
    public void Hue_Getter_ReturnsCorrectValues()
    {
        Assert.That(_hslColor.Hue, Is.EqualTo(120));
    }
    [Test]
    public void Saturationue_Getter_ReturnsCorrectValues()
    {
        Assert.That(_hslColor.Saturation, Is.EqualTo(50));
    }
    [Test]
    public void Lightness_Getter_ReturnsCorrectValues()
    {
        Assert.That(_hslColor.Lightness, Is.EqualTo(70));
    }

    [Test]
    public void Constructor_WithValidValues_CreatesColor()
    {
        int hue = 120;
        int saturation = 50;
        int lightness = 75;

        var color = new HslColor(hue, saturation, lightness);

        Assert.That(color.Hue, Is.EqualTo(hue));
        Assert.That(color.Saturation, Is.EqualTo(saturation));
        Assert.That(color.Lightness, Is.EqualTo(lightness));
    }


    [TestCase(500,40,70)]
    [TestCase(120,180,70)]
    [TestCase(-895,60,70)]
    [TestCase(10,60,280)]
    public void Constructor_WithInValidValues_ThrowArgumentException(int hue, int saturation, int lightness)
    {

        // Assert
        Assert.Throws<ArgumentException>(() => new HslColor(hue, saturation, lightness));

    }


    [Test]
    public void Create_WithValidValues_ReturnsCorrectColor()
    {
        int hue = 120;
        int saturation = 50;
        int lightness = 75;

        var color = new HslColor(hue, saturation, lightness);

        Assert.That(color.Hue, Is.EqualTo(hue));
        Assert.That(color.Saturation, Is.EqualTo(saturation));
        Assert.That(color.Lightness, Is.EqualTo(lightness));
    }

    [TestCase(500, 40, 70)]
    [TestCase(120, 180, 70)]
    [TestCase(120, 50, 150)]
    public void Create_WithInvalidValues_ThrowsArgumentException(int hue, int saturation, int lightness)
    {
        Assert.Throws<ArgumentException>(() => HslColor.Create(hue, saturation, lightness));
    }


    [Test]
    public void Parse_WithValidString_ReturnsColor()
    {

        string hslString = "120,50,75";

        var color = HslColor.Parse(hslString);

        Assert.That(color.Hue, Is.EqualTo(120));
        Assert.That(color.Saturation, Is.EqualTo(50));
        Assert.That(color.Lightness, Is.EqualTo(75));
    }

    [TestCase("Hello")]
    [TestCase("12,12321")]
    [TestCase("-12,100,40")]
    [TestCase(" ")]
    public void Parse_WithInValidString_ThrowArgumentException( string hslString)
    {
        Assert.Throws<ArgumentException>(() => HslColor.Parse(hslString));
    }

    [Test]
    public void TryParse_WithValidParametr_ReturnTrue()
    {
        string hslString = "300,50,30";

        bool result = HslColor.TryParse(hslString, out HslColor color);

        Assert.That(result,Is.EqualTo(true));
    }

    [TestCase("hello")]
    [TestCase("120,abc,75")]
    [TestCase("120,50")]
    [TestCase("120,50,75,20")]
    public void TryParse_WithInValidString_ReturnFalse(string hslString)
    {

        bool result = HslColor.TryParse(hslString, out HslColor color);

        Assert.That(result, Is.EqualTo(false));
    }

    [TestCase("500,50,75")]
    [TestCase("120,150,75")]
    [TestCase("120,50,150")]
    [TestCase("-10,50,75")]
    public void TryParse_WithOutOfRangeValues_ReturnFalse(string hslString)
    {
        bool result = HslColor.TryParse(hslString, out HslColor color);

        Assert.That(result, Is.EqualTo(false));
    }

    [Test]
    public void TryParse_WithNull_ReturnsFalse()
    {
        bool result = HslColor.TryParse(null, out HslColor color);

        Assert.That(result, Is.False);
    }

    [Test]
    public void Equals_WithSameValues_ReturnTrue()
    {
        var color1 = new HslColor(120, 50, 70);

        var color2 = new HslColor(120, 50, 70);

        bool result=color1.Equals(color2);

        Assert.That(result, Is.True);
    }

    [TestCase(121, 50, 75)]
    [TestCase(120, 51, 75)]
    [TestCase(120, 50, 76)]
    public void Equals_WithDifferentValues_ReturnFalse(int hue, int saturation, int lightness)
    {
        var color1 = new HslColor(120, 50, 70);

        var color2 = new HslColor(hue,saturation,lightness);

        bool result = color1.Equals(color2);

        Assert.That(result, Is.False);
    }

    [Test]
    public void Equals_WithObjectOfSameColor_ReturnTrue()
    {
        var color1 = new HslColor(120, 50, 70);

        object color2 = new HslColor(120, 50, 70);

        bool result = color1.Equals(color2);

        Assert.That(result, Is.True);
    }

    [Test]
    public void Equals_WithObjectOfSameColor_ReturnFalse()
    {
        var color1 = new HslColor(120, 50, 70);

        object other = "120,50,70";

        bool result = color1.Equals(other);

        Assert.That(result, Is.False);
    }

    [Test]
    public void Equals_WithNull_ReturnsFalse()
    {
        var color = new HslColor(120, 50, 75);

        Assert.That(color.Equals(null), Is.False);
    }

    [Test]
    public void ToString_ReturnCorrectHslStringFormat()
    {
        var color = new HslColor(120, 50, 75);

        var hslString= color.ToString();

        Assert.That(hslString, Is.EqualTo("120,50,75"));
    }

    [Test]
    public void GetHashCode_ReturnSameHashCode_ForSEqualColor()
    {
        var color1 = new HslColor(120, 50, 70);

        var color2 = new HslColor(120, 50, 70);

        int hash1=color1.Hue.GetHashCode();

        int hash2=color2.Hue.GetHashCode();

        Assert.That(hash1, Is.EqualTo(hash2));
    }
}
