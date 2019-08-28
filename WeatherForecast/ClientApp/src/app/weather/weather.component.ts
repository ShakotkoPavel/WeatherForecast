import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Weather } from 'src/app/weather'
import { RequestOptions } from 'src/app/requestOptions';
import { NgForm } from '@angular/forms';
import { WeatherService } from 'src/app/shared/weatherService';
 
@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html'
})

export class WeatherComponent implements OnInit {
  public forecasts: Weather[];
  public requestOptions: RequestOptions = new RequestOptions();
  //public unit: string = "Fahrenheit";
  //public lang: string = En

  constructor(private http: HttpClient, private weatherService: WeatherService) {

  }

  ngOnInit() {

  }

  getWeather(form: NgForm) {
    this.weatherService.getWeather(this.requestOptions.getRequestOptions()).subscribe(
      data => {
        this.forecasts = data
      },
      err => {
        console.log(err)
      }
    );
  }

  toUnit(event) {
    this.requestOptions.unit = event.target.value;
  }

  toLanguage(event) {
    this.requestOptions.language = event.target.value;
  }
}
