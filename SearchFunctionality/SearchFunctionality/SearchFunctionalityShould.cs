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
    }

    public class CitiesSearch {
        public List<string> Cities { get; }

        public CitiesSearch() {
            Cities = new List<string> { "Valencia", "Vancouver" };
        }

        public List<string> GetCitiesBy(string searchText) {
            var citiesFound = new List<string>();
            foreach (var city in Cities) {
                if (city.Contains(searchText))
                    citiesFound.Add(city);
            }
            return citiesFound;
        }
    }
}