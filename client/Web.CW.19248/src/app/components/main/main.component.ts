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
  public filteredContacts: Contact[] = [];

  constructor(private contactService: ContactService) { }

  ngOnInit(): void {
    this.contactService.getAllContacts().subscribe(contacts => {
      this.contacts = contacts;
      this.filteredContacts = [...contacts];
    });
  }

  public clickDelete(id: number | undefined): void {
    if (id) {
      this.contactService.deleteContact(id).subscribe(() => {
        this.contacts = this.contacts.filter(contact => contact.id !== id);
        this.filteredContacts = this.filteredContacts.filter(contact => contact.id !== id);
      });
    }
  }

  public searchContact(event: Event, name: string): void {
    event.preventDefault(); 
    if (name) {
      this.filteredContacts = this.contacts.filter(contact =>
        contact.name.toLowerCase().includes(name.toLowerCase())
      );
    } else {
      this.filteredContacts = [...this.contacts];
    }
  }
}
