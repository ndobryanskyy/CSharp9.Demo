using System;
using FluentAssertions;
using Xunit;

namespace CSharp9.LearningTests
{
    public class IdeSettings
    {
        private readonly int _editorScaling = 100;

        public IdeSettings(WhitespaceCharacter whitespaceCharacter)
        {
            WhitespaceCharacter = whitespaceCharacter;
        }

        public WhitespaceCharacter WhitespaceCharacter { get; }

        public int EditorScaling
        {
            get => _editorScaling;
            init
            {
                if (value < 25)
                {
                    throw new ArgumentException();
                }

                if (value > 300)
                {
                    throw new ArgumentException();
                }

                _editorScaling = value;
            }
        }

        public string FontFamily { get; init; } = "Consolas";

        public int FontSize { get; init; } = 16;
    }

    public sealed class VisualStudioSettings : IdeSettings
    {
        public VisualStudioSettings()
            : base(WhitespaceCharacter.Tab)
        {
            EditorScaling = 125;
        }
    }

    public sealed class InitSetterTests
    {
        [Fact]
        public void Should_Be_Politically_Correct()
        {
            var settings = new IdeSettings(WhitespaceCharacter.Space)
            {
                FontFamily = "Fira Code",
                FontSize = 18,
            };

            settings.WhitespaceCharacter.Should().Be(WhitespaceCharacter.Space);
            settings.FontFamily.Should().Be("Fira Code");
            settings.FontSize.Should().Be(18);
        }
        
        [Fact]
        public void Settings_Should_Be_Immutable()
        {
            var settings = new IdeSettings(WhitespaceCharacter.Tab)
            {
                EditorScaling = 121
            };
            
            // Does not compile
            // settings.EditorScaling = 100;
        
            settings.EditorScaling.Should().Be(121);
        }
        
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
    }
}