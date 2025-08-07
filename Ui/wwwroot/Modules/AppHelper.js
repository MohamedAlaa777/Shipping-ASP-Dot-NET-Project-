const AppHelper = {
    getCookie: function (name) {
        const value = `; ${document.cookie}`;
        const parts = value.split(`; ${name}=`);
        if (parts.length === 2) return parts.pop().split(';').shift();
        return null;
    },

    showToast: function (message, type = 'info') {
        // مثال بسيط باستخدام toastr أو أي مكتبة تنبيه
        if (window.toastr) {
            toastr[type](message);
        } else {
            alert(message);
        }
    },

    formatDate: function (date) {
        return new Date(date).toISOString();
    },

    getQueryParam: function (name) {
        const urlParams = new URLSearchParams(window.location.search);
        return urlParams.get(name);
    },
    getIdFromPath: function () {
        const segments = window.location.pathname.split('/');
        return segments[segments.length - 1]; // يأخذ آخر جزء من الرابط
    }
};
