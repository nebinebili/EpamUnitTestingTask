# HSL Color Struct Testing

Beginner level task for practicing unit testing.

Estimated time to complete the task - 2h.

The task requires .NET 8 SDK installed.

## Task Description

Implement a comprehensive test suite for the existing `HslColor` structure that represents a color in the HSL (Hue, Saturation, Lightness) color model. The structure is already implemented and provides functionality for creating, parsing, and comparing HSL colors.

### Requirements

1. Create unit tests for the following functionality:
   - Constructor validation
   - Property getters (Hue, Saturation, Lightness)
   - Static `Create` method with parameter validation
   - `Parse` method for converting string to HslColor
   - `TryParse` method for safe string conversion
   - Equality comparison methods (`Equals`, `==`, `!=`)
   - `GetHashCode` method
   - `ToString` method

2. Test cases should cover:
   - Valid input values
   - Invalid input values (out of range)
   - Edge cases
   - Null values where applicable
   - String parsing edge cases
   - Equality comparison edge cases
   - Hash code distribution

3. Test naming should follow the Arrange-Act-Assert pattern and be descriptive.

4. Use appropriate assertion methods to verify:
   - Expected values
   - Exception throwing
   - Object equality
   - String formatting

### Implementation Notes

The `HslColor` structure is already implemented with the following characteristics:
- Immutable and readonly struct
- Hue range: 0-360 degrees
- Saturation range: 0-100%
- Lightness range: 0-100%
- String format: "H,S,L" with two decimal places
- Equality comparison uses double.Epsilon for floating-point comparison

### Example Test Cases

```csharp
// Constructor validation
[Test]
public void Constructor_WithValidValues_CreatesColor()
{
    // Arrange
    double hue = 120;
    double saturation = 50;
    double lightness = 75;

    // Act
    var color = new HslColor(hue, saturation, lightness);

    // Assert
    Assert.That(color.Hue, Is.EqualTo(hue));
    Assert.That(color.Saturation, Is.EqualTo(saturation));
    Assert.That(color.Lightness, Is.EqualTo(lightness));
}

// String parsing
[Test]
public void Parse_WithValidString_ReturnsColor()
{
    // Arrange
    string hslString = "120.00,50.00,75.00";

    // Act
    var color = HslColor.Parse(hslString);

    // Assert
    Assert.That(color.Hue, Is.EqualTo(120));
    Assert.That(color.Saturation, Is.EqualTo(50));
    Assert.That(color.Lightness, Is.EqualTo(75));
}
```

### Additional Requirements

1. Create a test project using xUnit testing framework
2. Ensure test coverage is comprehensive
3. Include XML documentation for test methods
4. Follow SOLID principles in test organization
5. Use appropriate test categories and attributes
6. Implement test data using appropriate patterns (e.g., Theory, InlineData)

### Deliverables

1. Complete test project with all required test cases
2. Documentation of test coverage
3. Any additional test utilities or helper methods
4. Updated README with test execution instructions

### Project Setup

1. Create a new xUnit test project in the solution
2. Add a reference to the `HslColorStruct` project
3. Implement test classes following the structure of the `HslColor` implementation
4. Run tests using `dotnet test` command
