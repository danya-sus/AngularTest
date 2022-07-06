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
  public dNumber: string;
  public tNumber: string;

  constructor(private httpClient: HttpClient) { };

  public getTickets() {
    this.httpClient.get<Ticket[]>('transactions/tickets').subscribe(result => {
      this.tickets = result;
    }, error => console.error(error));
  }

  public getByDocNumber(docNumber: string) {
    this.httpClient.get<Ticket[]>('transactions/by_doc_number/' + docNumber).subscribe(result => {
      this.tickets = result;
    }, error => console.error(error));
  }

  public getByTicketNumber(ticketNumber: string) {
    this.httpClient.get<Ticket[]>('transactions/by_ticket_number/' + ticketNumber).subscribe(result => {
      this.tickets = result;
    }, error => console.error(error));
  }

  public clearDocNum() {
    this.dNumber = "";
  }

  public clearTicketNum() {
    this.tNumber = "";
  }

  public getAirlines() {
    this.httpClient.get<Airline[]>('transactions/airlines').subscribe(result => {
      this.airlines = result;
    }, error => console.error(error));
  }

  public toFile() {
    const replacer = (key, value) => value === null ? '' : value; // specify how you want to handle null values here
    const header = Object.keys(this.tickets[0]);
    let csv = this.tickets.map(row => header.map(fieldName => JSON.stringify(row[fieldName], replacer)).join(','));
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
