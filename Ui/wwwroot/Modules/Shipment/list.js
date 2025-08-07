function drawShipmentsTable(data) {
    var tbody = document.getElementById("shipmentsTableBody");
    tbody.innerHTML = ""; // Clear existing rows

    const formatter = new Intl.NumberFormat('en-US', {
        style: 'currency',
        currency: 'USD' // Use "EGP" for Egyptian Pound
    });

    for (let i = 0; i < data.length; i++) {
        const shipment = data[i];
        const row = document.createElement("tr");

        row.innerHTML = `
            <td>${i + 1}</td>
            <td>${shipment.trackingNumber ?? "-"}</td>
            <td>${new Date(shipment.shipingDate).toLocaleDateString()}</td>
            <td>${formatter.format(shipment.shippingRate)}</td>
            <td>${shipment.userSender?.senderName ?? "-"}</td>
            <td>${shipment.userReceiver?.receiverName ?? "-"}</td>
            <td>
                <a href="#" title="View"><i class="fa fa-check-circle" aria-hidden="true"></i></a>
            </td>
        `;

        tbody.appendChild(row);
    }
}