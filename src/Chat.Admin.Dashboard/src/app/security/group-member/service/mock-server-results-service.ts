import {Injectable} from "@angular/core";
import {Observable} from "rxjs";
import {PagedData} from "../model/paged-data";
import {CorporateEmployee} from "../model/corporate-employee";
import {Page} from "../model/page";

declare var require: any
const companyData = require('../data/company.json');


@Injectable()
export class MockServerResultsService {

    
    public getResults(page: Page): Observable<PagedData<CorporateEmployee>> {
        return Observable.of(companyData).map(data => this.getPagedData(page));
    }

    private getPagedData(page: Page): PagedData<CorporateEmployee> {
        let pagedData = new PagedData<CorporateEmployee>();
        page.totalElements = companyData.length;
        page.totalPages = page.totalElements / page.size;
        let start = page.pageNumber * page.size;
        let end = Math.min((start + page.size), page.totalElements);
        for (let i = start; i < end; i++){
            let jsonObj = companyData[i];
            let employee = new CorporateEmployee(jsonObj.name, jsonObj.gender, jsonObj.company, jsonObj.age);
            pagedData.data.push(employee);
        }
        pagedData.page = page;
        return pagedData;
    }

}