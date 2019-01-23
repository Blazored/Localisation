namespace Blazored.Localisation {
    class Localisation {
        public GetBrowserLocale(): string {
            return (navigator.languages && navigator.languages.length) ? navigator.languages[0] : navigator['userLanguage']
                || navigator.language
                || navigator['browserLanguage']
                || 'en';
        }
    }

    export function Load(): void {
        const localisation = {
            Localisation: new Localisation()
        };

        if (window['Blazored']) {
            window['Blazored'] = {
                ...window['Blazored'],
                ...localisation
            }
        } else {
            window['Blazored'] = {
                ...localisation
            }
        }
    }
}

Blazored.Localisation.Load();
