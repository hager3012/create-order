import { Component, OnInit } from '@angular/core';
import { OrdersServices } from './../../core/services/orders-services.service';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Order } from 'src/app/core/interfaces/order';
import { ToastrService } from 'ngx-toastr';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-orders-details',
  templateUrl: './orders-details.component.html',
  styleUrls: ['./orders-details.component.css']
})
export class OrdersDetailsComponent implements OnInit {
val:string='';
message:string='';
constructor(private _OrdersServices:OrdersServices,
  private _Fb:FormBuilder,
  private toastr: ToastrService,
  private _TranslateService:TranslateService
  ){}
  order=this._Fb.group({
    customerName:[this._OrdersServices.customerName],
    orderDate:[this._OrdersServices.orderdate],
    orderDetails: this._Fb.array([
    ])
  });
  orderDetailsForm=this._Fb.group({
    productName: [''],
    quantity: [],
    price: [],
  });
  createOrderDetailFormGroup() {
    return this._Fb.group({
      productName: [this.orderDetailsForm.controls.productName.value, Validators.required],
      quantity: [this.orderDetailsForm.controls.quantity.value, Validators.required],
      price: [this.orderDetailsForm.controls.price.value, Validators.required],
    });
  }
ngOnInit(): void {

}
get orderDetails(): FormArray {
  return this.order.get('orderDetails') as FormArray;
}
addOrderDetail() {
  this.orderDetails.push(this.createOrderDetailFormGroup());
  this.orderDetailsForm.reset();
}
showToaster(message: string, progress: number) {


  const toastrElement: any = document.getElementsByClassName(
    'toast-progress'
  )[0];
  toastrElement.innerHTML = '<app-progress-bar></app-progress-bar>';
  const progressBarElement: any = document.getElementsByTagName(
    'mat-progress-bar'
  )[0];
  progressBarElement.setAttribute('value', progress.toString());
}
Save():void{
  console.log(this.order.value);
  if(this.order.valid){
    this._OrdersServices.AddOrder(this.order.value as Order).subscribe({
      next:data =>{
        this.order.reset();
        console.log(data);
        this._TranslateService.get('toasterSuccess.val').subscribe((translation: string) => {
          this.val = translation;
        });
        this._TranslateService.get('toasterSuccess.message').subscribe((translation: string) => {
          this.message = translation;
        });
        this.toastr.success(this.val,this.message);
        setTimeout(()=>{
          window.location.reload();
        },5000)
        },
      error:error=>{
        console.log(error);
        this._TranslateService.get('toasterErorr.val').subscribe((translation: string) => {
          this.val = translation;
        });
        this._TranslateService.get('toasterErorr.message').subscribe((translation: string) => {
          this.message = translation;
        });
        this.toastr.error(this.val,this.message);
        setTimeout(()=>{
          window.location.reload();
        },3500)
      }
    }
    )
  }else{
    this._TranslateService.get('toasterErorr.val').subscribe((translation: string) => {
      this.val = translation;
    });
    this._TranslateService.get('toasterErorr.message').subscribe((translation: string) => {
      this.message = translation;
    });
    this.toastr.error(this.val,this.message);
  }

}
}
