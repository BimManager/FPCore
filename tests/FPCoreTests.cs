using System;

using NUnit.Framework;

namespace FPCore {
  [TestFixture]
  public class FPCoreTests {
    [Test]
    public void TestNone_ItIsDefined_NotNull() {
    }

    [Test]
    public void TestSome_ItIsDefined_NotNull() {
      Option<String> some = "foo";
      Assert.NotNull(some);
    }

    [Test]
    public void Option_NullInput_ProperHandling() {
      Assert.AreEqual("Sorry, who?", greet(null));
    }

    [Test]
    public void Option_NotNullInput_PropertHandling() {
      Assert.AreEqual("Hello, John!", greet("John"));
    }

    [Test]
    public void ParseInt_NullInput_ProperHandling() {
      var result = ParseInt(null)
          .Match<String>(
              None: () => "Parsing failed",
              Some: (num) => num.ToString());
      Assert.AreEqual("Parsing failed", result);
    }

    String greet(Option<String> greetee)
    => greetee.Match(
        None: () => "Sorry, who?",
        Some: (name) => $"Hello, {name}!");

    Option<Int32> ParseInt(String num) {
      Int32 res;
      return Int32.TryParse(num, out res) ? res : Option<Int32>.None;
    }
  }
}
