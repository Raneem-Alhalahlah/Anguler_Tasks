import { Component } from '@angular/core';
import { URLService } from '../RaneemURL/url.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  constructor(private _ser: URLService, private _router: Router) { }



  checkIfUserLogin(data: any) {
    var formdata = new FormData();
    for (let item in data) {
      formdata.append(item, data[item])
    }

    this._ser.UserLogin(formdata).subscribe(() => {
      this._router.navigate(['Services']);
    }, (error) => {
      alert(error.error)
    })
  }
}
