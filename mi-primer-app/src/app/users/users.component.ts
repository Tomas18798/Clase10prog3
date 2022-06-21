import { Component, OnInit } from '@angular/core';
import { User } from '../interfaces/user';
import { UserProvider } from '../providers/user.provider';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  users: User[] = [];

  constructor(private userProvider: UserProvider) { }

  ngOnInit(): void {
    this.userProvider.getAll().subscribe({
      next: (reponse: User[]) => { 
        this.users = reponse;
        console.log(this.users); 
      },
      error: (error) => console.error(error),
      complete: () => console.info('complete') 
    });
  }

}
