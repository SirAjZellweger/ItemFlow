using ItemFlow.Domain.Items;

using Xunit;

namespace ItemFlow.Domain.Tests;

public class ItemTests
{
    [Fact]
    public void Create_ReturnsItem_WhenNameIsNotEmpty()
    {
        // Arrange
        var nonEmptyName = "Test Name";
        var description = "Test Beschreibung";

        // Act
        var item = Item.Create(nonEmptyName, description);

        //Assert
        Assert.Equal(nonEmptyName, item.Name);
        Assert.Equal(description, item.Description);
        Assert.NotEqual(Guid.Empty, item.Id);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void Create_Throws_WhenNameIsEmpty(string badName)
    {
        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => Item.Create(badName));
    }
}
