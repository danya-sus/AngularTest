import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-airlines-data',
  templateUrl: './airlines-data.component.html'
})
export class AirlinesDataComponent {
  public airlines: Airline[];

  constructor(private httpClient: HttpClient) { };

  public getAirlines() {
    this.httpClient.get<Airline[]>('transactions/airlines').subscribe(result => {
      this.airlines = result;
    }, error => console.error(error));
  }
}

interface Airline {
  id: number;
  name: string;
  nameEn: string;
  icaoCode: string;
  iataCode: string;
  rfCode: string;
  country: string;
}
