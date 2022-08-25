import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { AddressDTO } from 'src/app/_core/models/addressDto';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { OperationResult } from '../../../_core/helpers/utilities/operation-result';

@Component({
  selector: 'app-add-address',
  templateUrl: './add-address.component.html',
  styleUrls: ['./add-address.component.scss']
})
export class AddAddressComponent implements OnInit {
  address: AddressDTO = <AddressDTO>{};
  type: boolean;
  @Output() addressOutput = new EventEmitter();
  constructor(public bsModalRef: BsModalRef) { }

  ngOnInit(): void {
    this.type = this.address.addressID > 0;
  }

  onSubmit() {
    this.addressOutput.emit(<OperationResult>{ data: this.address, isSuccess: this.type })
    this.bsModalRef.hide();
  }

}
