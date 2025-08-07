const ManagePageControls = {
    fillCountryDropdown: function (selectSelector) {
        CountriesService.GetAll(function (response) {
            $(selectSelector).empty();
            $(selectSelector).append('<option value="">Select a country</option>');

            console.log("First country:", response.Data[0]);
            console.log("CountryAName:", response.Data[0].CountryAName);

            console.log(response.Data);
            response.Data.forEach(function (country) {
                $(selectSelector).append(
                    `<option value="${country.Id}">${country.CountryAname}</option>`
                );
            });
        }, function (error) {
            console.error('Error fetching countries:', error.responseText);
        });
    },

    fillShippingTypesDropdown: function (selectSelector) {
        ShippingTypesService.GetAll(function (response) {
            $(selectSelector).empty();
            $(selectSelector).append('<option value="">Select a shipping type</option>');

            console.log(response.Data);
            response.Data.forEach(function (type) {
                $(selectSelector).append(
                    `<option value="${type.Id}">${type.ShippingTypeAname}</option>`
                );
            });
        }, function (error) {
            console.error('Error fetching shipping types:', error.responseText);
        });
    },

    fillShippingPackgingDropdown: function (selectSelector) {
        ShippingPackgingService.GetAll(function (response) {
            $(selectSelector).empty();
            $(selectSelector).append('<option value="">Select a packaging type</option>');

            console.log(response.Data);
            response.Data.forEach(function (pack) {
                $(selectSelector).append(
                    `<option value="${pack.Id}">${pack.ShipingPackgingAname}</option>`
                );
            });
        }, function (error) {
            console.error('Error fetching shipping packging:', error.responseText);
        });
    },

    fillCityDropdown: function (selectSelector, countryId, cityId) {
        if (!countryId) {
            $(selectSelector).empty().append('<option value="">Select a city</option>');
            return;
        }

        CititesService.GetByCountryId(countryId, function (response) {
            $(selectSelector).empty().append('<option value="">Select a city</option>');
            console.log("Cities:", response.Data);

            response.Data.forEach(function (city) {
                $(selectSelector).append(
                    `<option value="${city.Id}">${city.CityAname}</option>` // ✅ Corrected property name
                );
            });

            if (cityId) {
                $(selectSelector).val(cityId);
            }
        }, function (error) {
            console.error('Error fetching cities:', error.responseText);
        });
    }

};