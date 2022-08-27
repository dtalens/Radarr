using FluentAssertions;
using NUnit.Framework;
using NzbDrone.Core.Languages;
using NzbDrone.Core.Parser;
using NzbDrone.Core.Test.Framework;

namespace NzbDrone.Core.Test.ParserTests
{
    [TestFixture]
    public class LanguageParserFixture : CoreTest
    {
        [TestCase("Movie.Title.1994.English.1080p.XviD-LOL")]
        public void should_parse_language_english(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.English);
        }

        [TestCase("The Danish Movie 2015")]
        [TestCase("Movie.Title.2018.2160p.WEBRip.x265.10bit.HDR.DD5.1-GASMASK")]
        [TestCase("Movie.Title.2010.720p.BluRay.x264.-[YTS.LT]")]
        public void should_parse_language_unknown(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.Unknown);
        }

        [TestCase("Movie Title - 2022.en.sub")]
        [TestCase("Movie Title - 2022.EN.sub")]
        [TestCase("Movie Title - 2022.eng.sub")]
        [TestCase("Movie Title - 2022.ENG.sub")]
        [TestCase("Movie Title - 2022.English.sub")]
        [TestCase("Movie Title - 2022.english.sub")]
        [TestCase("Movie Title - 2022.en.cc.sub")]
        [TestCase("Movie Title - 2022.en.sdh.sub")]
        [TestCase("Movie Title - 2022.en.forced.sub")]
        [TestCase("Movie Title - 2022.en.sdh.forced.sub")]
        public void should_parse_subtitle_language_english(string fileName)
        {
            var result = LanguageParser.ParseSubtitleLanguage(fileName);
            result.Should().Be(Language.English);
        }

        [TestCase("Movie.Title.1994.French.1080p.XviD-LOL")]
        [TestCase("Movie Title : Other Title 2011 AVC.1080p.Blu-ray HD.VOSTFR.VFF")]
        [TestCase("Movie Title - Other Title 2011 Bluray 4k HDR HEVC AC3 VFF")]
        [TestCase("Movie Title  2019 AVC.1080p.Blu-ray Remux HD.VOSTFR.VFF")]
        [TestCase("Movie Title  : Other Title 2010 x264.720p.Blu-ray Rip HD.VOSTFR.VFF. ONLY")]
        [TestCase("Movie Title  2019 HEVC.2160p.Blu-ray 4K.VOSTFR.VFF. JATO")]
        public void should_parse_language_french(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.French);
        }

        [TestCase("Movie 1990 1080p Eng Fra [mkvonly]")]
        [TestCase("Movie Directory 25 Anniversary 1990 Eng Fre Multi Subs 720p [H264 mp4]")]
        [TestCase("Foreign-Words-Here-Movie-(1990)-[DVDRip]-H264-Fra-Ac3-2-0-Eng-5-1")]
        public void should_parse_language_french_english(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().Contain(Language.French);
            result.Languages.Should().Contain(Language.English);
        }

        [TestCase("Movie.Title.1994.Spanish.1080p.XviD-LOL")]
        [TestCase("Movie Title (2020)[BDRemux AVC 1080p][E-AC3 DD Plus 5.1 Castellano-Inglés Subs]")]
        [TestCase("Movie Title (2020) [UHDRemux2160p HDR][DTS-HD MA 5.1 AC3 5.1 Castellano - True-HD 7.1 Atmos Inglés Subs]")]
        [TestCase("Movie Title (2016) [UHDRemux 2160p SDR] [Castellano DD 5.1 - Inglés DTS-HD MA 5.1 Subs]")]
        public void should_parse_language_spanish(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.Spanish);
        }

        [TestCase("Movie.Title.1994.German.1080p.XviD-LOL")]
        [TestCase("Movie.Title.2016.Ger.Dub.AAC.1080p.WebDL.x264-TKP21")]
        public void should_parse_language_german(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.German);
        }

        [TestCase("Movie.Title.1994.Italian.1080p.XviD-LOL")]
        public void should_parse_language_italian(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.Italian);
        }

        [TestCase("Movie.Title.1994.Danish.1080p.XviD-LOL")]
        public void should_parse_language_danish(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.Danish);
        }

        [TestCase("Movie.Title.1994.Dutch.1080p.XviD-LOL")]
        public void should_parse_language_dutch(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.Dutch);
        }

        [TestCase("Movie.Title.1994.Japanese.1080p.XviD-LOL")]
        public void should_parse_language_japanese(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.Japanese);
        }

        [TestCase("Movie.Title.1994.Icelandic.1080p.XviD-LOL")]
        public void should_parse_language_icelandic(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.Icelandic);
        }

        [TestCase("Movie.Title.1994.Chinese.1080p.XviD-LOL")]
        public void should_parse_language_chinese(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.Chinese);
        }

        [TestCase("Movie.Title.1994.Russian.1080p.XviD-LOL")]
        public void should_parse_language_russian(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.Russian);
        }

        [TestCase("Movie.Title.1994.Romanian.1080p.XviD-LOL")]
        public void should_parse_language_romanian(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.Romanian);
        }

        [TestCase("Movie.Title.1994.Hindi.1080p.XviD-LOL")]
        public void should_parse_language_hindi(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.Hindi);
        }

        [TestCase("Movie.Title.1994.Thai.1080p.XviD-LOL")]
        public void should_parse_language_thai(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.Thai);
        }

        [TestCase("Movie.Title.1994.Bulgarian.1080p.XviD-LOL")]
        [TestCase("Movie.Title.1994.BGAUDIO.1080p.XviD-LOL")]
        [TestCase("Movie.Title.1994.BG.AUDIO.1080p.XviD-LOL")]
        public void should_parse_language_bulgarian(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.Bulgarian);
        }

        [TestCase("Movie.Title.1994.Dublado.1080p.XviD-LOL")]
        [TestCase("Movie.Title.2.2019.1080p.Bluray.Dublado.WWW.TPF.GRATIS")]
        [TestCase("Movie.Title.2014.1080p.Bluray.Brazilian.WWW.TPF.GRATIS")]
        public void should_parse_language_brazilian_portuguese(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.PortugueseBR);
        }

        [TestCase("Movie.Title.1994.Polish.1080p.XviD-LOL")]
        [TestCase("Movie.Title.1994.PL.1080p.XviD-LOL")]
        [TestCase("Movie.Title.1994.PLDUB.1080p.XviD-LOL")]
        [TestCase("Movie.Title.1994.DUBPL.1080p.XviD-LOL")]
        [TestCase("Movie.Title.1994.PL-DUB.1080p.XviD-LOL")]
        [TestCase("Movie.Title.1994.DUB-PL.1080p.XviD-LOL")]
        [TestCase("Movie.Title.1994.PLLEK.1080p.XviD-LOL")]
        [TestCase("Movie.Title.1994.LEKPL.1080p.XviD-LOL")]
        [TestCase("Movie.Title.1994.PL-LEK.1080p.XviD-LOL")]
        public void should_parse_language_polish(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.Polish);
        }

        [TestCase("Movie.Title.1994.PL-SUB.1080p.XviD-LOL")]
        [TestCase("Movie.Title.1994.PLSUB.1080p.XviD-LOL")]
        [TestCase("Movie.Title.1994.SUB-PL.1080p.XviD-LOL")]
        public void should_parse_language_polish_subbed(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.Unknown);
        }

        [TestCase("Movie.Title.1994.Vietnamese.1080p.XviD-LOL")]
        public void should_parse_language_vietnamese(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.Vietnamese);
        }

        [TestCase("Movie.Title.1994.Swedish.1080p.XviD-LOL")]
        public void should_parse_language_swedish(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.Swedish);
        }

        [TestCase("Movie.Title.1994.Norwegian.1080p.XviD-LOL")]
        public void should_parse_language_norwegian(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.Norwegian);
        }

        [TestCase("Movie.Title.1994.Finnish.1080p.XviD-LOL")]
        public void should_parse_language_finnish(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.Finnish);
        }

        [TestCase("Movie.Title.1994.Turkish.1080p.XviD-LOL")]
        public void should_parse_language_turkish(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.Turkish);
        }

        [TestCase("Movie.Title.1994.Portuguese.1080p.XviD-LOL")]
        public void should_parse_language_portuguese(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.Portuguese);
        }

        [TestCase("Movie.Title.1994.Flemish.1080p.XviD-LOL")]
        public void should_parse_language_flemish(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.Flemish);
        }

        [TestCase("Movie.Title.1994.Greek.1080p.XviD-LOL")]
        public void should_parse_language_greek(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.Greek);
        }

        [TestCase("Movie.Title.1994.Korean.1080p.XviD-LOL")]
        public void should_parse_language_korean(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.Korean);
        }

        [TestCase("Movie.Title.1994.Hungarian.1080p.XviD-LOL")]
        public void should_parse_language_hungarian(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.Hungarian);
        }

        [TestCase("Movie.Title.1994.Hebrew.1080p.XviD-LOL")]
        public void should_parse_language_hebrew(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.Hebrew);
        }

        [TestCase("Movie.Title.1994.AC3.LT.EN-CNN")]
        public void should_parse_language_lithuanian(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.Lithuanian);
        }

        [TestCase("Movie.Title.1994.CZ.1080p.XviD-LOL")]
        public void should_parse_language_czech(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.Czech);
        }

        [TestCase("Movie.Title.2019.ARABIC.WEBRip.x264-VXT")]
        public void should_parse_language_arabic(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle);
            result.Languages.Should().BeEquivalentTo(Language.Arabic);
        }

        [TestCase("Movie.Title [1989, BDRip] MVO + DVO + UKR (MVO) + Sub")]
        [TestCase("Movie.Title (2006) BDRemux 1080p 2xUkr | Sub Ukr")]
        [TestCase("Movie.Title [1984, BDRip 720p] MVO + MVO + Dub + AVO + 3xUkr")]
        [TestCase("Movie.Title.2019.UKRAINIAN.WEBRip.x264-VXT")]
        public void should_parse_language_ukrainian(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.Ukrainian);
        }

        [TestCase("Movie.Title [1937, BDRip 1080p] Dub UKR/Eng + Sub rus")]
        [TestCase("Movie.Title.[2003.BDRemux.1080p].Dub.MVO.(2xUkr/Fra).Sub.(Rus/Fra)")]
        public void should_parse_language_ukrainian_multi(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().Contain(Language.Ukrainian);
        }

        [TestCase("Movie.Title.2019.PERSIAN.WEBRip.x264-VXT")]
        public void should_parse_language_persian(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle);
            result.Languages.Should().BeEquivalentTo(Language.Persian);
        }

        [TestCase("Movie.Title.2019.BENGALI.WEBRip.x264-VXT")]
        public void should_parse_language_bengali(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle);
            result.Languages.Should().BeEquivalentTo(Language.Bengali);
        }

        [TestCase("Movie.Title.1994.HDTV.x264.SK-iCZi")]
        [TestCase("Movie.Title.2019.1080p.HDTV.x265.iNTERNAL.SK-iCZi")]
        [TestCase("Movie.Title.2018.SLOVAK.DUAL.2160p.UHD.BluRay.x265-iCZi")]
        [TestCase("Movie.Title.1990.SLOVAK.HDTV.x264-iCZi")]
        public void should_parse_language_slovak(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle);
            result.Languages.Should().BeEquivalentTo(Language.Slovak);
        }
        
        [TestCase("Movie.Title.1994.Catalan.1080p.XviD-LOL")]
        [TestCase("Movie Title (2020)[BDRemux AVC 1080p][E-AC3 DD Plus 5.1 CA-EN Subs]")]
        [TestCase("Movie Title (2020)[BDRemux AVC 1080p][E-AC3 DD Plus 5.1 ES-CA-EN Subs]")]
        [TestCase("Movie Title (2020) [UHDRemux2160p HDR][DTS-HD MA 5.1 AC3 5.1 CA - True-HD 7.1 Atmos EN Subs]")]
        [TestCase("Movie Title (2016) [UHDRemux 2160p SDR] [CA DD 5.1 - EN DTS-HD MA 5.1 Subs]")]
        public void should_parse_language_spanish(string postTitle)
        {
            var result = Parser.Parser.ParseMovieTitle(postTitle, true);

            result.Languages.Should().BeEquivalentTo(Language.Catalan);

        [TestCase("Movie.Title.en.sub")]
        [TestCase("Movie Title.eng.sub")]
        [TestCase("Movie.Title.eng.forced.sub")]
        [TestCase("Movie-Title-eng-forced.sub")]
        public void should_parse_subtitle_language(string fileName)
        {
            var result = LanguageParser.ParseSubtitleLanguage(fileName);
            result.Should().Be(Language.English);
        }

        [TestCase("Movie Title.sub")]
        public void should_parse_subtitle_language_unknown(string fileName)
        {
            var result = LanguageParser.ParseSubtitleLanguage(fileName);
            result.Should().Be(Language.Unknown);
        }
    }
}
