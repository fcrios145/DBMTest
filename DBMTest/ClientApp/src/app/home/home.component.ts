import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CustomerI, CreditCardI, CardChargeI, ResponceCardCharge } from '../models/models.interface';

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
  public creditCardNamePlusType: string;
  public chargeAmount: number;


  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.creditCardSelected = { creditCardNumber: "0000", balance: 0, limit: 0, limitAvailable: 0, type: "EMPTY", creditCardNamePlusType: "EMPTY" };
    this.http.get<CustomerI[]>(baseUrl + 'customer').subscribe(result => {
      this.customers = result;
      console.log(this.customers);
    }, error => console.error(error));
  }

  onSelect(name: string): void {
    this.selectedCustomerLive = this.customers.find(item => item.name == name)
    this.creditCardSelected = this.selectedCustomerLive.creditCards[0];
    this.creditCardValue = this.creditCardSelected.type;
  }

  onSelectCreditCard(creditCardNamePlusType: string): void {
    this.creditCardNamePlusType = creditCardNamePlusType;
    this.creditCardSelected = this.selectedCustomerLive.creditCards.find(item => item.creditCardNamePlusType == creditCardNamePlusType)
  }

  purchase(): void {
    const cardCharge: CardChargeI =
    {
      customerName: this.selectedCustomerLive.name,
      creditCardNumber: this.creditCardSelected.creditCardNumber,
      amountToCharge: this.chargeAmount
    };
    this.http.post<ResponceCardCharge>('card/charge', cardCharge).subscribe(result => {
      if (result.success) {
        this.selectedCustomerLive = <CustomerI>result.payload;
        this.creditCardSelected = this.selectedCustomerLive.creditCards.find(item => item.creditCardNamePlusType == this.creditCardNamePlusType)
      } else {
        alert(result.reason);
      }
    }, error => console.error(error));
  }
}
