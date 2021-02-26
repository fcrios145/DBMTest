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
  public customerValue: string;
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

  onSelectCreditCard(type: string): void {
    this.creditCardSelected = this.selectedCustomerLive.creditCards.find(item => item.type == type)
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
        this.creditCardSelected = <CreditCardI>result.payload;
        this.http.get<CustomerI[]>('customer').subscribe(result => {
          this.customers = result;
          this.chargeAmount = 0;
          alert("Updated");
        }, error => console.error(error));
      } else {
        alert(result.reason);
      }
    }, error => console.error(error));
  }
}
