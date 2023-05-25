import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public contacts: Contacts[] = [];

  constructor(
    private http: HttpClient,
    private router: Router,
    @Inject('BASE_URL') private baseUrl: string
  ) {
    this.loadContacts();
  }

  loadContacts(): void {
    this.http.get<Contacts[]>(this.baseUrl + 'contacts/all').subscribe(result => {
      this.contacts = result;
    }, error => console.error(error));
  }

  editItem(contact: Contacts): void {
    this.router.navigate(['update', contact.id]);
  }

  deleteItem(contact: Contacts): void {
    // Make an API call to delete the item
    this.http.delete(this.baseUrl + `contacts/${contact.id}`).subscribe(() => {
      // Reload the contacts
      this.loadContacts();
    }, error => console.error(error));
  }

  openCreateModal(): void {
    this.router.navigate(['/create']);
  }
}

interface Contacts {
  id: number;
  dateCreated: Date;
  dateModified: Date | null;
  firstName: string;
  lastName: string;
  phoneNumber: string;
}
