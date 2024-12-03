import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { Contact } from '../../models/contact';
import { Category } from '../../models/category';
import { ContactService } from '../../services/contact.service';
import { CategoryService } from '../../services/category.service';
import { NgFor, NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-add',
  imports: [RouterLink, NgIf, NgFor, FormsModule],
  templateUrl: './add.component.html',
  styleUrl: './add.component.css'
})
export class AddComponent {
  public contact: Contact = {} as Contact;
  public categories: Category[] = [] as Category[];

  constructor(
    private router: Router,
    private contactService: ContactService,
    private categoryService: CategoryService
  ) {}

  ngOnInit(): void {
    this.categoryService.getAllCategories().subscribe(categories => this.categories = categories);
  }

  public createSubmit(): void {
    this.contactService.addContact(this.contact).subscribe(() => {
      this.router.navigate(['/']);
    });
  }
}
