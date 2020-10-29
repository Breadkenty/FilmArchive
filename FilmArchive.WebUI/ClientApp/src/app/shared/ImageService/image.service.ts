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

  async uploadImages(files) {
    const response = await fetch("/api/Uploads", {
      method: "POST",
      body: files,
    });
    const apiResponse = await response.json();
    const url = apiResponse.url;
    return url;
  }
}
