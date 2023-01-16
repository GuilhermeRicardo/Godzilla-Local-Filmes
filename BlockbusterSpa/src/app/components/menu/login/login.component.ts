import { MenuComponent } from './../menu.component';
import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit{
  loginForm!: FormGroup


constructor (
  public dialogRef: MatDialogRef<MenuComponent>,
  public FormBuilder:FormBuilder
) {}

  ngOnInit(): void {

    this.loginForm = this.FormBuilder.group({
      email: [''],
      senha: [''],
    });
    
    throw new Error('Method not implemented.');
  }

  onCancel(): void {
    this.dialogRef.close();
  }

}
