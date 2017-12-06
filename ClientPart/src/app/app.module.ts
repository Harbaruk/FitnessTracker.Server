import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { LoginComponent } from './login/login.component';
import { AlertModule } from 'ngx-bootstrap';

import { routes } from './app-routing/app-routing.module';
import { RegistrationComponent } from './registration/registration.component';
import { ForgotpassComponent } from './forgotpass/forgotpass.component';
import { MainComponent } from './main/main.component';
import { ProfileComponent } from './profile/profile.component';
import { PlanComponent } from './plan/plan.component';
import { BlocksComponent } from './blocks/blocks.component';
import { ExercisesComponent } from './exercises/exercises.component';
import { UserComponent } from './user/user.component';
import { ApiService } from './services/api.service';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegistrationComponent,
    ForgotpassComponent,
    MainComponent,
    ProfileComponent,
    PlanComponent,
    BlocksComponent,
    ExercisesComponent,
    UserComponent
  ],
  imports: [
      BrowserModule,
      FormsModule,
      HttpModule,
    BrowserModule,
    FormsModule,
    HttpModule,
    routes
  ],
  providers: [ApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
