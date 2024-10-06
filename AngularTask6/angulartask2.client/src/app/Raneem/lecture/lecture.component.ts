import { Component } from '@angular/core';

@Component({
  selector: 'app-lecture',
  templateUrl: './lecture.component.html',
  styleUrl: './lecture.component.css'
})
export class LectureComponent {

  name: string = "raneem";
  num: number = 1;

  onchange() {
    this.name = "Jana"
       }
}
