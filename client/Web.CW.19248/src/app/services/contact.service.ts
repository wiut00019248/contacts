import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Contact } from '../models/contact';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  private serverUrl = 'http://localhost:5224/api/Contact';
  constructor(private client: HttpClient) { }

  public getAllContacts(): Observable<Contact[]> {
    let url = `${this.serverUrl}/GetAll`;
    return this.client.get<Contact[]>(url);
  };

  public getContact(id: number): Observable<Contact> { 
    let url = `${this.serverUrl}/GetContact/${id}`;
    return this.client.get<Contact>(url);
  };

  public addContact(contact: Contact): Observable<Contact> {
    let url = `${this.serverUrl}/CreateContact`;
    return this.client.post<Contact>(url, contact);
  };

  public updateContact(contact: Contact, id: number): Observable<Contact> {
    let url = `${this.serverUrl}/UpdateContact/${id}`;
    return this.client.put<Contact>(url, contact);
  };

  public deleteContact(id: number): Observable<Contact> {
    let url = `${this.serverUrl}/DeleteContact/${id}`;
    return this.client.delete<Contact>(url);
  }
}
