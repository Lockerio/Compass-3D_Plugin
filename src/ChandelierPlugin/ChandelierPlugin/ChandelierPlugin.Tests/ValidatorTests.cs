using NUnit.Framework;
using ChandelierPlugin.Model;
using System;

[TestFixture]
public class ValidatorTests
{
    [TestCase(5.0, 1.0, 10.0)]
    [TestCase(7.5, 5.0, 10.0)]
    public void ValidateRange_ShouldNotThrowException(
        double value,
        double minValue,
        double maxValue)
    {
        // Act, Assert
        Assert.DoesNotThrow(() =>
            Validator.ValidateRange(value, minValue, maxValue));
    }

    [TestCase(5.0, 10.0, 1.0)]
    [TestCase(7.5, 10.0, 5.0)]
    public void ValidateRange_ShouldThrowArgumentException(
        double value,
        double minValue,
        double maxValue)
    {
        // Act, Assert
        Assert.Throws<ArgumentException>(() =>
            Validator.ValidateRange(value, minValue, maxValue));
    }

    [TestCase(5.0, 10.0)]
    [TestCase(0.5, 5.0)]
    public void ValidateMinMax_ShouldNotThrowException(
        double minValue,
        double maxValue)
    {
        // Act, Assert
        Assert.DoesNotThrow(() =>
            Validator.ValidateMinMax(minValue, maxValue));
    }

    [TestCase(5.0, 1.0)]
    [TestCase(8, 7.5)]
    public void ValidateMinMax_ShouldThrowArgumentException(
        double minValue,
        double maxValue)
    {
        // Act, Assert
        Assert.Throws<ArgumentException>(() =>
            Validator.ValidateMinMax(minValue, maxValue));
    }

    [TestCase(5.0)]
    [TestCase(7.5)]
    public void ValidateNonNegative_ShouldNotThrowException(double value)
    {
        // Act, Assert
        Assert.DoesNotThrow(() => Validator.ValidateNonNegative(value));
    }

    [TestCase(-5.0)]
    [TestCase(0)]
    public void ValidateNonNegative_ShouldThrowArgumentException(
        double value)
    {
        // Act, Assert
        Assert.Throws<ArgumentException>(() =>
            Validator.ValidateNonNegative(value));
    }

    [TestCase(5.0, 1.0, 10.0)]
    [TestCase(7.5, 5.0, 10.0)]
    public void AssertNumberIsInRange_ShouldNotThrowException(
        double value,
        double minValue,
        double maxValue)
    {
        // Act, Assert
        Assert.DoesNotThrow(() =>
            Validator.AssertNumberIsInRange(value, minValue, maxValue));
    }

    [TestCase(5.0, 10.0, 1.0)]
    [TestCase(7.5, 10.0, 5.0)]
    public void AssertNumberIsInRange_ShouldThrowException(
        double value,
        double minValue,
        double maxValue)
    {
        // Act, Assert
        Assert.Throws<ArgumentException>(() =>
            Validator.AssertNumberIsInRange(value, minValue, maxValue));
    }
}