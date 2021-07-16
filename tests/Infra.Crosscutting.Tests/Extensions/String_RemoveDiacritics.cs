using System;
using FluentAssertions;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Extensions
{
    public class String_RemoveDiacritics
    {
        [Theory]
        [InlineData("äǽ", "aæ")]
        [InlineData("öœ", "oœ")]
        [InlineData("ü", "u")]
        [InlineData("Ä", "A")]
        [InlineData("Ü", "U")]
        [InlineData("Ö", "O")]
        [InlineData("ÀÁÂÃÄÅǺĀĂĄǍΑΆẢẠẦẪẨẬẰẮẴẲẶА", "AAAAAAAAAAAΑΑAAAAAAAAAAAА")]
        [InlineData("àáâãåǻāăąǎªαάảạầấẫẩậằắẵẳặа", "aaaaaaaaaaªααaaaaaaaaaaaaа")]
        [InlineData("ÇĆĈĊČ", "CCCCC")]
        [InlineData("çćĉċč", "ccccc")]
        [InlineData("Ďď", "Dd")]
        [InlineData("ÈÉÊËĒĔĖĘĚΕΈẼẺẸỀẾỄỂỆЕЭЁ", "EEEEEEEEEΕΕEEEEEEEEЕЭЕ")]
        [InlineData("èéêëēĕėęěέεẽẻẹềếễểệеэё", "eeeeeeeeeεεeeeeeeeeеэе")]
        [InlineData("ĜĞĠĢΓГҐ", "GGGGΓГҐ")]
        [InlineData("ĝğġģγгґ", "ggggγгґ")]
        [InlineData("ĤĦ", "HĦ")]
        [InlineData("ĥħ", "hħ")]
        [InlineData("ÌÍÎÏĨĪĬǏĮİΗΉΊΙΪỈỊИЫЇ", "IIIIIIIIIIΗΗΙΙΙIIИЫІ")]
        [InlineData("ìíîïĩīĭǐįıηήίιϊỉịиыї", "iiiiiiiiiıηηιιιiiиыі")]
        [InlineData("Ĵ", "J")]
        [InlineData("ĵ", "j")]
        [InlineData("ĶΚК", "KΚК")]
        [InlineData("ķκк", "kκк")]
        [InlineData("ĹĻĽĿŁΛЛ", "LLLĿŁΛЛ")]
        [InlineData("ĺļľŀłλл", "lllŀłλл")]
        [InlineData("ÑŃŅŇΝН", "NNNNΝН")]
        [InlineData("ñńņňŉνн", "nnnnŉνн")]
        [InlineData("ÒÓÔÕŌŎǑŐƠØǾΟΌΩΏỎỌỒỐỖỔỘỜỚỠỞỢО", "OOOOOOOOOØØΟΟΩΩOOOOOOOOOOOOО")]
        [InlineData("òóôõōŏǒőơøǿºοόωώỏọồốỗổộờớỡởợо", "oooooooooøøºοοωωooooooooooooо")]
        [InlineData("ŔŖŘΡР", "RRRΡР")]
        [InlineData("ŕŗřρр", "rrrρр")]
        [InlineData("ŚŜŞȘŠΣС", "SSSSSΣС")]
        [InlineData("śŝşșšſσςс", "sssssſσςс")]
        [InlineData("ȚŢŤŦτТ", "TTTŦτТ")]
        [InlineData("țţťŧт", "tttŧт")]
        [InlineData("ÙÚÛŨŪŬŮŰŲƯǓǕǗǙǛŨỦỤỪỨỮỬỰУ", "UUUUUUUUUUUUUUUUUUUUUUUУ")]
        [InlineData("ùúûũūŭůűųưǔǖǘǚǜυύϋủụừứữửựу", "uuuuuuuuuuuuuuuυυυuuuuuuuу")]
        [InlineData("ÝŸŶΥΎΫỲỸỶỴЙ", "YYYΥΥΥYYYYИ")]
        [InlineData("ýÿŷỳỹỷỵй", "yyyyyyyи")]
        [InlineData("Ŵ", "W")]
        [InlineData("ŵ", "w")]
        [InlineData("ŹŻŽΖЗ", "ZZZΖЗ")]
        [InlineData("źżžζз", "zzzζз")]
        [InlineData("ÆǼ", "ÆÆ")]
        public void RemoveAllAccentsSuccessfully(string test, string expected)
        {
            string cleanedValue = test.RemoveDiacritics();
            cleanedValue.Should().NotBeNullOrWhiteSpace().And.Be(expected);
        }
    }
}
