import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { OrdersDetailsComponent } from './../orders-details/orders-details.component';
import {   FormBuilder, FormGroup, Validators } from '@angular/forms';
import { OrdersServices } from './../../core/services/orders-services.service';

@Component({
  selector: 'app-create-order',
  templateUrl: './create-order.component.html',
  styleUrls: ['./create-order.component.css']
})
export class CreateOrderComponent implements OnInit{
  constructor(public dialog: MatDialog,private _fb:FormBuilder,private _OrdersServices:OrdersServices) {

  }
  ngOnInit(): void {
  }
  form=this._fb.group({
    customerName:['',[Validators.required]],
    orderDate:['',[Validators.required]]
  })
  openDialog(form :FormGroup) {
    console.log(form.value);
    this._OrdersServices.customerName=this.form.controls.customerName.value as string;
    this._OrdersServices.orderdate=this.form.controls.orderDate.value as string;
    const dialogRef = this.dialog.open(OrdersDetailsComponent);
    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

}
