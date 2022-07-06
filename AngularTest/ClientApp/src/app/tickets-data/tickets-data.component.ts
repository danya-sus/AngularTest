import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { saveAs } from 'file-saver';

@Component({
  selector: 'app-tickets-data',
  templateUrl: './tickets-data.component.html'
})
export class TicketsDataComponent {
  public tickets: Ticket[];
  public airlines: Airline[];
  public tempTickets: Ticket[];
  public dNumber: string;
  public tNumber: string;
  public airline: string;
  public isChecked: boolean;

  constructor(private httpClient: HttpClient) {
    this.isChecked = true;
    this.httpClient.get<Airline[]>('transactions/airlines').subscribe(result => {
      this.airlines = result;
    }, error => console.error(error));
  };

  public getByDocNumber() {
    this.httpClient.post<Ticket[]>('transactions/by_doc_number', {
      docNumber: this.dNumber
    }, {headers: {
        'Content-Type': 'application/json',
        Accept: 'application/json'
      }
    }).subscribe(result => {
      this.tickets = result;
    }, error => console.error(error));
  }

  public getByTicketNumber() {
    this.httpClient.post<Ticket[]>('transactions/by_ticket_number', {
      ticketNumber: this.tNumber,
      isChecked: !this.isChecked
    }, {headers: {
        'Content-Type': 'application/json',
        Accept: 'application/json'
      }
    }).subscribe(result => {
      this.tickets = result;
    }, error => console.error(error));
  }

  public clearDocNum() {
    this.dNumber = "";
  }

  public clearTicketNum() {
    this.tNumber = "";
  }

  public toFile() {
    this.tickets.forEach(val => this.tempTickets.push(Object.create(val)));

    this.tempTickets.forEach(t => {
      if (!this.airline.includes(t.airlineCode)) {
        t.place = "";
        t.sender = "";
        t.ticketNumber = "******" + t.ticketNumber.slice(6);
        t.airlineRouteId = null;
        t.airlineCode = "";
        t.departPlace = "";
        t.arrivePlace = "";
        t.arriveDatetime = "";
        t.pnrID = "";
        t.operatingAirlineCode = "";
        t.cityFromCode = "";
        t.cityFromName = "";
        t.airportFromIcaoCode = "";
        t.airportFromRfCode = "";
        t.airportFromName = "";
        t.cityToCode = "";
        t.cityToName = "";
        t.airportToIcaoCode = "";
        t.airportToRfCode = "";
        t.airportToName = "";
        t.flightNums = "";
        t.fareCode = "";
        t.farePrice = null;
      }
    })

    const replacer = (key, value) => value === null ? '' : value;
    const header = Object.keys(this.tempTickets[0]);

    let csv = this.tempTickets.map(row => header.map(fieldName => JSON.stringify(row[fieldName], replacer)).join(','));
    csv.unshift(header.join(','));
    let csvArray = csv.join('\r\n');

    var blob = new Blob([csvArray], { type: 'text/csv' });
    saveAs(blob, "myFile.csv");
  }
}

interface Ticket {
  operationId: bigint;
  type: string;
  time: any;
  place: string;
  sender: string;
  transactionTime: string;
  validationStatus: string;
  operationTimeTimezone: number;
  passengerId: bigint;
  surname: string;
  name: string;
  patronymic: string;
  birthdate: any;
  genderId: number;
  passengerDocumentId: bigint;
  passengerDocumentType: string;
  passengerDocumentNumber: string;
  passengerDocumentDisabledNumber: string;
  passengerDocumentLargeNumber: string;
  passengerTypeId: number;
  passengerTypeName: string;
  passengerTypeType: string;
  raCategory: string;
  description: string;
  isQuota: boolean;
  ticketId: bigint;
  ticketNumber: string;
  ticketType: number;
  airlineRouteId: bigint;
  airlineCode: string;
  departPlace: string;
  departDatetime: any;
  arrivePlace: string;
  arriveDatetime: any;
  pnrID: string;
  operatingAirlineCode: string;
  departDatetimeTimezone: number;
  arriveDatetimeTimezone: number;
  cityFromCode: string;
  cityFromName: string;
  airportFromIcaoCode: string;
  airportFromRfCode: string;
  airportFromName: string;
  cityToCode: string;
  cityToName: string;
  airportToIcaoCode: string;
  airportToRfCode: string;
  airportToName: string;
  flightNums: string;
  fareCode: string;
  farePrice: number;
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
