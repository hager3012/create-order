import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from './../../../environments/environment.development';
import { Order } from '../interfaces/order';
import { FormArray } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

@Injectable({
  providedIn: 'root'
})
export class OrdersServices {
  customerName='';
  orderdate='';

  constructor(private _HttpClient:HttpClient) { }
  AddOrder(order:Order):Observable<Order>{
    return this._HttpClient.post<Order>(`${environment.apiUrl}api/Orders`,order);

  }
}
