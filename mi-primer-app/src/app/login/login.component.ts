import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../interfaces/user';
import { UserProvider } from '../providers/user.provider';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  username: string = '';
  password: string = '';

  constructor(private userProvider: UserProvider, private router: Router) { }

  ngOnInit(): void {
  }

  login(){
    this.userProvider.login(this.username, this.password)
      .subscribe({
        next: (response: User) => this.handleSuccess(response),
        error: (error) => alert(error),
        complete: () => console.log("Terminó la petición.")
      });
  }

  handleSuccess(response: User){
    this.userProvider.setUserLogged();
    this.router.navigateByUrl('/users');
    alert("Hola " + response.name);
  }
}
