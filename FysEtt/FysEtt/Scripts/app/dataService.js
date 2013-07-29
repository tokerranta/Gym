var fysett = fysett || {};

fysett.dataService = (function () {

    var
        getNews = function () {
            var url = "/api/newsdata/";
            return $.getJSON(url);
        };

    return {
        getNews: getNews
    }

}());