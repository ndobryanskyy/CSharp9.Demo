using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace CSharp9.LearningTests
{
    public sealed class RiderSettings : IdeSettings
    {
        public RiderSettings() 
            : base(WhitespaceCharacter.Space)
        {
        }
    
        public List<FontSettings> SupportedFonts { get; } = new();
    
        public Dictionary<string, string> Registry { get; } = new();
    }

    public sealed class TargetNewTests
    {
        [Fact]
        public void Should_Infer_Type_For_Property_With_NonAbstract_Type()
        {
            var settings = new RiderSettings();

            settings.SupportedFonts.Should().NotBeNull();
            settings.SupportedFonts.Should().BeOfType<List<FontSettings>>();

            settings.Registry.Should().NotBeNull();
            settings.Registry.Should().BeOfType<Dictionary<string, string>>();
        }
        
        [Fact]
        public void Should_Infer_Type_For_Ternary_Operator()
        {
            static IdeSettings CreateSettings(bool isCrossPlatform)
                => isCrossPlatform ? new RiderSettings() : new VisualStudioSettings();

            var nonCrossPlatformSettings = CreateSettings(false);
            var crossPlatformSettings = CreateSettings(true);

            nonCrossPlatformSettings.Should().BeOfType<VisualStudioSettings>();
            crossPlatformSettings.Should().BeOfType<RiderSettings>();
        }

        [Fact]
        public void Should_Infer_Type_For_Null_Coalescing_Operator()
        {
            static FontSettings GetDefaultFont(RiderSettings riderSettings)
                => riderSettings.SupportedFonts.FirstOrDefault() 
                    ?? new ExtendedFontSettings(riderSettings.FontFamily, riderSettings.FontSize);

            var settings = new RiderSettings
            {
                FontFamily = "Consolas",
                FontSize = 14
            };

            var defaultFont = GetDefaultFont(settings);

            defaultFont.Should().NotBeNull();
            defaultFont.Family.Should().Be("Consolas");
            defaultFont.Size.Should().Be(14);
        }

        [Fact]
        public void Should_Infer_Type_For_Arguments()
        {
            static string StartIde(RiderSettings settings)
                => $"Starting with {settings.GetType().Name}";

            StartIde(new()).Should().Be("Starting with RiderSettings");
            StartIde(new() { EditorScaling = 200 }).Should().Be("Starting with RiderSettings");
        }

        [Fact]
        public void Is_Reversed_VAR_Alternative()
        {
            VisualStudioSettings visualStudioSettings = new();
            
            List<RiderSettings> listOfRiderSettings = new()
            {
                new(),
                new()
            };

            (RiderSettings RiderSettings, VisualStudioSettings VsSettings) settingsTuple = new(new(), new());

            visualStudioSettings.Should().NotBeNull();

            listOfRiderSettings.Should()
                .HaveCount(2)
                .And.NotContainNulls();

            settingsTuple.RiderSettings.Should().NotBeNull();
            settingsTuple.VsSettings.Should().NotBeNull();
        }

        [Fact]
        public void Is_Supported_When_Throwing()
        {
            static void StopIt()
            {
                throw new("Sometimes you just need to take a break...");
            }

            Assert.Throws<Exception>(StopIt);
        }
    }
}