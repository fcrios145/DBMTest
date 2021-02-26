import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ClientCallsService {

  constructor(private http: HttpClient) { }
    
  public chargeCard(): void {
    
  }
}
