using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace CSharp9.LearningTests
{
    public static class EnumerableExtensions
    {
        public static TItem? MaxBy<TItem, TMember>(this IEnumerable<TItem> source, Func<TItem, TMember?> selector)
            where TMember : IComparable<TMember>
        {
            return source.Aggregate(default(TItem), (maxItem, currentItem) =>
            {
                if (maxItem == null)
                {
                    return currentItem;
                }
                
                var currentToMaxComparison = selector(currentItem)?.CompareTo(selector(maxItem));

                return currentToMaxComparison switch
                {
                    null => maxItem,
                    >= 0 => currentItem,
                    _ => maxItem
                };
            });
        }
    }
    
    public sealed class NullableConstraintsTests
    {
        [Fact]
        public void Should_Find_Max_Item_By_Selector()
        {
            var fonts = new[] { DefaultFonts.Arial14, DefaultFonts.Consolas16, DefaultFonts.FiraCode15 };

            var maxFontBySize = fonts.MaxBy(x => x.Size);
            maxFontBySize.Should().Be(DefaultFonts.Consolas16);
        }
        
        [Fact]
        public void Should_Return_Default_If_Source_Contains_No_Elements()
        {
            var fonts = Array.Empty<FontSettings>();
            var maxFontBySize = fonts.MaxBy(x => x.Size);

            maxFontBySize.Should().BeNull();
        }

        public struct FontSettingsStruct
        {
            public FontSettingsStruct(string family, int size)
            {
                Family = family;
                Size = size;
            }

            public string Family { get; }
            
            public int Size { get; }
        }
        
        [Fact]
        public void Should_Also_Work_On_Value_Types()
        {
            var biggestFont = new FontSettingsStruct("Arial", 24);

            var fontStructs = new[]
            {
                new FontSettingsStruct("Arial", 12),
                biggestFont, 
                new FontSettingsStruct("Consolas", 20)
            };

            var maxFontBySize = fontStructs.MaxBy(x => x.Size);
            
            maxFontBySize.Should().Be(biggestFont);
        }

        [Fact]
        public void Should_Return_Default_Instance_For_Structs_If_Source_Is_Empty()
        {
            var fontStructs = Array.Empty<FontSettingsStruct>();

            var maxFontBySize = fontStructs.MaxBy(x => x.Size);

            maxFontBySize.Should().NotBeNull();
            maxFontBySize.Family.Should().BeNull();
            maxFontBySize.Size.Should().Be(0);
        }
    }
}