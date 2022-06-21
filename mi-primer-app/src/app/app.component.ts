import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserProvider } from './providers/user.provider';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Bienvenidos 2w1';
  url = 'https://www.google.com.ar/'

  constructor(private userProvider: UserProvider, private router: Router){}

  logout(){
    this.userProvider.setUserLogout();
    this.router.navigateByUrl('/login');
    alert("Cerrando sesión");
  }
}
