namespace CSharp9.LearningTests
{
    public class IdeSettings
    {
        public WhitespaceCharacter WhitespaceCharacter { get; set; }

        public int EditorScaling { get; set; } = 100;
        
        public string FontFamily { get; set; } = "Consolas";

        public int FontSize { get; set; } = 16;
    }

    public sealed class InitSetterTests
    {
        /* Whitespace
        [Fact]
        public void Should_Be_Politically_Correct()
        {
            var settings = new IdeSettings
            {
                FontFamily = "Fira Code",
                FontSize = 18
            };

            settings.WhitespaceCharacter.Should().Be(WhitespaceCharacter.Space);
            settings.FontFamily.Should().Be("Fira Code");
            settings.FontSize.Should().Be(18);
        }
        */
        
        /* Immutability
        [Fact]
        public void Settings_Should_Be_Immutable()
        {
            var settings = new IdeSettings(WhitespaceCharacter.Tab)
            {
                EditorScaling = 121
            };
            
            settings.EditorScaling = 100;
        
            settings.EditorScaling.Should().Be(121);
        }
        */
        
        /* Editor Scaling
        [Theory]
        [InlineData(24)]
        [InlineData(301)]
        public void EditorScaling_Should_Only_Be_Between_25_And_300(int editorScaling)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _ = new IdeSettings(WhitespaceCharacter.Space)
                {
                    EditorScaling = editorScaling
                };
            });
        }
        */
        
        /* VisualStudioSettings 125
        [Fact]
        public void Can_Change_VisualStudio_Defaults()
        {
            var defaultSettings = new VisualStudioSettings();
            var settingsWithDecreasedScaling = new VisualStudioSettings
            {
                EditorScaling = 100
            };
        
            defaultSettings.EditorScaling.Should().Be(125);
            settingsWithDecreasedScaling.EditorScaling.Should().Be(100);
        }
        */
    }
}