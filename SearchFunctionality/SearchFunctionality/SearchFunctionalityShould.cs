namespace SearchFunctionality {
    public class SearchFunctionalityShould {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void return_no_results_when_search_is_fewer_than_two_characters() {
            var twoCharactersText = "Pa";

            var result = new CitiesSearch().GetCitiesBy(twoCharactersText);

            result.Count.Should().Be(0);
        }
    }

    public class CitiesSearch {
        public List<string> GetCitiesBy(string searchText) {
            return new List<string>();
        }
    }
}