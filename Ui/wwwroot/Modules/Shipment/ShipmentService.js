const ShipmentService =
{
    FormIds: {},
    GetModel: function () {
        const shipmentDto = {
            ShipingDate: new Date().toISOString(),
            DelivryDate: new Date(new Date().setDate(new Date().getDate() + 3)).toISOString(),

            SenderId: "00000000-0000-0000-0000-000000000000",
            UserSender: {
                Id: "00000000-0000-0000-0000-000000000000",
                UserId: "00000000-0000-0000-0000-000000000000",
                SenderName: $('input[name="SenderName"]').val(),
                Email: $('input[name="Email"]').val(),
                Phone: $('input[name="Phone"]').val(),
                CityId: $('select[name="SenderCityId"]').val(),
                Address: $('input[name="Address"]').val(),
                Contact: $('input[name="Contact"]').val(),
                PostalCode: $('input[name="PostalCode"]').val(),
                OtherAddress: $('input[name="OtherAddress"]').val()
            },

            ReceiverId: "00000000-0000-0000-0000-000000000000",
            UserReceiver: {
                Id: "00000000-0000-0000-0000-000000000000",
                UserId: "00000000-0000-0000-0000-000000000000",
                ReceiverName: $('input[name="ReciverName"]').val(),
                Email: $('input[name="ReciverEmail"]').val(),
                Phone: $('input[name="ReciverPhone"]').val(),
                CityId: $('select[name="ReciverCity"]').val(),
                Address: $('input[name="ReciverAddress"]').val(),
                Contact: $('input[name="ReciverContact"]').val(),
                PostalCode: $('input[name="ReciverPostalCode"]').val(),
                OtherAddress: $('input[name="ReciverOtherAddress"]').val()
            },

            ShippingTypeId: $('select[name="ShippingType"]').val(),
            ShipingPackgingId: $('select[name="PackageType"]').val() || null,

            Width: parseFloat($('input[name="Width"]').val()) || 0,
            Height: parseFloat($('input[name="Height"]').val()) || 0,
            Weight: parseFloat($('input[name="Weight"]').val()) || 0,
            Length: parseFloat($('input[name="Length"]').val()) || 0,

            PackageValue: parseFloat($('input[name="PackageValue"]').val()) || 0,
            ShippingRate: 0.0,

            PaymentMethodId: null,
            UserSubscriptionId: null,
            TrackingNumber: null,
            ReferenceId: null
        };
        console.log(shipmentDto);
        return shipmentDto;
    },
    FillShipmentForm: function (data) {
        this.FormIds = {
            Id: data.Id,
            SenderId: data.UserSender?.Id,
            ReciverId: data.UserReceiver?.Id,
            TrackingNumber: data.TrackingNumber,
            ShippingRate: data.ShippingRate
        };
        $('input[name="SenderName"]').val(data.UserSender?.SenderName || "");
        $('input[name="Email"]').val(data.UserSender?.Email || "");
        $('input[name="Phone"]').val(data.UserSender?.Phone || "");
        /*        $('select[name="SenderCityId"]').val(data.UserSender?.CityId || "");*/
        $('select[name="Sendercountry"]').val(data.UserSender?.CountryId || "");
        ManagePageControls.fillCityDropdown('select[name="SenderCityId"]', data.UserSender?.CountryId, data.UserSender?.CityId);
        $('input[name="Address"]').val(data.UserSender?.Address || "");
        $('input[name="Contact"]').val(data.UserSender?.Contact || "");
        $('input[name="PostalCode"]').val(data.UserSender?.PostalCode || "");
        $('input[name="OtherAddress"]').val(data.UserSender?.OtherAddress || "");

        // Receiver Info
        $('input[name="ReciverName"]').val(data.UserReceiver?.ReceiverName || "");
        $('input[name="ReciverEmail"]').val(data.UserReceiver?.Email || "");
        $('input[name="ReciverPhone"]').val(data.UserReceiver?.Phone || "");
        //$('select[name="ReciverCity"]').val(data.UserReceiver?.CityId || "");
        $('select[name="ReciverCountry"]').val(data.UserReceiver?.CountryId || "");
        ManagePageControls.fillCityDropdown('select[name="ReciverCity"]', data.UserReceiver?.CountryId, data.UserReceiver?.CityId);
        $('input[name="ReciverAddress"]').val(data.UserReceiver?.Address || "");
        $('input[name="ReciverContact"]').val(data.UserReceiver?.Contact || "");
        $('input[name="ReciverPostalCode"]').val(data.UserReceiver?.PostalCode || "");
        $('input[name="ReciverOtherAddress"]').val(data.UserReceiver?.OtherAddress || "");

        // Shipment details
        $('select[name="ShippingType"]').val(data.ShippingTypeId || "");
        $('select[name="PackageType"]').val(data.ShipingPackgingId || "");
        $('input[name="Width"]').val(data.Width);
        $('input[name="Height"]').val(data.Height);
        $('input[name="Weight"]').val(data.Weight);
        $('input[name="Length"]').val(data.Length);
        $('input[name="PackageValue"]').val(data.PackageValue);
        $('input[name="TrackingNumber"]').val(data.TrackingNumber ?? "");

        // Dates
        $('input[name="ShipingDate"]').val(new Date(data.ShipingDate).toISOString().split("T")[0]);
        $('input[name="DelivryDate"]').val(new Date(data.DelivryDate).toISOString().split("T")[0]);
    },

    SaveShippment: function () {
        let data = ShipmentService.GetModel();
        console.log("log data before send");
        console.log(data);
        ApiClient.post("/api/Shipment/Create", data,
            function (data) { }, function (xhr) {
                console.error("API Error:", xhr.responseJSON);
            });
    },
    EditShippment: function () {
        let data = ShipmentService.GetModel();
        data.Id = this.FormIds.Id;
        data.SenderId = this.FormIds.SenderId;
        data.ReceiverId = this.FormIds.ReciverId;
        data.TrackingNumber = this.FormIds.TrackingNumber;
        data.ShippingRate = this.FormIds.ShippingRate;
        console.log("log data before send");
        console.log(data);
        ApiClient.post("/api/Shipment/Edit", data,
            function (data) { }, function (xhr) {
                console.error("API Error:", xhr.responseJSON);
            });
    },
    GetShipments: function (onSuccess, onError) {
        ApiClient.get(`/api/Shipment/shipments`, onSuccess, onError, true);
    },
    GetById: function (id, onSuccess, onError) {
        ApiClient.get(`/api/Shipment/${id}`, onSuccess, onError, true);
    },
}