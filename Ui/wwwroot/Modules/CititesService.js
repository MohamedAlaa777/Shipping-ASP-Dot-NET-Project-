const CititesService = {
    GetAll: function (onSuccess, onError) {
        ApiClient.get('/api/Cities', onSuccess, onError, false);
    },

    GetById: function (id, onSuccess, onError) {
        ApiClient.get(`/api/Cities/${id}`, onSuccess, onError, false);
    },
    GetByCountryId: function (id, onSuccess, onError) {
        ApiClient.get(`/api/Cities/GetByCountry/${id}`, onSuccess, onError, false);
    }
};