import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CustomerI, CreditCardI, CardChargeI } from '../models/models.interface';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public customers: CustomerI[];
  public creditCardSelected: CreditCardI;
  emptyCreditCards: CreditCardI[] = [{ creditCardNumber: "0000", balance: 0, limit: 0, limitAvailable: 0, type: "EMPTY", creditCardNamePlusType: "EMPTY" }]
  public selectedCustomerLive: CustomerI = { name: "test", creditCards: this.emptyCreditCards };
  public creditCardValue: string;
  public customerValue: string;


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.creditCardSelected = { creditCardNumber: "0000", balance: 0, limit: 0, limitAvailable: 0, type: "EMPTY", creditCardNamePlusType: "EMPTY" };
    http.get<CustomerI[]>(baseUrl + 'customer').subscribe(result => {
      this.customers = result;
      console.log(this.customers);
    }, error => console.error(error));
  }

  onSelect(name: string): void {
    this.selectedCustomerLive = this.customers.find(item => item.name == name)
    this.creditCardSelected = this.selectedCustomerLive.creditCards[0];
    this.creditCardValue = this.creditCardSelected.type;
  }

  onSelectCreditCard(type: string): void {
    this.creditCardSelected = this.selectedCustomerLive.creditCards.find(item => item.type == type)
  }

  purchase(http: HttpClient, @Inject('BASE_URL') baseUrl: string): void {
    const cardCharge: CardChargeI =
    {
      customerName: this.selectedCustomerLive.name,
      creditCardNumber: this.creditCardSelected.creditCardNumber,
      amountToCharge: 100
    };
    http.post<CustomerI>(baseUrl + 'card/charge', cardCharge).subscribe(result => {
    }, error => console.error(error));
  }
}
