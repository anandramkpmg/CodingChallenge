import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Languages } from 'src/app/interfaces/languages';
import { MatTableDataSource } from '@angular/material';
import { CountriesService } from 'src/app/services/country.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit {
  name: string;
  cards: any[];
  languagesDatasource: any;
  LANGUAGES_COLUMNS = ['iso639_1', 'iso639_2', 'name', 'nativeName'];

  constructor(
    private activatedRoute: ActivatedRoute,
    private countriesService: CountriesService
  ) {
    this.cards = [];
    this.activatedRoute.params.subscribe(params => this.name = params['name']);
  }

  ngOnInit() {
    this.countriesService.getCountry(this.name).subscribe(data => {
      console.log("received", data);
      this.languagesDatasource = new MatTableDataSource<Languages>(data.languages);
      this.cards = [
        { title: 'Flag', cols: 1, rows: 1, flag: data.flag },
        { title: 'Currencies', cols: 1, rows: 1, currencies: data.currencies },
        { title: 'Languages', cols: 1, rows: 1 },
        { title: 'Info', cols: 1, rows: 1, borders: data.borders, capital: data.capital, population: data.population, timezones: data.timezones },
      ];
    }, err => {
      console.log(err);
    });
  }
}
