import { Component } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { Contact } from '../../models/contact';
import { Category } from '../../models/category';
import { ContactService } from '../../services/contact.service';
import { CategoryService } from '../../services/category.service';
import { NgFor, NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-edit',
  imports: [RouterLink, NgIf, NgFor, FormsModule],
  templateUrl: './edit.component.html',
  styleUrl: './edit.component.css'
})
export class EditComponent {
  public id: string | null = null;
  public contact: Contact = {} as Contact;
  public categories: Category[] = [] as Category[];

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private contactService: ContactService,
    private categoryService: CategoryService
  ) { }

  ngOnInit(): void { 
    this.activatedRoute.paramMap.subscribe((param) => {
      this.id = param.get('id');
    });
    if (this.id) {
      this.contactService.getContact(parseInt(this.id)).subscribe(contact => {
        this.contact = contact;
        this.categoryService.getAllCategories().subscribe(categories => {
          this.categories = categories;
        });
      }
    )};
  }

  public submitEdit(): void {
    if (this.id) {
      this.contactService.updateContact(this.contact, parseInt(this.id)).subscribe(() => {
        this.router.navigate(['/']);
      });
    }
  }
}
