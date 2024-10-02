import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class URLService {

  constructor(private http: HttpClient) { }
  staticData = "https://localhost:7130/api";
  getServices(): Observable<any> {
    return this.http.get<any>(`${this.staticData}/Services`);
  }

  getSubsicription(): Observable<any> {
    return this.http.get<any>(`${this.staticData}/Subsicription`);
  }

  getSubServiceByID(id: any): Observable<any> {
    return this.http.get<any>(`${this.staticData}/SubServices/GetSubServicesbyServiceID/${id}`);
  }

  //addUserSubscribtion(data: any): Observable<any> {
  //  return this.http.post<any>(`${this.staticData}/userSubscription`,data)
  //}

  getSubServiceDetails(id: any): Observable<any> {
    return this.http.get<any>(`${this.staticData}/SubServices/GetSubServicesbyID/${id}`);
  }

  addusersubscription(data: any): Observable<any> {
    return this.http.post<any>(`${this.staticData }/userSubscription`, data)

  }



  regesteruser(data: any): Observable<any> {
    return this.http.post(`https://localhost:7130/api/User/addUser`, data)
  }

  UserLogin(data: any): Observable<any> {
    return this.http.post<any>(`${this.staticData}/User/Login`, data)
  }



 
}
