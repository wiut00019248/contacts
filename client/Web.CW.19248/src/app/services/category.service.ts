import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Contact } from '../models/contact';
import { Category } from '../models/category';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private serverUrl = 'http://localhost:5224/api/Category';
  constructor(private client: HttpClient) { }

  public getAllCategories(): Observable<Category[]> {
    let url = `${this.serverUrl}/GetAll`;
    return this.client.get<Category[]>(url);
  }

  public getCategory(contact: Contact): Observable<Category> {
    let url = `${this.serverUrl}/GetCategory/${contact.categoryId}`;
    return this.client.get<Category>(url);
  }
}
