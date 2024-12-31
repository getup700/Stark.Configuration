namespace Stark.Configuration.Test;

public class Tests
{
    private IConfiguration _configuration;
    [SetUp]
    public void SetUp()
    {
        _configuration = ConfigHelper.InitialConfiguration();
    }

    [Test]
    public void Get()
    {
        var value = _configuration["appname"];

        Assert.That(value, Is.EqualTo("stark"));
    }

    [Test]
    public void GetComplex()
    {
        var value = _configuration["details:company"];

        Assert.That(value, Is.EqualTo("tony stark"));
    }

    [Test]
    public void GetChildren()
    {
        var value = _configuration.GetChildren();

        Assert.That(value.Count(), Is.EqualTo(5));
    }







}