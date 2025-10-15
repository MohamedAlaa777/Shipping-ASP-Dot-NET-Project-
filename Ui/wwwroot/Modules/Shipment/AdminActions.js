$('form.steps').on('submit', function (e) {
    e.preventDefault(); // منع الإرسال التقليدي

    const submitter = e.originalEvent?.submitter;
    const buttonValue = $(submitter).val();
    const buttonName = $(submitter).attr("id");
    console.log(buttonValue);
    switch (ShipmentService.FormIds.CurrentState) {
        case 1:
        case 2:
        case 3:
            ShipmentService.ChangeStatus(ShipmentService.FormIds.CurrentState + 1);
            break;
        case 4:
            if (buttonName === "mainButton")
                ShipmentService.ChangeStatus(5);
            else
                ShipmentService.ChangeStatus(6);
            break;
    }
});