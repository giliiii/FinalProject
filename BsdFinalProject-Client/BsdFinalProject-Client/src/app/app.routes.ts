import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login';
import { Home as UserHome } from './components/user/home/home';
import { Home as ManagerHome } from './components/manager/home/home';
import { RegisterComponent}  from './components/register/register';

export const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'login', component: LoginComponent },
  { path: 'user/home', component: UserHome },
  { path: 'manager/home', component: ManagerHome },
  { path: 'register', component: RegisterComponent },
  { path: '**', redirectTo: '' }
];
