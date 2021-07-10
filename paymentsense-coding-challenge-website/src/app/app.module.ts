import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PaymentsenseCodingChallengeApiService } from './services';
import { HttpClientModule } from '@angular/common/http';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { CountriesComponent } from './components/countries/countries/countries.component';
import { NavbarComponent } from './components/navbar/navbar/navbar.component';
import { MaterialModule } from './material.module';
import { CountriesService } from './services/country.service';
import { DetailsComponent } from './components/details/details/details.component';

@NgModule({
  declarations: [
    AppComponent,
    CountriesComponent,
    NavbarComponent,
    DetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FontAwesomeModule,
    MaterialModule
  ],
  providers: [CountriesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
