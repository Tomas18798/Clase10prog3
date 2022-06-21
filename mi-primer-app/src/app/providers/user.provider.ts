import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { catchError, Observable, throwError } from "rxjs";
import { User } from "../interfaces/user";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn: 'root'
})
export class UserProvider {
    constructor(private http: HttpClient){}

    login(username: string, password: string): Observable<any> {
        const request = {
            username: username,
            password: password
        };

        const url = environment.url + 'User/login';
        const header = { 'content-type': 'application/json' };

        return this.http.post<User>(url, request, { 'headers': header}).pipe(catchError(this.handleError));
    }                                                      // con pipe interceptamos el error y lo podemos manejar //                                         

    private handleError(error: HttpErrorResponse){
        if(error.status === 0){
            console.log("algo pasó, error: " + error.message);
        }
        else{
            console.log("Status code: " + error.status);
            console.log(error);
        }
        return throwError(() => new Error(error.error));
    }

    getAll(): Observable<User[]> {
        const url = "https://localhost:7132/User";
        return this.http.get<User[]>(url).pipe(catchError(this.handleError));
    }

    setUserLogged() {
        sessionStorage.setItem("logged", "true");
    }

    setUserLogout() {
        sessionStorage.removeItem("logged");
    }

    isLogged() :boolean {
        return sessionStorage.getItem("logged") === "true";
    }
}