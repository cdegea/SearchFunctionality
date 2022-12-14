namespace SearchFunctionality {
    public class SearchFunctionalityShould {

        [Test]
        public void return_no_results_when_search_is_fewer_than_two_characters() {
            var oneCharacterText = "P";

            var result = new CitiesSearch().GetCitiesBy(oneCharacterText);

            result.Count.Should().Be(0);
        }

        [Test]
        public void return_cities_when_search_contains_two_or_more_characters() {
            var expectedCities = new List<string> { "Valencia", "Vancouver" };
            var twoCharactersText = "Va ";

            var citiesFound = new CitiesSearch().GetCitiesBy(twoCharactersText);

            citiesFound.Should().BeEquivalentTo(expectedCities);
        }

        [Test]
        public void return_cities_with_insensitive_case() {
            var expectedCities = new List<string> { "Valencia", "Vancouver" };
            var twoCharactersText = "va";

            var citiesFound = new CitiesSearch().GetCitiesBy(twoCharactersText);

            citiesFound.Should().BeEquivalentTo(expectedCities);
        }

        [Test]
        public void return_all_city_name_when_search_is_asterisk() {
            var expectedCities = new List<string> {
                "Paris", "Budapest", "Skopje", "Rotterdam", 
                "Valencia", "Vancouver", "Amsterdam", "Vienna", 
                "Sydney", "New York City", "London", "Bangkok", 
                "Hong Kong", "Dubai", "Rome", "Instanbul"
            };
            var allCitiesSearch = "*";

            var citiesFound = new CitiesSearch().GetCitiesBy(allCitiesSearch);

            citiesFound.Should().BeEquivalentTo(expectedCities);
        }

        [Test]
        public void return_cities_when_search_contains_white_spaces() {
            var expectedCities = new List<string> { "Valencia", "Vancouver" };
            var twoCharactersText = "Va ";

            var citiesFound = new CitiesSearch().GetCitiesBy(twoCharactersText);

            citiesFound.Should().BeEquivalentTo(expectedCities);
        }
    }

    public class CitiesSearch {
        private List<string> Cities { get; }

        public CitiesSearch() {
            Cities = new List<string> {
                "Paris", "Budapest", "Skopje", "Rotterdam",
                "Valencia", "Vancouver", "Amsterdam", "Vienna",
                "Sydney", "New York City", "London", "Bangkok",
                "Hong Kong", "Dubai", "Rome", "Instanbul"
            };
        }

        public List<string> GetCitiesBy(string searchText) {
            return Cities.Where(city => IsFound(searchText, city)).ToList();
        }

        private static bool IsFound(string searchText, string city) {
            var textToSearch = searchText.Trim().ToLower();
            return textToSearch is "*" || textToSearch.Length >= 2 && city.ToLower().Contains(textToSearch.ToLower());
        }
    }
}