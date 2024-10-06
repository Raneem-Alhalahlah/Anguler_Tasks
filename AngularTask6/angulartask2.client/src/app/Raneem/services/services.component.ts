import { Component } from '@angular/core';
import { URLService } from '../RaneemURL/url.service';

@Component({
  selector: 'app-services',
  templateUrl: './services.component.html',
  styleUrl: './services.component.css'
})
export class ServicesComponent {
  ngOnInit() {
    this.getService()
  }
  constructor(private _ser:
    URLService) { }

  servicesArray: any
  getService() {

    this._ser.getServices().subscribe((data) => {
      this.servicesArray = data
      console.log(this.servicesArray)

    })
  }
}
