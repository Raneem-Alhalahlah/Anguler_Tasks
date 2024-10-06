import { Component } from '@angular/core';
import { URLService } from '../RaneemURL/url.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-regester',
  templateUrl: './regester.component.html',
  styleUrl: './regester.component.css'
})
export class RegesterComponent {


  ngOnInit() {
  
  }



 
  constructor(private _src: URLService, private _router: Router) {

  }



  regesterUserCall(data: any) {
    
    var form = new FormData();
    for (let key in data) {
      form.append(key, data[key])
    }
    this._src.regesteruser(form).subscribe(() => {
     
      alert("user add sucssefully")
      this._router.navigate(['Login']);

    },
      (error) => {
        alert(error.error)
      }

    )


    }
  }












