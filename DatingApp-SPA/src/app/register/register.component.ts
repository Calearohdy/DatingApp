import { AlertifyService } from './../_services/alertify.service';
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

  constructor(private authServce: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  register() {
    this.authServce.register(this.model).subscribe(() => {
      this.alertify.success('registration successful');
      }, error => {
        this.alertify.error(error);
      }
    );
  }

  cancel() {
    this.cancelRegister.emit(false);
    console.log('cancelled');
  }
}
