"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var RequestOptions = /** @class */ (function () {
    function RequestOptions() {
        this.city = "New York";
        this.unit = "Fahrenheit";
        this.language = "English";
        this.period = 5;
        this.languageDictionary = new KeyedCollection();
        this.unitsDictionary = new KeyedCollection();
        //this.fillCities();
        this.fillDictionaries();
    }
    Object.defineProperty(RequestOptions.prototype, "period", {
        get: function () {
            return this._period;
        },
        set: function (value) {
            if (value <= 5 && value >= 1) {
                this._period = value;
            }
            else {
                this._period = 5;
            }
        },
        enumerable: true,
        configurable: true
    });
    //private fillCities(): void {
    //  this.getJSON().subscribe(data => {
    //    //this.cities = <City[]>JSON.parse(data);
    //    console.log(this.cities);
    //  }
    //  );
    //}
    //private getJSON(): Observable<any> {
    //  return this.client.get('../assets/city.list.json');
    //}
    RequestOptions.prototype.fillDictionaries = function () {
        this.languageDictionary.Add("Arabic", "ar");
        this.languageDictionary.Add("Bulgarian", "bg");
        this.languageDictionary.Add("Catalan", "ca");
        this.languageDictionary.Add("Czech", "cz");
        this.languageDictionary.Add("German", "de");
        this.languageDictionary.Add("Greek", "el");
        this.languageDictionary.Add("English", "en");
        this.languageDictionary.Add("Persian", "fa");
        this.languageDictionary.Add("Finnish", "fi");
        this.languageDictionary.Add("French", "fr");
        this.languageDictionary.Add("Galician", "gl");
        this.languageDictionary.Add("Croatian", "hr");
        this.languageDictionary.Add("Hungarian", "hu");
        this.languageDictionary.Add("Italian", "it");
        this.languageDictionary.Add("Japanese", "ja");
        this.languageDictionary.Add("Korean", "kr");
        this.languageDictionary.Add("Latvian", "la");
        this.languageDictionary.Add("Lithuanian", "lt");
        this.languageDictionary.Add("Macedonian", "mk");
        this.languageDictionary.Add("Dutch", "nl");
        this.languageDictionary.Add("Polish", "pl");
        this.languageDictionary.Add("Portuguese", "pt");
        this.languageDictionary.Add("Romanian", "ro");
        this.languageDictionary.Add("Russian", "ru");
        this.languageDictionary.Add("Swedish", "se");
        this.languageDictionary.Add("Slovak", "sk");
        this.languageDictionary.Add("Slovenian", "sl");
        this.languageDictionary.Add("Spanish", "es");
        this.languageDictionary.Add("Turkish", "tr");
        this.languageDictionary.Add("Ukrainian", "ua");
        this.languageDictionary.Add("Vietnamese", "vi");
        this.languageDictionary.Add("Chinese_Simplified", "zh_cn");
        this.languageDictionary.Add("Chinese_Traditional", "zh_tw");
        this.unitsDictionary.Add("Fahrenheit", "imperial");
        this.unitsDictionary.Add("Celsius", "metric");
        this.unitsDictionary.Add("Kelvin", "standard");
    };
    RequestOptions.prototype.getRequestOptions = function () {
        var ewqe = this.unitsDictionary.Item(this.unit);
        return "?City=" + this.city + "&Unit=" + this.unitsDictionary.Item(this.unit) + "&Language=" + this.languageDictionary.Item(this.language) + "&Period=" + this.period.toString();
    };
    return RequestOptions;
}());
exports.RequestOptions = RequestOptions;
var KeyedCollection = /** @class */ (function () {
    function KeyedCollection() {
        this.items = {};
    }
    KeyedCollection.prototype.Add = function (key, value) {
        if (!this.items.hasOwnProperty(key))
            this.items[key] = value;
    };
    KeyedCollection.prototype.Item = function (key) {
        return this.items[key];
    };
    KeyedCollection.prototype.Keys = function () {
        var keySet = [];
        for (var prop in this.items) {
            if (this.items.hasOwnProperty(prop)) {
                keySet.push(prop);
            }
        }
        return keySet;
    };
    KeyedCollection.prototype.Values = function () {
        var values = [];
        for (var prop in this.items) {
            if (this.items.hasOwnProperty(prop)) {
                values.push(this.items[prop]);
            }
        }
        return values;
    };
    return KeyedCollection;
}());
exports.KeyedCollection = KeyedCollection;
var Coord = /** @class */ (function () {
    function Coord() {
    }
    return Coord;
}());
exports.Coord = Coord;
var City = /** @class */ (function () {
    function City() {
    }
    return City;
}());
exports.City = City;
//# sourceMappingURL=requestOptions.js.map