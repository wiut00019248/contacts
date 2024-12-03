import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Contact } from '../../models/contact';
import { NgFor, NgIf } from '@angular/common';
import { ContactService } from '../../services/contact.service';

@Component({
  selector: 'app-main',
  imports: [RouterLink, NgFor, NgIf],
  templateUrl: './main.component.html',
  styleUrl: './main.component.css'
})
export class MainComponent {
  public contacts: Contact[] = [];
  constructor(private contactService: ContactService) { }

  ngOnInit(): void {
    this.contactService.getAllContacts().subscribe(contacts => this.contacts = contacts);
  }

  public clickDelete(id: number | undefined): void {
    if (id) {
      this.contactService.deleteContact(id).subscribe(() => {
        this.contacts = this.contacts.filter(contact => contact.id !== id);
      });
    }
  }
}
