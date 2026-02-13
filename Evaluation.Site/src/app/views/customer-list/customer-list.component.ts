import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CustomerItem, CustomerApiService } from '../../api/customer-api.service';

@Component({
  selector: 'app-customer-list',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './customer-list.component.html'
})
export class CustomerListComponent implements OnInit {

  listData: CustomerItem[] = [];
  searchText = '';
  isBusy = false;

  constructor(private customerApi: CustomerApiService) {}

  ngOnInit(): void {
    this.refreshList();
  }

  refreshList(): void {
    this.isBusy = true;
    this.customerApi.getList(this.searchText).subscribe({
      next: (result) => {
        this.listData = result;
        this.isBusy = false;
      },
      error: (err) => {
        console.error(err);
        this.isBusy = false;
      }
    });
  }

  runSearch(): void {
    this.refreshList();
  }

  clearFilters(): void {
    this.searchText = '';
    this.refreshList();
  }
}
