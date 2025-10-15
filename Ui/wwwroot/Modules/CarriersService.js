const CarriersService = {
    GetAll: function (onSuccess, onError) {
        ApiClient.get('/api/Carriers', onSuccess, onError, false);
    },

    GetById: function (id, onSuccess, onError) {
        ApiClient.get(`/api/Carriers/${id}`, onSuccess, onError, false);
    }
};