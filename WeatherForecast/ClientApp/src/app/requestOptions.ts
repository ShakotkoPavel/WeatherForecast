export class RequestOptions {
  private _period: number;

  public city?: string;
  public unit?: string;
  public language?: string;

  set period(value: number) {
    if (value <= 5 && value >= 1) {
      this._period = value;
    }
    else {
      this._period = 5;
    }
  }

  get period(): number {
    return this._period;
  }

  public languageDictionary: IKeyedCollection<string>;
  public unitsDictionary: IKeyedCollection<string>;
  public cities: City[];

  constructor() {
    this.city = "New York";
    this.unit = "Fahrenheit";
    this.language = "English";
    this.period = 5;

    this.languageDictionary = new KeyedCollection<string>();
    this.unitsDictionary = new KeyedCollection<string>();

    //this.fillCities();
    this.fillDictionaries();
  }

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

  private fillDictionaries(): void {

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

  }

  public getRequestOptions(): string {
    let ewqe = this.unitsDictionary.Item(this.unit);
    return "?City=" + this.city + "&Unit=" + this.unitsDictionary.Item(this.unit) + "&Language=" + this.languageDictionary.Item(this.language) + "&Period=" + this.period.toString();
  }
}

export interface IKeyedCollection<T> {
  Add(key: string, value: T);
  Item(key: string): T;
  Keys(): string[];
  Values(): T[];
}

export class KeyedCollection<T> implements IKeyedCollection<T> {
  private items: { [index: string]: T } = {};

  public Add(key: string, value: T) {
    if (!this.items.hasOwnProperty(key))
    this.items[key] = value;
  }

  public Item(key: string): T {
    return this.items[key];
  }

  public Keys(): string[] {
    var keySet: string[] = [];

    for (var prop in this.items) {
      if (this.items.hasOwnProperty(prop)) {
        keySet.push(prop);
      }
    }

    return keySet;
  }

  public Values(): T[] {
    var values: T[] = [];

    for (var prop in this.items) {
      if (this.items.hasOwnProperty(prop)) {
        values.push(this.items[prop]);
      }
    }

    return values;
  }
}

export class Coord {
  lon: number;
  lat: number;
}

export class City {
  id: number;
  name: string;
  country: string;
  coord: Coord;
}
