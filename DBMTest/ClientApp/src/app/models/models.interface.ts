export interface CreditCardI {
  creditCardNumber: string;
  balance: number;
  limit: number;
  limitAvailable: number;
  type: string;
  creditCardNamePlusType?: string;
  validCreditCardNumber?: string;
}

export interface CustomerI {
  name: string;
  creditCards: CreditCardI[]
}

export interface CardChargeI {
  customerName: string;
  creditCardNumber: string;
  amountToCharge: number;
}

export interface ResponceCardCharge {
  reason: string;
  success: boolean;
  payload?: any;
}