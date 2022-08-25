import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { catchError, firstValueFrom, of, tap } from 'rxjs';
import { OperationResult } from 'src/app/_core/helpers/utilities/operation-result';
import { Pagination } from 'src/app/_core/helpers/utilities/pagination-utility';
import { AddressDTO } from 'src/app/_core/models/addressDto';
import { NgxNotiflixService } from 'src/app/_core/services/ngx-notiflix.service';
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
  bsModalRef?: BsModalRef;
  constructor(private addressService: AddressService, private notiflixService: NgxNotiflixService, private modalService: BsModalService) {
  }

  ngOnInit(): void {
    this.getData();
  }

  search() {
    this.pagination.pageNumber = 1;
    this.getData();
  }

  getData() {
    this.notiflixService.showLoading();
    this.addressService.getSearchData(this.pagination).subscribe({
      next: (res) => {
        this.addressList = res.result;
        this.pagination = res.pagination;
        this.notiflixService.hideLoading();
      },
      error: (err) => {
        console.log(err);
        this.notiflixService.hideLoading();
      }
    })
  }

  pageChanged(event: any) {
    this.pagination.pageNumber = event;
  }


  async openEditModal(address: AddressDTO) {
    const initialState: ModalOptions = {
      class: 'modal-lg',
      initialState: {
        address : address
      }
    };
    this.bsModalRef = this.modalService.show(AddAddressComponent, initialState);
    this.bsModalRef.content.addressOutput.subscribe(async (response: OperationResult) => {
      if (response.isSuccess) {
        await firstValueFrom(this.addressService.update(response.data).pipe(
          tap((res) => {
            if (res.isSuccess) {
              this.notiflixService.success('Update Successfully');
              this.search();
            }
            else {
              this.notiflixService.error('Update Failed');
            }
          }),
          catchError((err) => {
            this.notiflixService.error('Something error here');
            return of(null);
          })
        ));
      } else {
        this.notiflixService.error("Something error here");
      }
    })
  }

  async openAddModal() {
    const initialState: ModalOptions = {
      class: 'modal-lg',
    };
    this.bsModalRef = this.modalService.show(AddAddressComponent, initialState);
    this.bsModalRef.content.addressOutput.subscribe(async (response: OperationResult) => {
      if (!response.isSuccess) {
        await firstValueFrom(this.addressService.addNew(response.data).pipe(
          tap((res) => {
            if (res.isSuccess) {
              this.notiflixService.success('Add Successfully');
              this.search();
            }
            else {
              this.notiflixService.error('Add Failed');
            }
          }),
          catchError((err) => {
            this.notiflixService.error('Something error here');
            return of(null);
          })
        ));
      } else {
        this.notiflixService.error("Something error here");
      }
    })
  }

  async deleteItem(item: AddressDTO) {
    this.notiflixService.confirm('Warning!', 'Are you sure you want to delete this record?', async () => {
      await firstValueFrom(this.addressService.delete(item.addressID).pipe(
        tap((res) => {
          if (res.isSuccess) {
            this.notiflixService.success('Delete Successfully');
            this.search();
          }
          else {
            this.notiflixService.error('Delete Failed');
          }
        }),
        catchError((err) => {
          this.notiflixService.error('Something error here');
          return of(null);
        })
      ))
    })
  }
}
