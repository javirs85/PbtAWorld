var MyModule = {

    DeleteCookieLogout: function () {
        document.cookie = 'TrySingOutGoogleAuth' + '=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;';
    }

}