import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

interface NewContactDto {
  firstName: string;
  lastName: string;
  phoneNumber: string;
}

@Component({
  selector: 'app-create-modal',
  templateUrl: './create-modal.component.html'
})
export class CreateModalComponent {
  contact: NewContactDto = {
    firstName: '',
    lastName: '',
    phoneNumber: ''
  };

  constructor(
    private http: HttpClient,
    private router: Router,
    @Inject('BASE_URL') private baseUrl: string
  ) {
  }

  saveContact() {
    this.http.post(this.baseUrl + `contacts`, this.contact)
      .subscribe(
        () => {
          console.log('Contact created successfully!');

          this.router.navigate(['']);
        },
        (error) => {
          console.error('Error creating contact:', error);
        }
      );

  }
}
