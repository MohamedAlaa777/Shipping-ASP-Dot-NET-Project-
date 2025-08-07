$(document).ready(function () {
    const shipmentId = AppHelper.getQueryParam("id") || AppHelper.getIdFromPath();

    if (shipmentId) {

        LoadShipmentById(shipmentId); // تستدعي الـ API وتملأ الفورم
    }
});



function LoadShipmentById(id) {
    ShipmentService.GetById(
        id,
        function (response) {

            console.log("data return success")
            ShipmentService.FillShipmentForm(response.Data);

        },
        function (error) {
            console.error("API Error", error);
            alert("فشل في تحميل بيانات الشحنة");
        }
    );
}