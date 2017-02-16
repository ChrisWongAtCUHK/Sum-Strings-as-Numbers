using System;
using NUnit.Framework;

[TestFixture]
public class CodeWarsTest
{
    [Test]
    public void Given123And456Returns579()
    {
        Assert.AreEqual("8670", Kata.sumStrings("00103", "08567"));
    }
}

