import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { Country } from 'src/app/interfaces/country';
import { CountriesService } from 'src/app/services/country.service';

@Component({
  selector: 'app-countries',
  templateUrl: './countries.component.html',
  styleUrls: ['./countries.component.scss']
})

export class CountriesComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  dataSource: any;
  COLUMNS = ['name', 'capital', 'flag', 'view'];
  loading:boolean;

  constructor(private countriesService: CountriesService) { this.loading = true; }

  ngOnInit() {
    this.countriesService.getAll().subscribe((data: Country[]) => {
      this.dataSource = new MatTableDataSource<Country>(data);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      this.loading = false;
    }, err => {
      this.loading = false;
      console.log(err);
    });
  }

  filterData(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}