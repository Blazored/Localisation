var Blazored;
(function (Blazored) {
    var Localisation;
    (function (Localisation_1) {
        class Localisation {
            GetBrowserLocale() {
                return (navigator.languages && navigator.languages.length) ? navigator.languages[0] : navigator['userLanguage']
                    || navigator.language
                    || navigator['browserLanguage']
                    || 'en';
            }
            GetBrowserTimeZoneOffset() {
                return new Date().getTimezoneOffset();
            }
            GetBrowserTimeZoneIdentifier() {
                return Intl.DateTimeFormat().resolvedOptions().timeZone;
            }
        }
        function Load() {
            const localisation = {
                Localisation: new Localisation()
            };
            if (window['Blazored']) {
                window['Blazored'] = Object.assign({}, window['Blazored'], localisation);
            }
            else {
                window['Blazored'] = Object.assign({}, localisation);
            }
        }
        Localisation_1.Load = Load;
    })(Localisation = Blazored.Localisation || (Blazored.Localisation = {}));
})(Blazored || (Blazored = {}));
Blazored.Localisation.Load();
//# sourceMappingURL=blazored-localisation.js.map