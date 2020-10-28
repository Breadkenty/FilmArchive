import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Entry } from "./models/Entry/entry.model";

@Injectable({
  providedIn: "root",
})
export class DataService {
  apiUrl = "/api/Entries";

  constructor(private _http: HttpClient) {}

  getEntries() {
    return this._http.get<Entry[]>(this.apiUrl);
  }
}
