import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { DataTableRequest } from '../model/datatable-request';
import { DatatableResponse } from '../model/datatable-response';
import { GroupMember } from '../model/group-member';
import {Observable} from "rxjs";
@Injectable()
export class GroupMemberService {
  
  constructor(private http: Http) { }

  getDatatable(request: DataTableRequest) : Observable<DatatableResponse<GroupMember>> {
    let pagedData = new DatatableResponse<GroupMember>();
    let headers = new Headers({ 'Content-Type': 'application/json' });
    return this.http.post('http://localhost:7656/api/group-member/datatable', request, { headers: headers })
    .map(responseData => {
      return responseData.json();
    })
    .map((data: DatatableResponse<GroupMember>) =>{
      return data;
    });
  }
}