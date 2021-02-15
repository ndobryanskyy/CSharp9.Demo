using FluentAssertions;
using Xunit;

namespace CSharp9.LearningTests
{
    public sealed class PatternMatchingTests
    {
        public record IdeFontSettings(
            FontSettings DefaultFont,
            FontSettings? UserDefaultFont = default,
            FontSettings? ProjectFont = default);
        
        /* NOT modifier
        [Fact]
        public void Should_Support_Pattern_Negation_With_NOT()
        {
            var settings = new IdeFontSettings(DefaultFonts.Consolas16, DefaultFonts.FiraCode15);

            var userFontIsSet = settings.UserDefaultFont != null;
            userFontIsSet.Should().BeTrue();

            var nonDefaultSize = settings.UserDefaultFont!.Size != 16;
            nonDefaultSize.Should().BeTrue();
        }
        */

        /* NOT null switch
        [Fact]
        public void Support_Not_Null_Expression_In_Switch()
        {
            static FontSettings GetEffectiveFont(IdeFontSettings? settings) => settings switch
            {
                { ProjectFont: { } projectFont } => projectFont,
                { UserDefaultFont: { } userFont } => userFont,
                { } => settings.DefaultFont,
                null => DefaultFonts.Consolas16
            };
            
            var defaultSettings = new IdeFontSettings(DefaultFonts.Consolas16);
            var withUserDefault = defaultSettings with { UserDefaultFont = DefaultFonts.Arial14 };
            var withUserDefaultAndProject = withUserDefault with { ProjectFont = DefaultFonts.FiraCode15 };

            GetEffectiveFont(defaultSettings).Should().Be(DefaultFonts.Consolas16);
            GetEffectiveFont(withUserDefault).Should().Be(DefaultFonts.Arial14);
            GetEffectiveFont(withUserDefaultAndProject).Should().Be(DefaultFonts.FiraCode15);
            
            GetEffectiveFont(null).Should().Be(DefaultFonts.Consolas16);
        }
        */

        /* Enhancements
        [Fact]
        public void Support_And_Or_Patterns()
        {
            static bool IsNiceFont(FontSettings settings)
            {
                if (settings is ExtendedFontSettings extended)
                {
                    return extended switch
                    {
                        { IsItalic: true } => true,
                        { Family: "Fira Code", Size: var size } when (size >= 14 && size <= 24) => true,
                        { Family: "Consolas", Size: var size } when (size >= 14 && size <= 24) => true,
                        _ => false
                    };
                }
                else
                {
                    return false;
                }
            }

            var italicArial = new ExtendedFontSettings("Arial", 30, true);
            var consolas14 = new ExtendedFontSettings("Consolas", 14);
            var firaCode24 = new ExtendedFontSettings("Fira Code", 24);
            var firaCode30 = firaCode24 with { Size = 30 };
            
            IsNiceFont(DefaultFonts.FiraCode15).Should().BeFalse();
            IsNiceFont(firaCode30).Should().BeFalse();
            
            IsNiceFont(italicArial).Should().BeTrue();
            IsNiceFont(firaCode24).Should().BeTrue();
            IsNiceFont(consolas14).Should().BeTrue();
        }
        */
    }
}