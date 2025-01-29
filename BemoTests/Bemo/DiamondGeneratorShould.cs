using FluentAssertions;

namespace Bemo;

public class DiamondGeneratorShould
{
    private string _actualDiamond;

    [Fact]
    public void GenerateDiamondForA()
    {
        WhenGerenateDiamondForCharacter('A').
            DiamondShouldLooksLike("A");
    }

    [Fact]
    public void GenerateDiamondForB()
    {
        WhenGerenateDiamondForCharacter('B').
            DiamondShouldLooksLike(
@" A
B B
 A
");
    }

    [Fact]
    public void GenerateDiamondForC()
    {
        WhenGerenateDiamondForCharacter('C').
            DiamondShouldLooksLike(
                @"  A
 B B
C   C
 B B
  A
");
    }

    [Fact]
    public void GenerateDiamondForD()
    {
        WhenGerenateDiamondForCharacter('D').
            DiamondShouldLooksLike(
                @"   A
  B B
 C   C
D     D
 C   C
  B B
   A
");
    }

    [Fact]
    public void GenerateDiamondForE()
    {
        WhenGerenateDiamondForCharacter('E').
            DiamondShouldLooksLike(
                @"    A
   B B
  C   C
 D     D
E       E
 D     D
  C   C
   B B
    A
");
    }

    [Fact]
    public void GenerateDiamondForF()
    {
        WhenGerenateDiamondForCharacter('F').
            DiamondShouldLooksLike(
                @"     A
    B B
   C   C
  D     D
 E       E
F         F
 E       E
  D     D
   C   C
    B B
     A
");
    }

    private void DiamondShouldLooksLike(string expectedDiamond)
    {
        _actualDiamond.Should().Be(expectedDiamond);
    }

    private DiamondGeneratorShould WhenGerenateDiamondForCharacter(char diamondLetter)
    {
        _actualDiamond = DiamondGenerator.For(diamondLetter);
        return this;
    }
}