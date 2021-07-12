import { Component, OnInit } from '@angular/core';
import { Country } from 'src/app/interfaces/country';
import { CountriesService } from 'src/app/services/country.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material';
import { Currency } from 'src/app/interfaces/currency';

@Component({
  selector: 'app-addcountry',
  templateUrl: './addcountry.component.html',
  styleUrls: ['./addcountry.component.scss']
})

export class AddcountryComponent implements OnInit {

  constructor(private countriesService: CountriesService, private matSnackBar: MatSnackBar) {
  }

  countryForm = new FormGroup({
    countryName: new FormControl('', Validators.required),
    capital: new FormControl('', Validators.required),
  });

  ngOnInit() {
  }

  onSubmit() {
    // TODO: No time to design the UI, so added dummy values for other props. 
    var country = new Country();
    country.name = this.countryForm.value.countryName;
    country.capital = this.countryForm.value.capital;
    country.flag = "https://restcountries.eu/data/ggy.svg";
    country.population = 200000;
    country.timezones = ["UTC+06:00"];
    country.borders = ["CHN", "IND"];    
    this.countriesService.addCountry(country).subscribe((data) => {
      this.matSnackBar.open(this.countryForm.value.countryName + " added successfully.", '', { duration: 3000, verticalPosition: 'top' })
    });
  }
}