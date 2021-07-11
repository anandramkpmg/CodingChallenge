import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BASE_URL } from '../../app/app.global';
import { map } from 'rxjs/operators';
import { Country } from '../interfaces/country';

@Injectable({
  providedIn: 'root'
})
export class CountriesService {
  constructor(private httpClient: HttpClient) { }

  getAll() {
    return this.httpClient.get(BASE_URL);
  }

  getCountry(name: string) {
    let url = `${BASE_URL}/${name}`;
    return this.httpClient.get(url).pipe(
      map(response => {
        return response[0] ? response[0] : [];
      })
    );
  }

  addCountry(country: Country) {
    let url = `${BASE_URL}`;
    console.log(country);

    return this.httpClient.post(url, country).pipe(
      map(response => {
        return response[0] ? response[0] : [];
      })
    );
  }
}