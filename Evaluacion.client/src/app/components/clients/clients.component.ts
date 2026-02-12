import { Component, OnInit } from '@angular/core';

import { FormsModule } from '@angular/forms';
import { Client, ClientsService } from '../../services/clients.service';

@Component({
  selector: 'app-clients',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './clients.component.html'
})
export class ClientsComponent implements OnInit {

  clients: Client[] = [];
  nameFilter: string = '';
  loading: boolean = false;

  constructor(private clientsService: ClientsService) {}

  ngOnInit(): void {
    this.loadClients();
  }

  loadClients(): void {
    this.loading = true;
    this.clientsService.getClients(this.nameFilter).subscribe({
      next: (data) => {
        this.clients = data;
        this.loading = false;
      },
      error: (error) => {
        console.error(error);
        this.loading = false;
      }
    });
  }

  onSearch(): void {
    this.loadClients();
  }

  onClear(): void {
    this.nameFilter = '';
    this.loadClients();
  }
}

