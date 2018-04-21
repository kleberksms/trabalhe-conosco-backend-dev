import { DefaultComponent } from './default/default.component';
import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from './_guards/auth.guard';

import { LoginComponent } from './login/login.component';
import { UsersComponent } from './users/users.component';

const APP_ROUTES: Routes = [
    { path: '', component: DefaultComponent, canActivate: [AuthGuard] },
    { path: '/users/:id', component: UsersComponent, canActivate: [AuthGuard] },
    { path: '/users/page/:page', component: UsersComponent, canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent },
  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(APP_ROUTES);