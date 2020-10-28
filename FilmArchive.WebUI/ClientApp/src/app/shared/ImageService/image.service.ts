import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Entry } from "src/app/models/Entry/entry.model";

@Injectable({
  providedIn: "root",
})
export class ImageService {
  constructor(private _http: HttpClient) {}

  getEntries() {
    return this._http.get<Entry[]>("/api/Entries");
  }

  getEntry(id: number) {
    return this._http.get<Entry>(`/api/Entries/${id}`);
  }
}
