import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable } from "rxjs";
import { UserProvider } from "../providers/user.provider";

@Injectable({
    providedIn: 'root'
})
export class UserLoggedGuard implements CanActivate {
    constructor(private userProvider: UserProvider, private router: Router){}

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
        console.log(this.userProvider.isLogged());
        if(!this.userProvider.isLogged())
        {
            return this.router.navigate(['/login']).then(() => false);
        }
        return true;
    }
}