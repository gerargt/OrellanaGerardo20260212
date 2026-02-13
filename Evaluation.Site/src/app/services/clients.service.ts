import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

export interface Client {
  country: string;
  id: string;
  name: string;
  phone: string;
  category: number;
}

@Injectable({
  providedIn: 'root'
})
export class ClientsService {

  private readonly baseUrl = environment.apiBaseUrl;

  constructor(private http: HttpClient) {}

  getClients(nameFilter?: string): Observable<Client[]> {
    let params = new HttpParams();
    if (nameFilter) {
      params = params.set('name', nameFilter);
    }

    const url = `${this.baseUrl}/api/clients`;
    return this.http.get<Client[]>(url, { params });
  }
}

