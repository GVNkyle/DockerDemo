import { Component, OnInit } from '@angular/core';
import { ConfirmBoxEvokeService, ToastEvokeService } from '@costlydeveloper/ngx-awesome-popup';
import { NgxSmartModalService } from 'ngx-smart-modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { catchError, firstValueFrom, of, tap } from 'rxjs';
import { Pagination } from 'src/app/_core/helpers/utilities/pagination-utility';
import { AddressDTO } from 'src/app/_core/models/addressDto';

import { AddressService } from '../../../_core/services/address.service'
import { AddAddressComponent } from '../add-address/add-address.component';


@Component({
  templateUrl: 'dashboard.component.html',
  styleUrls: ['dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  addressList: AddressDTO[] = [];

  pagination: Pagination = <Pagination>{
    pageNumber: 1,
    pageSize: 10
  };

  constructor(private addressService: AddressService, private spinner: NgxSpinnerService, public ngxSmartModalService: NgxSmartModalService, private toastEvokeService: ToastEvokeService, private confirmBoxEvokeService: ConfirmBoxEvokeService) {
    this.ngxSmartModalService.create('myModal', AddAddressComponent);
  }

  ngOnInit(): void {
    this.getData();
  }

  search() {
    this.pagination.pageNumber = 1;
    this.getData();
  }

  getData() {
    this.spinner.show();
    this.addressService.getSearchData(this.pagination).subscribe({
      next: (res) => {
        this.addressList = res.result;
        this.pagination = res.pagination;
        this.spinner.hide();
      },
      error: (err) => {
        console.log(err);
        this.spinner.hide();
      }
    })
  }

  pageChanged(event: any) {
    this.pagination.pageNumber = event;
  }


  async openEditModal(address: AddressDTO) {
    this.ngxSmartModalService.setModalData(address, 'myModal');
    this.ngxSmartModalService.getModal('myModal').open();
    let data = await firstValueFrom(this.ngxSmartModalService.get('myModal').onDismiss);
    await firstValueFrom(this.addressService.update(data.data).pipe(
      tap((res) => {
        if (res.isSuccess) {
          this.toastEvokeService.success('Success', 'Update Successfully').subscribe();
          this.search();
        }
        else {
          this.toastEvokeService.danger('Error', 'Update Failed').subscribe();
        }
      }),
      catchError((err) => {
        this.toastEvokeService.danger('Error', 'Something error here').subscribe();
        return of(null);
      })
    ));
  }

  async openAddModal() {
    this.ngxSmartModalService.getModal('myModal').open();
    let data = await firstValueFrom(this.ngxSmartModalService.get('myModal').onDismiss);
    await firstValueFrom(this.addressService.addNew(data.data).pipe(
      tap((res) => {
        if (res.isSuccess) {
          this.toastEvokeService.success('Success', 'Add Successfully').subscribe();
          this.search();
        }
        else {
          this.toastEvokeService.danger('Error', 'Add Failed').subscribe();
        }
      }),
      catchError((err) => {
        this.toastEvokeService.danger('Error', 'Something error here').subscribe();
        return of(null);
      })
    ));
  }

  async deleteItem(item: AddressDTO) {
    let check = await firstValueFrom(this.confirmBoxEvokeService.warning('Warning!', 'Are you sure you want to delete this record!', 'Confirm', 'Decline'));
    if (check.success) {
      await firstValueFrom(this.addressService.delete(item.addressID).pipe(
        tap((res) => {
          if (res.isSuccess) {
            this.toastEvokeService.success('Success', 'Delete Successfully').subscribe();
            this.search();
          }
          else {
            this.toastEvokeService.danger('Error', 'Delete Failed').subscribe();
          }
        }),
        catchError((err) => {
          this.toastEvokeService.danger('Error', 'Something error here').subscribe();
          return of(null);
        })
      ))
    }
  }
}
