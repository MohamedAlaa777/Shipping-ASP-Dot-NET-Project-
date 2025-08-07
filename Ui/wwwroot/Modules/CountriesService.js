const CountriesService = {
    GetAll: function (onSuccess, onError) {
        ApiClient.get('/api/countries', onSuccess, onError, false);
    },

    GetById: function (id, onSuccess, onError) {
        ApiClient.get(`/api/countries/${id}`, onSuccess, onError, false);
    }
};