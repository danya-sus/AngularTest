import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { AirlinesDataComponent } from './airlines-data/airlines-data.component';
import { TicketsDataComponent } from './tickets-data/tickets-data.component';

@NgModule({
  declarations: [
    AppComponent,
    AirlinesDataComponent,
    TicketsDataComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: TicketsDataComponent, pathMatch: 'full' },
      { path: 'airlines-data', component: AirlinesDataComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
