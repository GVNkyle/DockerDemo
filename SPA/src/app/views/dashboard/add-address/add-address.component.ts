import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { NgxSmartModalService } from 'ngx-smart-modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { AddressDTO } from 'src/app/_core/models/addressDto';
import { AddressService } from 'src/app/_core/services/address.service';

@Component({
  selector: 'app-add-address',
  templateUrl: './add-address.component.html',
  styleUrls: ['./add-address.component.scss']
})
export class AddAddressComponent implements OnInit {
  address: AddressDTO = <AddressDTO>{};
  temp: AddressDTO = <AddressDTO>{};

  constructor(private addressService: AddressService, private spinner: NgxSpinnerService, public ngxSmartModalService: NgxSmartModalService) { }

  ngOnInit(): void {
    this.temp = this.ngxSmartModalService.getModalData('myModal');
    this.ngxSmartModalService.resetModalData('myModal');
    if (this.temp) this.address = { ...this.temp };
  }

  onSubmit() {
    let check = this.temp === undefined ? true : false;
    this.ngxSmartModalService.get('myModal').onDismiss.emit({ isSuccess: check, data: this.address, error: null });
    this.ngxSmartModalService.get('myModal').close();
  }

}
