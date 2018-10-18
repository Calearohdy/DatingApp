import { AuthService } from './../_services/auth.service';
import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  // Parent to Child Component using Input or Data from Parent => Child, Square brackets when passing down through the component
  @Input() valuesFromHome: any;
  // assign an output to a new EventEmitter for Child => Parent data passing, Parenthesis are used in html compnent
  @Output() cancelRegister = new EventEmitter();
  model: any = {};

  constructor(private authServce: AuthService) { }

  ngOnInit() {
  }

  register() {
    this.authServce.register(this.model).subscribe(() => {
      console.log('registration successful');
      }, error => {
        console.log(error);
      }
    );
  }

  cancel() {
    this.cancelRegister.emit(false);
    console.log('cancelled');
  }
}
