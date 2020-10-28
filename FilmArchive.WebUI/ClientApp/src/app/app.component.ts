import { Component, OnInit } from "@angular/core";
import { Data } from "@angular/router";
import * as moment from "moment";
import { DataService } from "./data.service";
import { Entry } from "./models/Entry/entry.model";
import { ImageService } from "./shared/image.service";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
})
export class AppComponent implements OnInit {
  entries$: Entry[];
  entry$: Entry;

  constructor(private imageService: ImageService) {}

  ngOnInit() {
    // return this.imageService
    //   .getEntries()
    //   .subscribe((data) => (this.entries$ = data));

    return this.imageService
      .getEntry(5)
      .subscribe((data) => (this.entry$ = data));
  }

  convertDate(date: Date, format: string) {
    return moment(date).format(format);
  }
}
