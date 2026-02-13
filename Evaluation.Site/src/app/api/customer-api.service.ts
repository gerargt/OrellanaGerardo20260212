import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

export interface CustomerItem {
  country: string;
  id: string;
  name: string;
  phone: string;
  category: number;
}

@Injectable({
  providedIn: 'root'
})
export class CustomerApiService {

  private readonly apiHost = environment.apiBaseUrl;

  constructor(private httpClient: HttpClient) {}

  getList(filterByName?: string): Observable<CustomerItem[]> {
    let queryParams = new HttpParams();
    if (filterByName && filterByName.trim() !== '') {
      queryParams = queryParams.set('name', filterByName.trim());
    }
    const endpoint = `${this.apiHost}/api/clients`;
    return this.httpClient.get<CustomerItem[]>(endpoint, { params: queryParams });
  }
}
