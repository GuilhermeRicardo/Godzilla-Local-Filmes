import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { LoginComponent } from './login/login.component';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent { 

  constructor (
    public dialog:MatDialog
  ) { }

  loginDialog() {
    const dialogRef = this.dialog.open(LoginComponent, {
      width: '250px'
    })

  }

}
