import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ToastrModule } from 'ngx-toastr';
import { OrdersDetailsComponent } from './components/orders-details/orders-details.component';
import { CreateOrderComponent } from './components/create-order/create-order.component';
import { NavComponent } from './components/nav/nav.component';
import {  HTTP_INTERCEPTORS, HttpClient, HttpClientModule } from '@angular/common/http';
import { HeaderLanguageInterceptor } from './core/interceptors/header-language.interceptor';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from './core/shared/shared/shared.module';
import { TranslateModule,TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

@NgModule({
  declarations: [
    AppComponent,
    OrdersDetailsComponent,
    CreateOrderComponent,
    NavComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    CommonModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    FormsModule,// required animations module
    NgbModule,
    ToastrModule.forRoot(),
    SharedModule,
    TranslateModule.forRoot({
      loader:{
        provide:TranslateLoader,
        useFactory:(http:HttpClient)=>{return new TranslateHttpLoader(http,'../assets/i18n/','.json');},
        deps:[HttpClient]
      }
    })
  ],
  providers: [
    {
      provide:HTTP_INTERCEPTORS,
      useClass:HeaderLanguageInterceptor,
      multi:true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
