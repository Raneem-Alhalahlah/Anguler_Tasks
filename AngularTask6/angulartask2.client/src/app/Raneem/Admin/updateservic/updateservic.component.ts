import { Component } from '@angular/core';
import { URLService } from '../../RaneemURL/url.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-updateservic',
  templateUrl: './updateservic.component.html',
  styleUrl: './updateservic.component.css'
})
export class UpdateservicComponent {
  ogOnInit() { }
  param: any
  imageFile: any
  changeimageevevnt(event: any) {
    this.imageFile = event.target.files[0]
  }
  constructor(private _ser: URLService, private _active: ActivatedRoute) {
    this.param = this._active.snapshot.paramMap.get('id');
  }
 

  UpdateServiceAdmin(data: any) {
    var form = new FormData();
    for (let key in data) {
      form.append(key, data[key])
    }
    form.append("ServiceImage", this.imageFile)
    this._ser.UpdateService(this.param, form).subscribe((data) => {
      alert("Services Updated Sucessfully")
    })
  }
}
