const paypalButtons = window.paypal.Buttons({
    style: {
        shape: "rect",
        layout: "vertical",
        color: "blue",
        label: "buynow",
    },
    // مكوّن الرسائل مش هنا (انظر الملحوظة 4)

    async createOrder() {
        const payload = {
            Items: [{ Name: "shipping", Description: "", Price: 50, Quantity: 1 }],
            ShippingValue: 0
        };

        const res = await fetch(ApiClient.baseUrl + "/api/Payment/create-order", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            },
            body: JSON.stringify(payload)
        });

        // مهم: اتأكد الأول من OK
        if (!res.ok) {
            const text = await res.text(); // ممكن يكون "System.InvalidOperationException..."
            throw new Error(`create-order failed ${res.status}: ${text}`);
        }

        // دلوقتي JSON بأمان
        const data = await res.json();
        if (!data?.id) {
            throw new Error(`create-order: missing id in response: ${JSON.stringify(data)}`);
        }
        return data.id; // لازم ترجع string للـ SDK
    },

    async onApprove(data) {
        // data.orderID جاي من PayPal
        const res = await fetch(ApiClient.baseUrl + "/api/Payment/capture-order", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            },
            body: JSON.stringify({ OrderId: data.orderID, Amount: 0 })
        });

        if (!res.ok) {
            const text = await res.text();
            throw new Error(`capture-order failed ${res.status}: ${text}`);
        }

        const capture = await res.json();
        alert("Transaction completed!");
        console.log(capture);
    },

    onError(err) {
        console.error("PayPal Buttons Error:", err);
        // resultMessage(`Payment error: ${err.message}`);
    }
});

paypalButtons.render("#paypal-button-container");

