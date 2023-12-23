import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  selectedLanguage: string ='';
  supportLanguage=['en','ar'];
  isArabic:boolean=false;
  constructor(private _TranslateService:TranslateService){
  }
  ngOnInit(): void {
    this._TranslateService.addLangs(this.supportLanguage);
    if(localStorage.getItem("Language") != null){
      // this._TranslateService.setDefaultLang('ar');
      this._TranslateService.use(localStorage.getItem("Language") as string);
      if(localStorage.getItem("Language") == 'ar'){
        this.isArabic=true;
      }
    }
    else{
      this._TranslateService.setDefaultLang('en');
      this._TranslateService.use('en');
    }

    // const browserlang = this._TranslateService.getBrowserLang();

    // console.log('Browser Language => ', browserlang);

    // if (this.supportLanguage.includes(browserlang!)) {
    //   this._TranslateService.use(browserlang!);
    // }
    this.selectedLanguage = localStorage.getItem("Language")||'en';
    console.log(this.selectedLanguage);

  }
  changeLanguage(event: any): void{
    localStorage.setItem("Language",event.target.value);
    console.log('selected language ==> ', localStorage.getItem("Language") as string);
    this._TranslateService.use(localStorage.getItem("Language") as string);
    window.location.reload();

  }
}
