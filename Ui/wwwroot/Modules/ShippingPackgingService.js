const ShippingPackgingService = {
    GetAll: function (onSuccess, onError) {
        ApiClient.get('/api/ShippingPackging', onSuccess, onError, false);
    },

    GetById: function (id, onSuccess, onError) {
        ApiClient.get(`/api/ShippingPackging/${id}`, onSuccess, onError, false);
    }
};