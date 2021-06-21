using NUnit.Framework;

public class HeroRepositoryTests
{
    //Arrange
    private HeroRepository heroRepository;

    [SetUp]
    public void SetUp()
    {
        heroRepository = new HeroRepository();
    }

    [Test]
    public void CreateMethodShouldThrowExceptionIfHeroIsNull()
    {
        //Act & Assert
        Assert.That(() => heroRepository.Create(null),
            Throws.ArgumentNullException);
    }

    [Test]
    public void CreateMethodShouldThrowExceptionIfHeroExists()
    {
        //Arrange
        var countOfHeroToAdd = 2;
        this.AddHerosToRepository(countOfHeroToAdd);
        var alreadyAddedHero = new Hero("Test1", 20);

        //Act & Assert
        Assert.That(() => heroRepository.Create(alreadyAddedHero),
            Throws.InvalidOperationException
            .With.Message.EqualTo($"Hero with name {alreadyAddedHero.Name} already exists"));
    }

    [Test]
    public void CreateMethodShouldReturnMessageIfOperationWasSuccessfull()
    {
        //Arrange
        var heroToAdd = new Hero("Test1", 20);
        var expectedMessage = $"Successfully added hero {heroToAdd.Name} with level {heroToAdd.Level}";

        //Act
        var actualMessage = this.heroRepository.Create(heroToAdd);

        //Assert
        Assert.That(this.heroRepository.Heroes.Count, Is.EqualTo(1));
        Assert.That(actualMessage, Is.EqualTo(expectedMessage));
    }

    [Test]
    public void RemoveMethodShouldThrowExceptionIfHeroIsNull()
    {
        //Act & Assert
        Assert.That(() => heroRepository.Remove(null),
            Throws.ArgumentNullException);
    }

    [Test]
    public void RemoveMethodShouldReturnFalseIfOperationFailed()
    {
        //Arrange
        var countOfHerosToAdd = 10;
        this.AddHerosToRepository(countOfHerosToAdd);
        var heroNameToRemove = "Test11";

        //Act
        var isFalse = this.heroRepository.Remove(heroNameToRemove);

        //Assert
        Assert.That(isFalse, Is.EqualTo(false));
    }

    [Test]
    public void RemoveMethodShouldReturnTrueIfOperationFailed()
    {
        //Arrange
        var countOfHerosToAdd = 10;
        var expectedCountAfterRemoval = 9;
        this.AddHerosToRepository(countOfHerosToAdd);
        var heroNameToRemove = "Test5";

        //Assert
        Assert.That(this.heroRepository.Heroes.Count, Is.EqualTo(countOfHerosToAdd));

        //Act
        var isTrue = this.heroRepository.Remove(heroNameToRemove);

        //Assert
        Assert.That(this.heroRepository.Heroes.Count, Is.EqualTo(expectedCountAfterRemoval));
        Assert.That(isTrue, Is.EqualTo(true));
    }

    [Test]
    public void GetHeroWithHighestLevelShouldReturnTheHighestLevel()
    {
        //Arrange
        var countOfHerosToAdd = 10;
        this.AddHerosToRepository(countOfHerosToAdd);
        var expectedName = "Test10";
        var expectedLevel = 29;

        //Act
        var expectedHero = this.heroRepository.GetHeroWithHighestLevel();

        //Assert
        Assert.That(expectedHero.Name, Is.EqualTo(expectedName));
        Assert.That(expectedHero.Level, Is.EqualTo(expectedLevel));
    }

    [Test]
    public void GetHeroShouldReturnNullIfNothingIsFound()
    {
        //Arrange
        var countOfHerosToAdd = 10;
        this.AddHerosToRepository(countOfHerosToAdd);
        var nameToSearch = "Test100";
        var expectedResult = (string)null;

        //Act
        var expectedHero = this.heroRepository.GetHero(nameToSearch);

        //Assert
        Assert.That(expectedHero, Is.EqualTo(expectedResult));
    }

    [Test]
    public void GetHeroShouldReturnHeroByName()
    {
        //Arrange
        var countOfHerosToAdd = 10;
        this.AddHerosToRepository(countOfHerosToAdd);
        var nameToSearch = "Test5";
        var expectedLevel = 24;

        //Act
        var expectedHero = this.heroRepository.GetHero(nameToSearch);

        //Assert
        Assert.That(expectedHero.Name, Is.EqualTo(nameToSearch));
        Assert.That(expectedHero.Level, Is.EqualTo(expectedLevel));
    }

    private void AddHerosToRepository(int count)
    {
        for (int i = 0; i < count; i++)
        {
            this.heroRepository.Create(new Hero($"Test{i + 1}", 20 + i));
        }
    }
}