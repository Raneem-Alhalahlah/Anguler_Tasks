import { Component } from '@angular/core';
import { URLService } from '../../RaneemURL/url.service';

@Component({
  selector: 'app-add-services',
  templateUrl: './add-services.component.html',
  styleUrl: './add-services.component.css'
})
export class AddServicesComponent {

  ngOnInut() {

  }



  constructor(private _src: URLService) {

  }

  image: any
  changeImage(event: any) {
    debugger
    this.image = event.target.files[0]

  }

  AddNewService(data: any) {
    var form = new FormData();
    for (let key in data) {
      form.append(key, data[key])
    }
    form.append("ServiceImage", this.image)
    this._src.AddServes11(form).subscribe(() => {
      alert("added")
    })
  }

 


}
