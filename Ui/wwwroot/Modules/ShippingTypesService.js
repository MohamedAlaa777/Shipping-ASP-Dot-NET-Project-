const ShippingTypesService = {
    GetAll: function (onSuccess, onError) {
        ApiClient.get('/api/ShippingTypes', onSuccess, onError, false);
    },

    GetById: function (id, onSuccess, onError) {
        ApiClient.get(`/api/ShippingTypes/${id}`, onSuccess, onError, false);
    }
};