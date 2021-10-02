import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private fb: FormBuilder, private http: HttpClient) { }

  readonly BaseURI = 'http://localhost:63148/api';

  formModel = this.fb.group({
    UserName: ['', Validators.required],
    Password: this.fb.group({
      Password: ['', [Validators.required, Validators.minLength(4)]]})
  });

  login(formData: any) {
      console.log(formData);
    return this.http.post(this.BaseURI + '/Auth/Login', formData);
  }
}
