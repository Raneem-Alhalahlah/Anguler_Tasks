import { Component } from '@angular/core';
import { URLService } from '../RaneemURL/url.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-sub-services-details',
  templateUrl: './sub-services-details.component.html',
  styleUrl: './sub-services-details.component.css'
})
export class SubServicesDetailsComponent {
  parameter: any
  array: any
  ngOnInit() {
    this.parameter = this._rout.snapshot.paramMap.get('id');
    this.getDetails(this.parameter)
    console.log(this.DetailsArray, "details")
  }

  constructor(private _ser: URLService, private _rout: ActivatedRoute) { }

  DetailsArray: any
  getDetails(id: any) {
    this._ser.getSubServiceDetails(id).subscribe((data) => {
      
      this.DetailsArray = data
    })

  }
}
