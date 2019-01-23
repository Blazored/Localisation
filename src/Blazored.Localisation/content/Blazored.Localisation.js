var __assign = (this && this.__assign) || function () {
    __assign = Object.assign || function(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
                t[p] = s[p];
        }
        return t;
    };
    return __assign.apply(this, arguments);
};
var Blazored;
(function (Blazored) {
    var Localisation;
    (function (Localisation_1) {
        var Localisation = /** @class */ (function () {
            function Localisation() {
            }
            Localisation.prototype.GetBrowserLocale = function () {
                return (navigator.languages && navigator.languages.length) ? navigator.languages[0] : navigator['userLanguage']
                    || navigator.language
                    || navigator['browserLanguage']
                    || 'en';
            };
            return Localisation;
        }());
        function Load() {
            var localisation = {
                Localisation: new Localisation()
            };
            if (window['Blazored']) {
                window['Blazored'] = __assign({}, window['Blazored'], localisation);
            }
            else {
                window['Blazored'] = __assign({}, localisation);
            }
        }
        Localisation_1.Load = Load;
    })(Localisation = Blazored.Localisation || (Blazored.Localisation = {}));
})(Blazored || (Blazored = {}));
Blazored.Localisation.Load();
//# sourceMappingURL=Blazored.Localisation.js.map