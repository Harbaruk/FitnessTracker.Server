import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from '../app.component';
import { RegistrationComponent } from '../registration/registration.component';
import { LoginComponent } from '../login/login.component';
import { ForgotpassComponent } from '../forgotpass/forgotpass.component';
import { MainComponent } from '../main/main.component';
import { ProfileComponent } from '../profile/profile.component';


export const router: Routes = [
    {
        path: '',
        redirectTo: 'registration',
        pathMatch: 'full'
    },
    {
        path: 'registration',
        component: RegistrationComponent
    },
    {
        path: 'login',
        component: LoginComponent
    }
    ,
    {
        path: 'forgot-password',
        component: ForgotpassComponent
    },
    {
        path: 'main',
        component: MainComponent
    },
    {
        path:'profile',
        component:ProfileComponent
    }
];

export const routes: ModuleWithProviders = RouterModule.forRoot(router);
