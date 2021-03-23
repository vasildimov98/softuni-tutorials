namespace SUS.MVC.Tests
{
    using Xunit;

    using System;
    using System.IO;

    using ViewEngine;
    using System.Collections.Generic;

    public class ViewEngineTests
    {
        [Theory]
        [InlineData("CleanHtml")]
        [InlineData("Foreach")]
        [InlineData("ForIfElse")]
        [InlineData("ViewModel")]
        public void TestIfViewEngineGenerateCleanHtmlWithGivenTemplate(string filePath)
        {
            var template = File.ReadAllText($"TemplateTests/{filePath}.html");
            var expected = File.ReadAllText($"TemplateTests/{filePath}.Result.html");

            var viewModel = new TestViewModel
            {
                Name = "TestName",
                Price = 12345.20M,
                DateOfBirth = new DateTime(2020, 2, 7)
            };

            var viewEngine = new SusViewEngine();

            var actual = viewEngine.GetHtml(template, viewModel);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestTemplateViewModel()
        {
            var template = File.ReadAllText(@"TemplateTests\TemplateViewModel.html");
            var expected = File.ReadAllText(@"TemplateTests\TemplateViewModel.Result.html");

            var viewModel = new List<int> { 1, 2, 3, 4, 5 };

            var viewEngine = new SusViewEngine();

            var actual = viewEngine.GetHtml(template, viewModel);

            Assert.Equal(expected, actual);
        }
    }
}
