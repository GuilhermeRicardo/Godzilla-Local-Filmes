import { authResult } from '../../../Models/DTO/authResult';
import { LoginService } from './login.service';
import { users } from './../../../Models/users';
import { MenuComponent } from './../menu.component';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  providers: [LoginService]
})
export class LoginComponent implements OnInit{
  loginForm!: FormGroup
  invalidUser!: boolean

constructor (
  public LoginService: LoginService,
  public dialogRef: MatDialogRef<MenuComponent>,
  public FormBuilder:FormBuilder
) {}

  ngOnInit(): void {

    this.invalidUser = false

    this.loginForm = this.FormBuilder.group({
      email: [''],
      senha: [''],
    });
    
    throw new Error('Method not implemented.');
  }

  onCancel(): void {
    this.dialogRef.close();
  }

  tryLogin () {

    let emailLogin = this.loginForm.controls['email'].value
    let senhaLogin = this.loginForm.controls['senha'].value
    let form: users = {
      email: emailLogin,
      password: senhaLogin
    }

    console.log(form);

    this.LoginService.postLogin(form).subscribe((result) =>
    { 
      localStorage.setItem("Authentication", result.token)
      this.dialogRef.close(result)
    },
    (error) => {
      console.log(error);
      this.invalidUser=true
    }
    );
  }

}
