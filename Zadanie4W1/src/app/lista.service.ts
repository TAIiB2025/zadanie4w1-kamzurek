import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Ksiazka } from '../models/ksiazka';
import { Observable, of } from 'rxjs';
import { KsiazkaBody } from '../models/ksiazka-body';
import { provideHttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class ListaService {
  private apiUrl = 'http://localhost:5003/api/ksiazka';

  constructor(private http: HttpClient) {}

  get(): Observable<Ksiazka[]> {
    return this.http.get<Ksiazka[]>(this.apiUrl);
  }

  getByID(id: number): Observable<Ksiazka> {
    return this.http.get<Ksiazka>(`${this.apiUrl}/${id}`);
  }

  post(body: KsiazkaBody): Observable<void> {
    return this.http.post<void>(this.apiUrl, body);
  }

  put(id: number, body: KsiazkaBody): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, body);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
