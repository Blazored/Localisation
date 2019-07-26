namespace Blazored.Localisation {
    class Localisation {
        public GetBrowserLocale(): string {
            return (navigator.languages && navigator.languages.length) ? navigator.languages[0] : navigator['userLanguage']
                || navigator.language
                || navigator['browserLanguage']
                || 'en';
        }

        public GetBrowserTimeZoneOffset(): number {
            return new Date().getTimezoneOffset();
        }

        public GetBrowserTimeZoneIdentifier(): string {
            return Intl.DateTimeFormat().resolvedOptions().timeZone;
        }
    }

    export function Load(): void {
        const localisation: any = {
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
