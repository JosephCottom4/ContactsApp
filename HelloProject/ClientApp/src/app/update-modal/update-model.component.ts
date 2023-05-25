import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';

interface Contact {
  id: number; // Add the ID property
  firstName: string;
  lastName: string;
  phoneNumber: string;
}

@Component({
  selector: 'app-update-modal',
  templateUrl: './update-modal.component.html'
})
export class UpdateModalComponent implements OnInit {
  contact: Contact = {
    id: 0,
    firstName: '',
    lastName: '',
    phoneNumber: ''
  };

  constructor(
    private http: HttpClient,
    private router: Router,
    private route: ActivatedRoute,
    @Inject('BASE_URL') private baseUrl: string
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const contactId = params['id'];
      this.http.get<Contact>(this.baseUrl + `contacts/${contactId}`)
        .subscribe(
          (data) => {
            this.contact = data;
          },
          (error) => {
            console.error('Error fetching contact:', error);
          }
        );
    });
  }

  updateContact() {
    this.http.put(this.baseUrl + 'contacts', this.contact)
      .subscribe(
        () => {
          console.log('Contact updated successfully!');
          this.router.navigate(['']);
        },
        (error) => {
          console.error('Error updating contact:', error);
        }
      );
  }
}
