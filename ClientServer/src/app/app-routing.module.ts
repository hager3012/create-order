import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateOrderComponent } from './components/create-order/create-order.component';

const routes: Routes = [
    {path:'',redirectTo:'Order/Create',pathMatch:'full'},
    {path:'Order/Create',component:CreateOrderComponent,title:"CreateOrder"}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
