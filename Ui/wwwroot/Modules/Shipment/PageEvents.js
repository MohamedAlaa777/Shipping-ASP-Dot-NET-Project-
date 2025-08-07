$(document).ready(function () {
    // تعبئة الدول
    ManagePageControls.fillCountryDropdown('select[name="Sendercountry"]');
    ManagePageControls.fillCountryDropdown('select[name="ReciverCountry"]');

    // تعبئة أنواع الشحن
    ManagePageControls.fillShippingTypesDropdown('select[name="ShippingType"]');

    // تعبئة أنواع التغليف
    ManagePageControls.fillShippingPackgingDropdown('select[name="PackageType"]');

    // تعبئة المدن بناءً على البلد
    $('select[name="Sendercountry"]').on('change', function () {
        const countryId = $(this).val();
        ManagePageControls.fillCityDropdown('select[name="SenderCityId"]', countryId, null);
    });

    $('select[name="ReciverCountry"]').on('change', function () {
        const countryId = $(this).val();
        ManagePageControls.fillCityDropdown('select[name="ReciverCity"]', countryId, null);
    });
});