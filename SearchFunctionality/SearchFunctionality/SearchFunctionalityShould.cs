namespace SearchFunctionality {
    public class SearchFunctionalityShould {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void return_no_results_when_search_is_fewer_than_two_characters() {
            var twoCharactersText = "P";

            var result = new CitiesSearch().GetCitiesBy(twoCharactersText);

            result.Count.Should().Be(0);
        }

        [Test]
        public void return_cities_when_search_contains_two_or_more_characters() {
            var expectedCities = new List<string> { "Valencia", "Vancouver" };
            var twoCharactersText = "Va";

            var citiesFound = new CitiesSearch().GetCitiesBy(twoCharactersText);

            citiesFound.Should().BeEquivalentTo(expectedCities);
        }

        [Test]
        public void return_cities_with_sensitive_case() {
            var expectedCities = new List<string> { "Valencia", "Vancouver" };
            var twoCharactersText = "va";

            var citiesFound = new CitiesSearch().GetCitiesBy(twoCharactersText);

            citiesFound.Should().BeEquivalentTo(expectedCities);
        }
    }

    public class CitiesSearch {
        private List<string> Cities { get; }

        public CitiesSearch() {
            Cities = new List<string> { "Valencia", "Vancouver" };
        }

        public List<string> GetCitiesBy(string searchText) {
            return Cities.Where(city => city.Contains(searchText)).ToList();
        }
    }
}