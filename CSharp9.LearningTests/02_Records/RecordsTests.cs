namespace CSharp9.LearningTests
{
    public class FontSettings
    {
        public FontSettings(string family, int size)
        {
            Family = family;
            Size = size;
        }

        public string Family { get; }

        public int Size { get; }
    }

    public sealed class RecordsTests
    {
        /* Equality
        [Fact]
        public void Instances_With_Equal_Values_Should_Be_Equal()
        {
            var settings = DefaultFonts.Consolas;

            var identicalSettings = new FontSettings("Consolas", 16);
            
            settings.Should().BeAssignableTo<IEquatable<FontSettings>>();
            
            settings.Equals(identicalSettings).Should().BeTrue();
            (settings == identicalSettings).Should().BeTrue();
            (settings != identicalSettings).Should().BeFalse();
        }
        */

        /* Primary Constructor
        [Fact]
        public void Positional_Properties_Should_Be_Synthesized_As_Get_Init()
        {
            var settings = new FontSettings(
                Family: "Consolas",
                Size: 16)
            {
                Size = 24
            };

            settings.Size.Should().Be(16);
        }
        */

        /* Deconstructor
        [Fact]
        public void Should_Have_Synthesized_Deconstructor()
        {
            var settings = DefaultFonts.Consolas;

            var (fontFamily, fontSize) = settings;

            fontFamily.Should().Be("Consolas");
            fontSize.Should().Be(16);
        }
        */
        
        /* ToString
        [Fact]
        public void Should_Have_Synthesized_ToString_Printing_All_Public_Members()
        {
            var settings = DefaultFonts.Consolas;

            settings.ToString().Should().Be("FontSettings { Family = Consolas, Size = 16 }");
        }
        */

        /* Derived Types: ExtendedFontSettings IsItalic
        [Fact]
        public void Derived_Type_Should_Extend_Base_ToString_And_Deconstructor()
        {
            var extendedSettings = new ExtendedFontSettings(
                Family: "Consolas",
                Size: 16,
                IsItalic: true);

            var (familyFromBase, sizeFromBase) = extendedSettings;
            var (family, size, isItalic) = extendedSettings;

            family.Should().Be(familyFromBase).And.Be("Consolas");
            size.Should().Be(sizeFromBase).And.Be(16);
            isItalic.Should().BeTrue();

            extendedSettings.ToString()
                .Should().Be("ExtendedFontSettings { Family = Consolas, Size = 16, IsItalic = True }");
        }
        */
        
        /* Derived Types: Equality
        [Fact]
        public void Synthesized_Equals_Implementation_Considers_Only_Records_Of_Same_Type_Equal()
        {
            static bool FontSettingsEqual(FontSettings left, FontSettings right) 
                => left.Equals(right);
        
            var defaultSettings = new FontSettings("Consolas", 16);
            
            var extendedSettings = new ExtendedFontSettings("Consolas", 16);
            var identicalExtendedSettings = new ExtendedFontSettings("Consolas", 16);

            extendedSettings.Equals(identicalExtendedSettings).Should().BeTrue();
            (extendedSettings == identicalExtendedSettings).Should().BeTrue();
            
            FontSettingsEqual(defaultSettings, extendedSettings).Should().BeFalse();
            FontSettingsEqual(extendedSettings, defaultSettings).Should().BeFalse();
        }
        */

        /* WITH Expression
        [Fact]
        public void Should_Support_Special_Non_Destructive_Copy_With_Expression()
        {
            var consolasDefault = new ExtendedFontSettings("Consolas", 16);

            var italicEnlargedConsolas = consolasDefault with 
            {
                Size = 20,
                IsItalic = true
            };

            italicEnlargedConsolas.Family.Should().Be("Consolas");
            italicEnlargedConsolas.Size.Should().Be(20);
            italicEnlargedConsolas.IsItalic.Should().BeTrue();
            
            consolasDefault.Size.Should().Be(16);
            consolasDefault.IsItalic.Should().BeFalse();
        }
        */

        /* Shallow Equals: AuthoredFontSettings Authors
        [Fact]
        public void Equality_Comparison_Is_Shallow()
        {
            var authoredFontSettings = new AuthoredFontSettings("JoJa", 16)
            {
                Authors = new List<string>
                {
                    "John", "Jane"
                }
            };
            
            var identicalAuthoredFontSettings = new AuthoredFontSettings("JoJa", 16)
            {
                Authors = new List<string>
                {
                    "John", "Jane"
                }
            };

            authoredFontSettings.Equals(identicalAuthoredFontSettings).Should().BeTrue();
        }
        */

        /* Shallow Cloning
        [Fact]
        public void Cloning_Is_Shallow()
        {
            var initialAuthoredFontSettings = new AuthoredFontSettings("JoJa", 16)
            {
                Authors = new List<string>
                {
                    "John", 
                    "Jane"
                }
            };
            
            var enlargedAuthoredFontSettings = initialAuthoredFontSettings with 
            {
                Size = 20
            };
            
            initialAuthoredFontSettings.Authors.Add("Alex");

            enlargedAuthoredFontSettings.Family.Should().Be("JoJa");
            enlargedAuthoredFontSettings.Size.Should().Be(20);
            
            enlargedAuthoredFontSettings.Authors.Should().BeEquivalentTo(new[]
            {
                "John", "Jane"
            });
        }
        */

        /* Serializers
        [Fact]
        public void System_Text_Json_Can_Serialize_And_Deserialize_Records()
        {
            var serializedSettings = JsonSerializer.Serialize(DefaultFonts.Consolas);
            serializedSettings.Should().Be(@"{""Family"":""Consolas"",""Size"":16}");

            var deserializedSettings = JsonSerializer.Deserialize<FontSettings>(serializedSettings);
            deserializedSettings.Should().Be(DefaultFonts.Consolas);
        }
        
        [Fact]
        public void Newtonsoft_Json_Can_Serialize_And_Deserialize_Records()
        {
            var serializedSettings = JsonConvert.SerializeObject(DefaultFonts.Consolas);
            serializedSettings.Should().Be(@"{""Family"":""Consolas"",""Size"":16}");

            var deserializedSettings = JsonConvert.DeserializeObject<FontSettings>(serializedSettings);
            deserializedSettings.Should().Be(DefaultFonts.Consolas);
        }
        */
    }
}