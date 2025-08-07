const ApiClient = {
    baseUrl: 'https://localhost:7186',

    get: function (url, onSuccess, onError, useAuth = true) {
        const accessToken = AppHelper.getCookie("AccessToken");
        const headers = useAuth && accessToken
            ? { 'Authorization': 'Bearer ' + accessToken }
            : {};

        $.ajax({
            url: this.baseUrl + url,
            type: 'GET',
            contentType: 'application/json',
            headers: headers,
            success: onSuccess,
            error: function (xhr) {
                if (useAuth && xhr.status === 401) {
                    ApiClient.refreshToken(() => {
                        ApiClient.get(url, onSuccess, onError, useAuth);
                    }, onError);
                } else if (onError) {
                    onError(xhr);
                }
            }
        });
    },

    post: function (url, data, onSuccess, onError, useAuth = true) {
        const accessToken = AppHelper.getCookie("AccessToken");
        const headers = useAuth && accessToken
            ? { 'Authorization': 'Bearer ' + accessToken }
            : {};

        $.ajax({
            url: this.baseUrl + url,
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: headers,
            xhrFields: {
                withCredentials: true
            },
            success: onSuccess,
            error: function (xhr) {
                if (useAuth && xhr.status === 401) {
                    ApiClient.refreshToken(() => {
                        ApiClient.post(url, data, onSuccess, onError, useAuth);
                    }, onError);
                } else if (onError) {
                    onError(xhr);
                }
            }
        });
    },

    refreshToken: function (onSuccess, onFailure) {


        $.ajax({
            url: this.baseUrl + '/api/auth/RefreshAccessToken',
            type: 'POST',
            contentType: 'application/json',
            xhrFields: {
                withCredentials: true
            },
            /*data: JSON.stringify({ refreshToken: refreshToken }),*/
            success: function (response) {
                if (response && response.accessToken) {
                    document.cookie = `AccessToken=${response.AccessToken}; path=/`;
                    onSuccess();
                } else {
                    if (onFailure) onFailure({ message: 'Token refresh failed.' });
                }
            },
            error: function (err) {
                if (onFailure) onFailure(err);
            }
        });
    }
};