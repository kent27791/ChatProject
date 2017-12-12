import { Component, OnInit } from '@angular/core';
import {MockServerResultsService} from "./service/mock-server-results-service";
import {GroupMemberService} from "./service/group-member.service";
import {PagedData} from "./model/paged-data";
import {CorporateEmployee} from "./model/corporate-employee";
import {Page} from "./model/page";
import {DataTableRequest} from './model/datatable-request'
@Component({
  selector: 'group-member',
  templateUrl: './group-member.component.html',
  styleUrls: ['./group-member.component.scss'],
  providers: [
    MockServerResultsService,
    GroupMemberService
  ]
})
export class GroupMemberComponent implements OnInit {
  page = new Page();
  rows = new Array<CorporateEmployee>();

  constructor(private serverResultsService: MockServerResultsService, private groupMemberService: GroupMemberService) {
    this.page.pageNumber = 0;
    this.page.size = 20;
  }

  ngOnInit() {
    let request = new DataTableRequest();
    request.offset = 1;
    request.page_size = 5;

    this.groupMemberService.getDatatable(request).subscribe(data =>{
        console.log(data); 
    });
    this.setPage({ offset: 0 });
  }

  setPage(pageInfo){
    console.log(pageInfo);
    this.page.pageNumber = pageInfo.offset;
    this.serverResultsService.getResults(this.page).subscribe(pagedData => {
      this.page = pagedData.page;
      this.rows = pagedData.data;
    });
  }

}