import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddcountryComponent } from './components/addcountries/addcountry/addcountry.component';
import { CountriesComponent } from './components/countries/countries/countries.component';
import { DetailsComponent } from './components/details/details/details.component';

const routes: Routes = [
  { path: '', component: CountriesComponent },
  { path: 'detail/:name', component: DetailsComponent },
  { path: 'addcountry', component: AddcountryComponent },
  { path: '**', component: CountriesComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
