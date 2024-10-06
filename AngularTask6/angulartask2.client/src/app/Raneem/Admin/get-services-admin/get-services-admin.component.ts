import { Component } from '@angular/core';
import { URLService } from '../../RaneemURL/url.service';

@Component({
  selector: 'app-get-services-admin',
  templateUrl: './get-services-admin.component.html',
  styleUrl: './get-services-admin.component.css'
})

export class GetServicesAdminComponent {
  ngOnInit() {
    this.getServicesAdmin()
  }
  
  array: any;
  constructor(private _ser: URLService) { }

  getServicesAdmin() {
    this._ser.getServices().subscribe((data) => {
      this.array = data;
    })
  }

}

