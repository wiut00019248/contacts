import { Component, inject } from '@angular/core';
import { ContactService } from '../../services/contact.service';
import { Contact } from '../../models/contact';
import { ActivatedRoute } from '@angular/router';
import { NgIf } from '@angular/common';
import { Category } from '../../models/category';
import { CategoryService } from '../../services/category.service';

@Component({
  selector: 'app-view',
  imports: [NgIf],
  templateUrl: './view.component.html',
  styleUrl: './view.component.css'
})
export class ViewComponent {
  public id: string | null = null;
  public contact: Contact = {} as Contact;
  public category: Category = {} as Category;
  constructor(
    private activedRoute: ActivatedRoute, 
    private contactService: ContactService,
    private categoryService: CategoryService
  ) { }

  public notEmpty(): boolean {
    return Object.keys(this.contact).length > 0 && Object.keys(this.category).length > 0;
  }

  ngOnInit(): void {
    this.activedRoute.paramMap.subscribe((param) => {
      this.id = param.get('id');
    });
    if (this.id) {
      this.contactService.getContact(parseInt(this.id)).subscribe(contact => {
        this.contact = contact;
        this.categoryService.getCategory(contact).subscribe(category => {
          this.category = category;
        })
      });
    }
  }
}
