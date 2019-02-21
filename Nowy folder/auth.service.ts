import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

interface myData {
  success: boolean,
  message: string
}

@Injectable()

export class AuthService {

  constructor(private http: HttpClient) { }

  getUserDetails(username, password){
    //post these details to api server  return user info if correct
    return this.http.post<myData>('/api/auth.php', {
      username,
      password
    })
  }
}
