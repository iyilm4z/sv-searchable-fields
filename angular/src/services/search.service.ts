import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { SearchResult } from "src/models/searh-result";
import { environment } from "../environments/environment";

@Injectable()
export class SearchService {
  constructor(private http: HttpClient) {}

  search(textToSearch: string): Observable<SearchResult> {
    const url = environment.apiUrl + "Search?textToSearch=" + textToSearch;

    return this.http.get<SearchResult>(url);
  }
}
