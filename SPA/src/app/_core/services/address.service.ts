import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { PaginationParam, PaginationResult } from '../helpers/utilities/pagination-utility';
import { AddressDTO } from '../models/addressDto';
import { OperationResult } from '../helpers/utilities/operation-result';
@Injectable({
  providedIn: 'root'
})
export class AddressService {
  apiUrl: string = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getSearchData(pagination: PaginationParam) {
    let params = new HttpParams().appendAll({ ...pagination });
    return this.http.get<PaginationResult<AddressDTO>>(this.apiUrl + "Address/SearchData", { params: params });
  }

  addNew(address: AddressDTO) {
    return this.http.post<OperationResult>(this.apiUrl + "Address/AddNewAddress", address);
  }

  update(address: AddressDTO) {
    return this.http.put<OperationResult>(this.apiUrl + "Address/UpdateAddress", address);
  }

  delete(addressID : number){
    let params = new HttpParams().append('addressID', addressID)
    return this.http.delete<OperationResult>(this.apiUrl + 'Address/DeleteAddress', {params} );
  }
}
