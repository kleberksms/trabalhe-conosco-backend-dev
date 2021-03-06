import { DefaultComponent } from './default/default.component';
import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from './_guards/auth.guard';

import { LoginComponent } from './login/login.component';
import { UsersComponent } from './users/users.component';

const APP_ROUTES: Routes = [
    { path: '', component: DefaultComponent },
  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(APP_ROUTES);