import { Weather } from 'src/app/weather';
import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RequestOptions } from 'src/app/requestOptions';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {
  formData: Weather;
  baseUrl: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  getWeather(queryOptions: string) {
    return this.http.get<Weather[]>(this.baseUrl + 'api/weather' + queryOptions);
  }
}
