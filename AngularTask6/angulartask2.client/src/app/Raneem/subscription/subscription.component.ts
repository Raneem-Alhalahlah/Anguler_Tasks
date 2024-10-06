import { Component } from '@angular/core';
import { URLService } from '../RaneemURL/url.service';

@Component({
  selector: 'app-subscription',
  templateUrl: './subscription.component.html',
  styleUrl: './subscription.component.css'
})
export class SubscriptionComponent {


  ngOnInit() {
    this.getallSubsicription()
  }


  constructor(protected _src: URLService) {

  }


  getSubsicriptionArray: any
  getallSubsicription() {
    this._src.getSubsicription().subscribe((data) => {
      this.getSubsicriptionArray = data
    })
  }
  data = {

    "userId": 1,
    "subscriptionId": 0,
    "subServiceId": 1
  }

  addusersubscription(id: any) {
    this.data.subscriptionId = id;

    this._src.addusersubscription(this.data).subscribe(() => {
      alert("lknlkdnlkadnfalknl")
    })


  }
}
