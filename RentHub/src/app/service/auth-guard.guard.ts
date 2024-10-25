import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';
import { UserService } from './user/user.service';

export const AuthGuard: CanActivateFn = (route, state) => {
  
  const userService: any = inject(UserService);
  const router = inject(Router);

  if(userService.isAuthenticated()){
    return true;
  }
  router.navigate(['user/login'])
  return false;
}