import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { UserService } from './shared/user.service';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserloginComponent } from './userlogin/userlogin.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { EmployeesComponent } from './home/employees/employees.component';
import { HttpClientModule } from '@angular/common/http';
import { EmployeeService } from './shared/employee.service';
import { StoreModule } from '@ngrx/store';
// import { dataReducer } from './reducer/data.reducer';
import { EffectsModule } from '@ngrx/effects';
import { EmployeesEffects } from './effects/employees.effects';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './auth/auth.interceptor';
import { employeesReducer } from './reducer/data.reducer';
import { EMPLOYEE_STATE_NAME } from './state/employee.selector';

@NgModule({
  declarations: [
    AppComponent,
    UserloginComponent,
    HomeComponent,
    EmployeesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    StoreModule.forRoot([]),
    EffectsModule.forRoot([]),
    EffectsModule.forFeature([EmployeesEffects]),
    StoreModule.forFeature(EMPLOYEE_STATE_NAME, employeesReducer),

    // StoreModule.forRoot({
    //   message: dataReducer
    // }),
  ],
  providers: [
    UserService,
    EmployeeService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }    
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
